using FluentAssertions;
using Mathematically.Quartermaster.Tests.ExampleItems;
using Mathematically.Quartermaster.Tests.Fixtures;
using Mathematically.Quartermaster.ViewModels;
using Xunit;
using Xunit.Extensions;

namespace Mathematically.Quartermaster.Tests.Specs
{
    public class HUDDisplayFeature : QuartermasterFixture
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
        [InlineData(Rings.IronRing, 0.0)]
        public void Copying_weapon_item_text_in_game_sets_the_HUD_DPS_correctly(string gameItemText, double dps)
        {
            StartQuartermaster();

            PasteIntoClipboard(gameItemText);

            _hudViewModel.Item.Damage.DPS.Should().Be(dps);
//            _hudViewModel.ShouldRaisePropertyChangeFor(x => x.Weapon);
        }

        [Fact]
        public void Copying_non_weapon_over_weapon_resets_dps_to_zero()
        {
            StartQuartermaster();
            PasteIntoClipboard(Weapons.DriftwoodWand);

            PasteIntoClipboard(Rings.IronRing);

            _hudViewModel.Item.Damage.DPS.Should().Be(0.0);
//            _hudViewModel.ShouldRaisePropertyChangeFor(x => x.Weapon);
        }
    }
}