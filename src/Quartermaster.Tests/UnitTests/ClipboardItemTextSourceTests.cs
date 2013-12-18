using System;
using FluentAssertions;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Tests.Fixtures;
using NSubstitute;
using Ploeh.AutoFixture;
using Quartermaster.Infrastructure;
using Xunit;

namespace Mathematically.Quartermaster.Tests.UnitTests
{
    public class ClipboardItemTextSourceTests: QuartermasterFixture
    {
        private readonly IClipboardMonitor _clipboardMonitor = Substitute.For<IClipboardMonitor>();
        private readonly IItemTextSanityCheck _itemTextSanityCheck = Substitute.For<IItemTextSanityCheck>();

        private ClipboardItemTextSource _sut;
        private string _itemArrivedEventText = string.Empty;

        public ClipboardItemTextSourceTests()
        {
            ConfigureSanityChecker();
        }

        private void CreateSUT()
        {
            _sut = new ClipboardItemTextSource(_clipboardMonitor, _itemTextSanityCheck);
            ListenForClipboardUpdates();
        }

        private void ListenForClipboardUpdates()
        {
            _sut.ItemTextArrived += (s, a) => _itemArrivedEventText = a.ItemText;
        }

        private void ConfigureSanityChecker()
        {
            _itemTextSanityCheck.LooksLikeGameText(Arg.Any<string>()).Returns(false);
            _itemTextSanityCheck.LooksLikeGameText(Arg.Is(ItemTextExamples.IronRing)).Returns(true);
        }

        [Fact]
        public void If_an_item_is_already_in_the_clipboard_at_startup_then_it_will_be_available_in_the_item_property()
        {
            _clipboardMonitor.CurrentText.Returns(ItemTextExamples.IronRing);
            CreateSUT();

            _sut.ItemText.Should().Be(ItemTextExamples.IronRing);
        }

        [Fact]
        public void When_the_clipboard_is_updated_with_game_text_the_item_arrived_event_is_raised()
        {
            CreateSUT();

            FakeItemCopy(ItemTextExamples.IronRing);

            _itemArrivedEventText.Should().NotBeNullOrEmpty();
        }

        private void FakeItemCopy(string itemText)
        {
            _clipboardMonitor.ClipboardTextArrived += Raise.EventWith(new object(),
                new ClipboardChangedEventArgs(itemText));
        }

        [Fact]
        public void When_the_clipboard_is_updated_with_non_game_text_the_item_arrived_event_is_not_raised()
        {
            CreateSUT();

            FakeItemCopy(Auto.Create<string>());

            _itemArrivedEventText.Should().BeNullOrEmpty();
        }

        [Fact]
        public void When_the_clipboard_is_updated_with_null_the_item_arrived_event_is_not_raised()
        {
            CreateSUT();

            PasteNullText()
                .ShouldNotThrow();
        }

        private Action PasteNullText()
        {
            return () => FakeItemCopy(null);
        }

        [Fact]
        public void When_the_clipboard_is_updated_with_invalid_text_previous_text_is_not_lost()
        {
            CreateSUT();
            PasteIronRing();

            PasteNonItemText()
                .ShouldNotThrow();

            _itemArrivedEventText.Should().Be(ItemTextExamples.IronRing);
        }

        private void PasteIronRing()
        {
            FakeItemCopy(ItemTextExamples.IronRing);
        }

        private Action PasteNonItemText()
        {
            return () => FakeItemCopy(Auto.Create<string>());
        }

        [Fact]
        public void When_the_clipboard_is_updated_with_game_text_the_game_text_should_be_reported_via_the_item_arrived_event()
        {
            CreateSUT();

            PasteIronRing();

            _itemArrivedEventText.Should().Be(ItemTextExamples.IronRing);
        }
    }
}