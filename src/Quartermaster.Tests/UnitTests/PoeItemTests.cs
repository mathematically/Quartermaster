using FluentAssertions;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Tests.ExampleItems;
using Mathematically.Quartermaster.Tests.Fixtures;
using Ploeh.AutoFixture;
using Xunit.Extensions;

namespace Mathematically.Quartermaster.Tests.UnitTests
{
    public class PoeItemTests : FakeQuartermasterFixture
    {
        private PoeItem _sut;

        [Theory]
        [InlineData(Weapons.DriftwoodWand, 4, 7, 1.30, 1.95)]
        [InlineData(Weapons.DriftwoodMaul, 12, 19, 1.1, 3.85)]
        [InlineData(Weapons.DriftwoodMaul, 12, 19, 1.1, 3.85)]
        [InlineData(Weapons.HeavyShortBow, 5, 14, 1.55, 6.98)]
        public void Physical_only_weapons_calculate_dps_correctly(string itemText, int minPhysicalDamage, int maxPhysicalDamage, double attackSpeed, double dps)
        {
            _sut = new PoeItem(Auto.Create<string>(), Auto.Create<ItemRarity>(), Auto.Create<int>(), minPhysicalDamage, maxPhysicalDamage, attackSpeed);

            _sut.Damage.DPS.Should().Be(dps);
        }

        [Theory]
        [InlineData(Weapons.DriftwoodWand, 
            4, 7, 1.30, 1.95,   // Physical range and attack speed and expected DPS
            0, 0, 0, 0, 0, 0,   // Elemental ranges
            0.0,                // Elemental DPS
            1.95                // Total DPS
            )]      
        [InlineData(Weapons.HypnoticWing, 
            13, 38, 1.55, 19.38, 
            7, 13, 0, 0, 3, 32, 
            27.12, 
            46.5)]
        [InlineData(Weapons.CorpseBlast, 
            19, 58, 1.55, 30.22, 
            27, 46, 7, 12, 4, 53,
            56.58, 86.8)]
        public void Elemental_weapon_items_calculate_total_dps_correctly(string itemText, 
            int minPhysicalDamage, int maxPhysicalDamage, double attackSpeed, double physicalDPS,
            int minFireDamage, int maxFireDamage, int minColdDamage, int maxColdDamage, int minLightningDamage, int maxLightningDamage, double elementalDPS, 
            double totalDPS)
        {
            _sut = new PoeItem(Auto.Create<string>(), Auto.Create<ItemRarity>(), Auto.Create<int>(), minPhysicalDamage, maxPhysicalDamage, attackSpeed, minFireDamage,
                maxFireDamage, minColdDamage, maxColdDamage, minLightningDamage, maxLightningDamage);

            _sut.Damage.DPS.Should().Be(totalDPS);
            _sut.Damage.PhysicalDPS.Should().Be(physicalDPS);
            _sut.Damage.ElementalDPS.Should().Be(elementalDPS);
        }

        [Theory]
        [InlineData(Weapons.HypnoticWing, 13, 38, 1.55, 46.50, 7, 13, 0, 0, 3, 32)]
        [InlineData(Weapons.CorpseBlast, 19, 58, 1.55, 86.80, 27, 46, 7, 12, 4, 53)]
        public void Weapon_items_calculate_total_dps_correctly(string itemText, int minPhysicalDamage, int maxPhysicalDamage, double attackSpeed, double dps,
            int minFireDamage, int maxFireDamage, int minColdDamage, int maxColdDamage, int minLightningDamage, int maxLightningDamage)
        {
            _sut = new PoeItem(Auto.Create<string>(), Auto.Create<ItemRarity>(), Auto.Create<int>(), minPhysicalDamage, maxPhysicalDamage, attackSpeed, minFireDamage,
                maxFireDamage, minColdDamage, maxColdDamage, minLightningDamage, maxLightningDamage);

            _sut.Damage.DPS.Should().Be(dps);
        }
    }
}