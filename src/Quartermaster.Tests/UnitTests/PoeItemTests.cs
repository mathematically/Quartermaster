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
        public void Weapon_items_calculate_dps_on_creation(string itemText, int minPhysicalDamage, int maxPhysicalDamage, double attackSpeed, double dps)
        {
            _sut = new PoeItem(Auto.Create<string>(), Auto.Create<ItemRarity>(), Auto.Create<int>(), minPhysicalDamage, maxPhysicalDamage, attackSpeed);

            _sut.DPS.Should().Be(dps);           
        }
    }
}