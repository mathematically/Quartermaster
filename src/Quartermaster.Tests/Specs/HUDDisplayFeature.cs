using FluentAssertions;
using Mathematically.Quartermaster.Tests.Examples;
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
        [InlineData(Rings.IronRingText, 4)]
        [InlineData(Rings.SapphireRingText, 15)]
        [InlineData(Weapons.DriftwoodMaulText, 4)]
        [InlineData(Weapons.DriftwoodWandText, 4)]
        public void Copying_item_text_in_game_sets_the_HUD_item_level_correctly(string gameItemText, int itemLevel)
        {
            StartQuartermaster();

            CopyIntoClipboard(gameItemText);

            _hudViewModel.Item.ItemLevel.Should().Be(itemLevel);
            _hudViewModel.ShouldRaisePropertyChangeFor(x => x.Item);
        }

        [Theory]
        [InlineData(Weapons.DriftwoodWandText, Weapons.DriftwoodWandDPS)]
        [InlineData(Weapons.DriftwoodMaulText, Weapons.DriftwoodMaulDPS)]
        [InlineData(Rings.IronRingText, 0.0)]
        public void Copying_weapon_item_text_in_game_sets_the_HUD_DPS_correctly(string gameItemText, double dps)
        {
            StartQuartermaster();

            CopyIntoClipboard(gameItemText);

            _hudViewModel.Item.Damage.DPS.Should().Be(dps);
        }

        [Theory]
        [InlineData(Weapons.HypnoticWingText, Weapons.HypnoticWingDPS, Weapons.HypnoticWingPhysicalDPS, Weapons.HypnoticWingElementalDPS)]
        [InlineData(Weapons.CorpseBlastText, Weapons.CorpseBlastDPS, Weapons.CorpseBlastPhysicalDPS, Weapons.CorpseBlastElementalDPS)]
        [InlineData(Rings.IronRingText, 0.0, 0.0, 0.0)]
        public void HUD_displays_dps_breakdown_numbers_for_elemental_weapons(string gameItemText, double dps, double physicalDps, double elementalDps)
        {
            StartQuartermaster();

            CopyIntoClipboard(gameItemText);

            _hudViewModel.Item.Damage.DPS.Should().Be(dps);
            _hudViewModel.Item.Damage.ElementalDPS.Should().Be(elementalDps);
            _hudViewModel.Item.Damage.PhysicalDPS.Should().Be(physicalDps);
        }

        [Fact]
        public void Copying_non_weapon_over_weapon_resets_dps_to_zero()
        {
            StartQuartermaster();
            CopyIntoClipboard(Weapons.HypnoticWingText);

            CopyIntoClipboard(Rings.IronRingText);

            _hudViewModel.Item.Damage.DPS.Should().Be(0.0);
            _hudViewModel.Item.Damage.PhysicalDPS.Should().Be(0.0);
            _hudViewModel.Item.Damage.ElementalDPS.Should().Be(0.0);
        }

        [Fact]
        public void Copying_non_elemental_weapon_over_elemental_weapon_resets_dps_to_zero()
        {
            StartQuartermaster();
            CopyIntoClipboard(Weapons.HypnoticWingText);

            CopyIntoClipboard(Weapons.DriftwoodWandText);

            _hudViewModel.Item.Damage.DPS.Should().Be(Weapons.DriftwoodWandDPS);
            _hudViewModel.Item.Damage.PhysicalDPS.Should().Be(Weapons.DriftwoodWandDPS);
            _hudViewModel.Item.Damage.ElementalDPS.Should().Be(0.0);
        }
    }
}