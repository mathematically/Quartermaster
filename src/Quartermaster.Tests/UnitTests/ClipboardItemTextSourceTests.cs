using FluentAssertions;
using Mathematically.Quartermaster.Tests.Fixtures;
using NSubstitute;
using Quartermaster.Infrastructure;
using Xunit;

namespace Mathematically.Quartermaster.Tests.UnitTests
{
    public class ClipboardItemTextSourceTests
    {
        private readonly IClipboardMonitor _clipboardMonitor = Substitute.For<IClipboardMonitor>();

        private ClipboardItemTextSource _sut;
        private string _actualItemText;

        private void CreateSUT()
        {
            _sut = new ClipboardItemTextSource(_clipboardMonitor);

            ListenForClipboardUpdates();
        }

        private void ListenForClipboardUpdates()
        {
            _actualItemText = string.Empty;
            _sut.ItemTextArrived += (s, a) => _actualItemText = a.ItemText;
        }

        private void FakeItemCopy(string itemText)
        {
            // Ideally we would do this for real via the clipboard like this...
            //Clipboard.SetData(DataFormats.Text, itemText);

            // .. but that would mean getting a hwndSource somehow so just raise the event on the fake
            // as if we had done that.
            _clipboardMonitor.ClipboardTextArrived += Raise.EventWith(new object(),
                new ClipboardChangedEventArgs(itemText));
        }

        [Fact]
        public void When_the_clipboard_is_updated_with_game_text_the_item_arrived_event_is_raised()
        {
            CreateSUT();

            FakeItemCopy(ItemTextFixture.IronRing);

            _actualItemText.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void When_the_clipboard_is_updated_with_game_text_the_game_text_should_be_reported_via_the_item_arrived_event()
        {
            CreateSUT();

            FakeItemCopy(ItemTextFixture.IronRing);

            _actualItemText.Should().Be(ItemTextFixture.IronRing);
        }
    }
}