using FluentAssertions;
using Mathematically.Quartermaster.Tests.Fixtures;
using Mathematically.Quartermaster.ViewModels;
using Xunit.Extensions;

namespace Mathematically.Quartermaster.Tests.Specs
{
    public class HUDDisplayFeature : QuartermasterFeature
    {
        private HUDViewModel _HUDViewModel;

        protected override void StartQuartermaster()
        {
            base.StartQuartermaster();

            _HUDViewModel = new HUDViewModel(Quartermaster);
            _HUDViewModel.MonitorEvents();
        }

        [Theory]
        [InlineData(ItemTextExamples.IronRing, 4)]
        [InlineData(ItemTextExamples.SapphireRing, 15)]
        public void Copying_item_text_in_game_sets_the_HUD_item_level_correctly(string gameItemText, int itemLevel)
        {
            StartQuartermaster();

            PasteIntoClipboard(gameItemText);

            _HUDViewModel.Item.ItemLevel.Should().Be(itemLevel);
            _HUDViewModel.ShouldRaisePropertyChangeFor(x => x.Item);
        }
    }
}