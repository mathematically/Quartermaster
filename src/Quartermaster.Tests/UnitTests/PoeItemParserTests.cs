using FluentAssertions;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Tests.ExampleItems;
using Mathematically.Quartermaster.Tests.Fixtures;
using Xunit.Extensions;

namespace Mathematically.Quartermaster.Tests.UnitTests
{
    public class PoeItemParserTests : QuartermasterFixture
    {
        private PoeItemParser _sut;

        private void CreateSUT( )
        {
            _sut = new PoeItemParser();
        }

        // Name parsing is always the same so two tests is enough

        [Theory]
        [InlineData(Rings.IronRing, IronRingName)]
        [InlineData(Rings.SapphireRing, SapphireRingName)]
        public void Parser_parses_name_correctly(string itemText, string itemName)
        {
            ParseTextWithSut(itemText);

            _sut.Name.Should().Be(itemName);
        }

        private void ParseTextWithSut(string itemText)
        {
            CreateSUT();
            _sut.Parse(itemText);
        }

        // Parse one of each rarity

        [Theory]
        [InlineData(Rings.IronRing, ItemRarity.Normal)]
        [InlineData(Rings.ThirstyRubyRingOfSuccess, ItemRarity.Magic)]
        public void Parser_parses_rarity_correctly(string itemText, ItemRarity rarity)
        {
            ParseTextWithSut(itemText);

            _sut.Rarity.Should().Be(rarity);
        }

        // Item level always the same

        [Theory]
        [InlineData(Rings.IronRing, 4)]
        [InlineData(Rings.SapphireRing, 15)]
        public void Parser_parses_item_level_correctly(string itemText, int itemLevel)
        {
            ParseTextWithSut(itemText);

            _sut.ItemLevel.Should().Be(itemLevel);
        }

        [Theory]
        [InlineData(Weapons.DriftwoodWand, true)]
        [InlineData(Weapons.DriftwoodMaul, true)]
        [InlineData(Rings.IronRing, false)]
        public void Parser_detects_weapons_correctly(string itemText, bool isWeapon)
        {
            ParseTextWithSut(itemText);

            _sut.IsWeapon.Should().Be(isWeapon);
        }

        // All weapons have physical damage, non-weapons should be zero

        [Theory]
        [InlineData(Weapons.DriftwoodWand, 4, 7)]
        [InlineData(Weapons.DriftwoodMaul, 12, 19)]
        [InlineData(Rings.IronRing, 0, 0)]
        public void Parser_detects_physical_damage_correctly(string itemText, int minPhysicalDamage, int maxPhysicalDamage)
        {
            ParseTextWithSut(itemText);

            _sut.MinPhysicalDamage.Should().Be(minPhysicalDamage);
            _sut.MaxPhysicalDamage.Should().Be(maxPhysicalDamage);
        }

        // Same for attack speed

        [Theory]
        [InlineData(Weapons.DriftwoodWand, 1.30)]
        [InlineData(Weapons.DriftwoodMaul, 1.10)]
        [InlineData(Rings.IronRing, 0)]
        public void Parser_detects_attack_speed_correctly(string itemText, double attackSpeed)
        {
            ParseTextWithSut(itemText);

            _sut.AttackSpeed.Should().Be(attackSpeed);
        }
    }
}