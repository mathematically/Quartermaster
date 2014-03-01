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
        }

        [Theory]
        [InlineData(Weapons.HypnoticWing, Weapons.HypnoticWingDPS, Weapons.HypnoticWingPhysicalDPS, Weapons.HypnoticWingElementalDPS)]
        [InlineData(Weapons.CorpseBlast, Weapons.CorpseBlastDPS, Weapons.CorpseBlastPhysicalDPS, Weapons.CorpseBlastElementalDPS)]
        [InlineData(Rings.IronRing, 0.0, 0.0, 0.0)]
        public void HUD_displays_dps_breakdown_numbers_for_elemental_weapons(string gameItemText, double dps, double physicalDps, double elementalDps)
        {
            StartQuartermaster();

            PasteIntoClipboard(gameItemText);

            _hudViewModel.Item.Damage.DPS.Should().Be(dps);
            _hudViewModel.Item.Damage.ElementalDPS.Should().Be(elementalDps);
            _hudViewModel.Item.Damage.PhysicalDPS.Should().Be(physicalDps);
        }

        [Fact]
        public void Copying_non_weapon_over_weapon_resets_dps_to_zero()
        {
            StartQuartermaster();
            PasteIntoClipboard(Weapons.HypnoticWing);

            PasteIntoClipboard(Rings.IronRing);

            _hudViewModel.Item.Damage.DPS.Should().Be(0.0);
            _hudViewModel.Item.Damage.PhysicalDPS.Should().Be(0.0);
            _hudViewModel.Item.Damage.ElementalDPS.Should().Be(0.0);
        }

        [Fact]
        public void Copying_non_elemental_weapon_over_elemental_weapon_resets_dps_to_zero()
        {
            StartQuartermaster();
            PasteIntoClipboard(Weapons.HypnoticWing);

            PasteIntoClipboard(Weapons.DriftwoodWand);

            _hudViewModel.Item.Damage.DPS.Should().Be(Weapons.DriftwoodWandDPS);
            _hudViewModel.Item.Damage.PhysicalDPS.Should().Be(Weapons.DriftwoodWandDPS);
            _hudViewModel.Item.Damage.ElementalDPS.Should().Be(0.0);
        }
    }
}