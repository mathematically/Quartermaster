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
    public class ClipboardItemTextSourceTests
    {
        private readonly Fixture _fixture = new Fixture();

        private readonly IClipboardMonitor _clipboardMonitor = Substitute.For<IClipboardMonitor>();
        private readonly IItemTextSanityCheck _itemTextSanityCheck = Substitute.For<IItemTextSanityCheck>();

        private ClipboardItemTextSource _sut;
        private string _actualItemText;

        private void CreateSUT()
        {
            _sut = new ClipboardItemTextSource(_clipboardMonitor, _itemTextSanityCheck);
            ListenForClipboardUpdates();
        }

        private void ListenForClipboardUpdates()
        {
            _actualItemText = string.Empty;
            _sut.ItemTextArrived += (s, a) => _actualItemText = a.ItemText;
        }

        [Fact]
        public void When_the_clipboard_is_updated_with_game_text_the_item_arrived_event_is_raised()
        {
            CreateSUT();

            FakeItemCopy(ItemTextExamples.IronRing);

            _actualItemText.Should().NotBeNullOrEmpty();
        }

        private void FakeItemCopy(string itemText)
        {
            // I suppose we could do this for real via the clipboard like this...
            //      Clipboard.SetData(DataFormats.Text, itemText);
            // .. but that would mean getting a hwndSource somehow so just raise the event on the fake
            // as if we had done that.
            _clipboardMonitor.ClipboardTextArrived += Raise.EventWith(new object(),
                new ClipboardChangedEventArgs(itemText));
        }

        [Fact]
        public void When_the_clipboard_is_updated_with_non_game_text_the_item_arrived_event_is_not_raised()
        {
            CreateSUT();
            PasteNonItemText();

            FakeItemCopy(_fixture.Create<string>());

            _actualItemText.Should().BeNullOrEmpty();
        }

        private Action PasteNonItemText()
        {
            return () => FakeItemCopy(_fixture.Create<string>());
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

            _actualItemText.Should().Be(ItemTextExamples.IronRing);
        }

        private void PasteIronRing()
        {
            FakeItemCopy(ItemTextExamples.IronRing);
        }

        [Fact]
        public void When_the_clipboard_is_updated_with_game_text_the_game_text_should_be_reported_via_the_item_arrived_event()
        {
            CreateSUT();

            PasteIronRing();

            _actualItemText.Should().Be(ItemTextExamples.IronRing);
        }
    }
}