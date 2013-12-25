using System.Linq.Expressions;
using System.Windows;
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

namespace Mathematically.Quartermaster.Tests.Specs
{
    /// <summary>
    /// GIVEN the app is running
    /// WHEN an item is copied to the clipboard in game
    /// THEN the item should be displayed in the 
    /// UI
    /// </summary>
    public class AutoDisplayClipboardItemFeature: QuartermasterFixture
    {
        private readonly IClipboardMonitor _clipboardMonitor = Substitute.For<IClipboardMonitor>();

        private QuartermasterStore _quartermaster;
        private QuartermasterViewModel _quartermasterViewModel;
        private ClipboardItemTextSource _clipboardItemTextSource;
        private ItemTextChecker _itemTextChecker;

        private void StartQuartermaster()
        {
            _itemTextChecker = new ItemTextChecker();
            _clipboardItemTextSource = new ClipboardItemTextSource(_clipboardMonitor, _itemTextChecker);
            _quartermaster = new QuartermasterStore(_clipboardItemTextSource);
            _quartermasterViewModel = new QuartermasterViewModel(_quartermaster, _clipboardMonitor);

            _quartermasterViewModel.MonitorEvents();
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

            _quartermaster.Item.ShouldMatch(ExpectedIronRingItem);
            _quartermasterViewModel.Item.ShouldMatch(ExpectedIronRingItem);
        }

        [Fact]
        public void Copying_an_iron_ring_in_game_sets_the_displayed_item_to_an_iron_ring()
        {
            StartQuartermaster();

            _clipboardMonitor.ClipboardTextArrived += Raise.EventWith(new object(), new ClipboardChangedEventArgs(ItemTextExamples.IronRing));

            _quartermasterViewModel.Item.ShouldMatch(ExpectedIronRingItem);
            _quartermasterViewModel.ShouldRaisePropertyChangeFor(x => x.Item);
        }
    }
}
