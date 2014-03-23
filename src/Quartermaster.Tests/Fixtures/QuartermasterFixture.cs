using ExpectedObjects;
using Mathematically.Quartermaster.Domain;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Domain.Parser;
using NSubstitute;
using Ploeh.AutoFixture;
using Quartermaster.Infrastructure;

namespace Mathematically.Quartermaster.Tests.Fixtures
{
    public class QuartermasterFixture
    {
        protected readonly Fixture Auto = new Fixture();
        protected readonly ExpectedObject NoItem = new NullPoeItem().ToExpectedObject();

        // The only thing faked in these tests is the base clipboard/interop stuff.
        protected readonly IClipboardMonitor ClipboardMonitor = Substitute.For<IClipboardMonitor>();

        private readonly ItemTextChecker _itemTextChecker = new ItemTextChecker();
        private readonly PoeItemParser _itemParser = new PoeItemParser();

        private PoeItemFactory _itemFactory;
        private ClipboardItemTextSource _clipboardItemTextSource;

        protected QuartermasterStore Quartermaster;

        protected virtual void StartQuartermaster()
        {
            _itemFactory = new PoeItemFactory(_itemParser);
            _clipboardItemTextSource = new ClipboardItemTextSource(ClipboardMonitor, _itemTextChecker);

            Quartermaster = new QuartermasterStore(_itemFactory, _clipboardItemTextSource);
        }

        protected void CopyIntoClipboard(string gameItemText)
        {
            ClipboardMonitor.CurrentText.Returns(gameItemText);
            ClipboardMonitor.ClipboardTextArrived += Raise.EventWith(new object(), new ClipboardChangedEventArgs(gameItemText));
        }
    }
}