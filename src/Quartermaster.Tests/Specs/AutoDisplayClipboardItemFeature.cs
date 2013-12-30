using System.Windows;
using Caliburn.Micro;
using ExpectedObjects;
using FluentAssertions;
using Mathematically.Quartermaster.Tests.ExampleItems;
using Mathematically.Quartermaster.ViewModels;
using NSubstitute;
using Ploeh.AutoFixture;
using Xunit;
using Xunit.Extensions;

namespace Mathematically.Quartermaster.Tests.Specs
{
    public class AutoDisplayClipboardItemFeature : QuartermasterFeature
    {
        private QuartermasterViewModel _quartermasterViewModel;

        protected override void StartQuartermaster()
        {
            base.StartQuartermaster();

            _quartermasterViewModel = new QuartermasterViewModel(Substitute.For<IWindowManager>(), Quartermaster, ClipboardMonitor);
            _quartermasterViewModel.MonitorEvents();
        }

        [Theory]
        [InlineData(Rings.IronRing, IronRingName)]
        [InlineData(Rings.SapphireRing, SapphireRingName)]
        [InlineData(Rings.ThirstyRubyRingOfSuccess, ThirstyRubyRingOfSuccessName)]
        [InlineData(Weapons.DriftwoodWand, DriftwoodWandName)]
        [InlineData(Weapons.DriftwoodMaul, DriftwoodMaulName)]
        public void Copying_item_text_in_game_sets_the_displayed_item_to_the_item_that_text_represents(
            string gameItemText, string itemName)
        {
            var expectedItem = GetExpectedItem(itemName);
            StartQuartermaster();

            PasteIntoClipboard(gameItemText);

            Quartermaster.Item.ShouldMatch(expectedItem);
            _quartermasterViewModel.Item.ShouldMatch(expectedItem);
            _quartermasterViewModel.ShouldRaisePropertyChangeFor(x => x.Item);
        }

        [Fact]
        public void On_startup_if_the_clipboard_is_empty_then_no_item_should_be_displayed()
        {
            StartQuartermaster();

            Quartermaster.Item.ShouldMatch(NoItem);
        }

        [Fact]
        public void On_startup_if_the_clipboard_has_non_poe_content_then_no_item_should_be_displayed()
        {
            Clipboard.SetData(DataFormats.Text, Auto.Create<string>());

            StartQuartermaster();

            Quartermaster.Item.ShouldMatch(NoItem);
        }

        [Fact]
        public void On_startup_if_the_clipboard_has_an_iron_ring_then_an_iron_ring_should_be_displayed()
        {
            ClipboardMonitor.CurrentText.Returns(Rings.IronRing);

            StartQuartermaster();

            Quartermaster.Item.ShouldMatch(IronRingItem);
            _quartermasterViewModel.Item.ShouldMatch(IronRingItem);
        }
    }
}