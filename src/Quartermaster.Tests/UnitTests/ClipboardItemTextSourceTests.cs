using System;
using FluentAssertions;
using Mathematically.Quartermaster.Domain.Parser;
using Mathematically.Quartermaster.Tests.Examples;
using NSubstitute;
using Ploeh.AutoFixture;
using Quartermaster.Infrastructure;
using Xunit;

namespace Mathematically.Quartermaster.Tests.UnitTests
{
    [Trait("Clipboard item text source", "")]
    public class ClipboardItemTextSourceTests
    {
        private readonly Fixture _auto = new Fixture();

        private readonly IClipboardMonitor _clipboardMonitor = Substitute.For<IClipboardMonitor>();
        private readonly IItemTextChecker _itemTextChecker = Substitute.For<IItemTextChecker>();

        private ClipboardItemTextSource _sut;

        private string _itemArrivedEventText = string.Empty;

        public ClipboardItemTextSourceTests()
        {
            ConfigureSanityChecker();
        }

        private void CreateSUT()
        {
            _sut = new ClipboardItemTextSource(_clipboardMonitor, _itemTextChecker);
            ListenForClipboardUpdates();
        }

        private void ListenForClipboardUpdates()
        {
            _sut.ItemTextArrived += (s, a) => _itemArrivedEventText = a.ItemText;
        }

        private void ConfigureSanityChecker()
        {
            _itemTextChecker.LooksLikeGameText(Arg.Any<string>()).Returns(false);
            _itemTextChecker.LooksLikeGameText(Arg.Is(Rings.IronRingText)).Returns(true);
        }

        [Fact]
        public void If_an_item_is_already_in_the_clipboard_at_startup_then_it_will_be_available_in_the_item_property()
        {
            _clipboardMonitor.CurrentText.Returns(Rings.IronRingText);
            CreateSUT();

            _sut.ItemText.Should().Be(Rings.IronRingText);
        }

        [Fact]
        public void When_the_clipboard_is_updated_with_game_text_the_item_arrived_event_is_raised()
        {
            CreateSUT();

            PasteIronRing();

            _itemArrivedEventText.Should().Be(Rings.IronRingText);
        }

        private void FakeItemCopy(string itemText)
        {
            _clipboardMonitor.ClipboardTextArrived += Raise.EventWith(new object(), new ClipboardChangedEventArgs(itemText));
        }

        [Fact]
        public void When_the_clipboard_is_updated_with_non_game_text_the_item_arrived_event_is_not_raised()
        {
            CreateSUT();

            FakeItemCopy(_auto.Create<string>());

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
        public void When_the_clipboard_is_updated_with_invalid_text_any_previous_valid_text_is_not_lost()
        {
            CreateSUT();
            PasteIronRing();

            PasteNonItemText()
                .ShouldNotThrow();

            _itemArrivedEventText.Should().Be(Rings.IronRingText);
        }

        private void PasteIronRing()
        {
            FakeItemCopy(Rings.IronRingText);
        }

        private Action PasteNonItemText()
        {
            return () => FakeItemCopy(_auto.Create<string>());
        }

        [Fact]
        public void When_the_clipboard_is_updated_with_game_text_the_game_text_should_be_reported_via_the_item_arrived_event()
        {
            CreateSUT();

            PasteIronRing();

            _itemArrivedEventText.Should().Be(Rings.IronRingText);
        }
    }
}