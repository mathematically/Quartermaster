using System.Linq.Expressions;
using System.Windows;
using ExpectedObjects;
using FluentAssertions;
using Mathematically.Quartermaster.Domain;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Tests.Fixtures;
using Mathematically.Quartermaster.ViewModels;
using NSubstitute;
using Quartermaster.Infrastructure;
using Xunit;

namespace Mathematically.Quartermaster.Tests.Specs
{
    /// <summary>
    /// GIVEN the app is running
    /// WHEN an item is copied to the clipboard in game
    /// THEN the item should be displayed in the UI
    /// </summary>
    public class AutoDisplayClipboardItemFeature
    {
        private readonly IClipboardMonitor _clipboardMonitor = Substitute.For<IClipboardMonitor>();

        private ItemTextSanityCheck _itemTextSanityCheck;
        private ClipboardItemTextSource _clipboardItemTextSource;
        private QuartermasterStore _quartermaster;
        private QuartermasterViewModel _quartermasterViewModel;

        private readonly ExpectedObject _noItem = new EmptyPoeItem().ToExpectedObject();

        private void StartQuartermaster()
        {
            _itemTextSanityCheck = new ItemTextSanityCheck();
            _clipboardItemTextSource = new ClipboardItemTextSource(_clipboardMonitor, _itemTextSanityCheck);
            _quartermaster = new QuartermasterStore(_clipboardItemTextSource);
            _quartermasterViewModel = new QuartermasterViewModel(_quartermaster, _clipboardMonitor);

            _quartermasterViewModel.MonitorEvents();
        }

        [Fact]
        public void On_startup_if_the_clipboard_is_empty_then_no_item_should_be_displayed()
        {
            StartQuartermaster();

            IPoeItem currentItem = _quartermaster.Item;

            currentItem.ShouldMatch(_noItem);
        }

        [Fact]
        public void Copying_an_iron_ring_in_game_sets_the_displayed_item_to_an_iron_ring()
        {
            var ironRing = new PoeItem(

                    "Iron Ring", 
                    ItemRarity.Normal

                ).ToExpectedObject();

            StartQuartermaster();

            _clipboardMonitor.ClipboardTextArrived += Raise.EventWith(new object(), new ClipboardChangedEventArgs(ItemTextExamples.IronRing));

            _quartermasterViewModel.Item.ShouldMatch(ironRing);
            _quartermasterViewModel.ShouldRaisePropertyChangeFor(x => x.Item);
        }
    }
}
