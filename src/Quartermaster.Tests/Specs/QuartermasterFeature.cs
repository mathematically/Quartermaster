using Mathematically.Quartermaster.Domain;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Tests.Fixtures;
using NSubstitute;
using Quartermaster.Infrastructure;

namespace Mathematically.Quartermaster.Tests.Specs
{
    public class QuartermasterFeature : TestItemsFixture
    {
        // The only thing faked for feature tests is the base clipboard/interop stuff.
        protected readonly IClipboardMonitor ClipboardMonitor = Substitute.For<IClipboardMonitor>();

        private ClipboardItemTextSource _clipboardItemTextSource;
        private ItemTextChecker _itemTextChecker;
        private PoeItemParser _itemParser;
        private PoeItemFactory _itemFactory;
        protected QuartermasterStore Quartermaster;

        protected virtual void StartQuartermaster()
        {
            _itemTextChecker = new ItemTextChecker();
            _itemParser = new PoeItemParser();
            _itemFactory = new PoeItemFactory(_itemParser);
            _clipboardItemTextSource = new ClipboardItemTextSource(ClipboardMonitor, _itemTextChecker);

            Quartermaster = new QuartermasterStore(_itemFactory, _clipboardItemTextSource);
        }

        protected void PasteIntoClipboard(string gameItemText)
        {
            ClipboardMonitor.CurrentText.Returns(gameItemText);
            ClipboardMonitor.ClipboardTextArrived += Raise.EventWith(new object(), new ClipboardChangedEventArgs(gameItemText));
        }
    }
}