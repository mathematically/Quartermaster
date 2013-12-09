using System.Windows;
using ExpectedObjects;
using Mathematically.Quartermaster.Domain;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.ViewModel;
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

        private ClipboardItemTextSource _clipboardItemTextSource;
        private QuartermasterStore _quartermaster;
        private QuartermasterViewModel _quartermasterViewModel;

        private readonly ExpectedObject _noItem = new EmptyPoeItem().ToExpectedObject();

        private void StartQuartermaster()
        {
            _clipboardItemTextSource = new ClipboardItemTextSource(_clipboardMonitor);
            _quartermaster = new QuartermasterStore(_clipboardItemTextSource);
            _quartermasterViewModel = new QuartermasterViewModel(_quartermaster);
        }

        [Fact]
        public void On_startup_if_the_clipboard_is_empty_then_no_item_should_be_displayed()
        {
            //Clipboard.Clear();
            StartQuartermaster();

            IPoeItem currentItem = _quartermaster.Item;

            currentItem.ShouldMatch(_noItem);
        }

        [Fact]
        public void Copying_an_iron_ring_in_game_sets_the_displayed_item_to_an_iron_ring()
        {
            const string ironRingGameText = @"Rarity: Normal
Iron Ring
--------
Itemlevel: 4
--------
Adds 1-4 Physical Damage";

            var ironRing = new PoeItem(

                    "Iron Ring", 
                    ItemRarity.Normal

                ).ToExpectedObject();

            StartQuartermaster();

            //Clipboard.SetData(DataFormats.Text, ironRingGameText);
            _clipboardMonitor.ClipboardTextArrived += Raise.EventWith(new object(), new ClipboardChangedEventArgs(ironRingGameText));

            _quartermasterViewModel.Item.ShouldMatch(ironRing);
        }
    }
}
