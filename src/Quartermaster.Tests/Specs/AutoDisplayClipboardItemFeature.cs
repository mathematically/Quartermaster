using System.Windows;
using Caliburn.Micro;
using ExpectedObjects;
using FluentAssertions;
using Mathematically.Quartermaster.Domain;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Tests.Fixtures;
using Mathematically.Quartermaster.ViewModels;
using NSubstitute;
using Ploeh.AutoFixture;
using Quartermaster.Infrastructure;
using Xunit;
using Xunit.Extensions;
using Action = System.Action;

namespace Mathematically.Quartermaster.Tests.Specs
{
    /// <summary>
    ///     GIVEN the app is running
    ///     WHEN an item is copied to the clipboard in game
    ///     THEN the item should be displayed in the UI
    /// </summary>
    public class AutoDisplayClipboardItemFeature : QuartermasterFixture
    {
        private readonly IClipboardMonitor _clipboardMonitor = Substitute.For<IClipboardMonitor>();

        private ClipboardItemTextSource _clipboardItemTextSource;
        private ItemTextChecker _itemTextChecker;
        private PoeItemParser _itemParser;
        private PoeItemFactory _itemFactory;
        private QuartermasterStore _quartermaster;
        private QuartermasterViewModel _quartermasterViewModel;

        private void StartQuartermaster()
        {
            _itemTextChecker = new ItemTextChecker();
            _itemParser = new PoeItemParser();
            _itemFactory = new PoeItemFactory(_itemParser);
            _clipboardItemTextSource = new ClipboardItemTextSource(_clipboardMonitor, _itemTextChecker);
            _quartermaster = new QuartermasterStore(_itemFactory, _clipboardItemTextSource);
            _quartermasterViewModel = new QuartermasterViewModel(_quartermaster, _clipboardMonitor);

            _quartermasterViewModel.MonitorEvents();
        }

        [Theory]
        [InlineData(ItemTextExamples.IronRing, IronRingName)]
        [InlineData(ItemTextExamples.SapphireRing, SapphireRingName)]
        [InlineData(ItemTextExamples.ThirstyRubyRingOfSuccess, ThirstyRubyRingOfSuccessName)]
        public void Copying_item_text_in_game_sets_the_displayed_item_to_the_item_that_text_represents(
            string gameItemText, string itemName)
        {
            var expectedItem = GetExpectedItem(itemName);
            StartQuartermaster();

            PasteIntoClipboard(gameItemText);

            _quartermaster.Item.ShouldMatch(expectedItem);
            _quartermasterViewModel.Item.ShouldMatch(expectedItem);
            _quartermasterViewModel.ShouldRaisePropertyChangeFor(x => x.Item);
        }

        private void PasteIntoClipboard(string gameItemText)
        {
            _clipboardMonitor.CurrentText.Returns(gameItemText);
            _clipboardMonitor.ClipboardTextArrived += Raise.EventWith(new object(),
                new ClipboardChangedEventArgs(gameItemText));
        }

        [Fact]
        public void On_startup_if_the_clipboard_is_empty_then_no_item_should_be_displayed()
        {
            StartQuartermaster();

            _quartermaster.Item.ShouldMatch(NoItem);
        }

        [Fact]
        public void On_startup_if_the_clipboard_has_non_poe_content_then_no_item_should_be_displayed()
        {
            Clipboard.SetData(DataFormats.Text, Auto.Create<string>());

            StartQuartermaster();

            _quartermaster.Item.ShouldMatch(NoItem);
        }

        [Fact]
        public void On_startup_if_the_clipboard_has_an_iron_ring_then_an_iron_ring_should_be_displayed()
        {
            _clipboardMonitor.CurrentText.Returns(ItemTextExamples.IronRing);

            StartQuartermaster();

            _quartermaster.Item.ShouldMatch(IronRingItem);
            _quartermasterViewModel.Item.ShouldMatch(IronRingItem);
        }
    }
}