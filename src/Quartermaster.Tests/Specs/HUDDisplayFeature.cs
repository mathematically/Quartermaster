using FluentAssertions;
using Mathematically.Quartermaster.Tests.ExampleItems;
using Mathematically.Quartermaster.ViewModels;
using Xunit.Extensions;

namespace Mathematically.Quartermaster.Tests.Specs
{
    public class HUDDisplayFeature : QuartermasterFeature
    {
        private HUDViewModel _hudViewModel;

        protected override void StartQuartermaster()
        {
            base.StartQuartermaster();

            _hudViewModel = new HUDViewModel(Quartermaster);
            _hudViewModel.MonitorEvents();
        }

        [Theory]
        [InlineData(Rings.IronRing, 4)]
        [InlineData(Rings.SapphireRing, 15)]
        [InlineData(Weapons.DriftwoodMaul, 4)]
        [InlineData(Weapons.DriftwoodWand, 4)]
        public void Copying_item_text_in_game_sets_the_HUD_item_level_correctly(string gameItemText, int itemLevel)
        {
            StartQuartermaster();

            PasteIntoClipboard(gameItemText);

            _hudViewModel.Item.ItemLevel.Should().Be(itemLevel);
            _hudViewModel.ShouldRaisePropertyChangeFor(x => x.Item);
        }

        [Theory]
        [InlineData(Weapons.DriftwoodWand, Weapons.DriftwoodWandDPS)]
        [InlineData(Weapons.DriftwoodMaul, Weapons.DriftwoodMaulDPS)]
        public void Copying_weapon_item_text_in_game_sets_the_HUD_DPS_correctly(string gameItemText, double dps)
        {
            StartQuartermaster();

            PasteIntoClipboard(gameItemText);

            _hudViewModel.Weapon.DPS.Should().Be(dps);
        }
    }
}