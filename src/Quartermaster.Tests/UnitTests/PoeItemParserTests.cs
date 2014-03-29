using FluentAssertions;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Domain.Parser;
using Mathematically.Quartermaster.Tests.Examples;
using Xunit;
using Xunit.Extensions;

namespace Mathematically.Quartermaster.Tests.UnitTests
{
    public class PoeItemParserTests
    {
        private PoeItemParser _sut;

        private void CreateSUT( )
        {
            _sut = new PoeItemParser();
        }

        // Name parsing is always the same so two tests is enough

        [Theory]
        [InlineData(Rings.IronRingText, Rings.IronRingName)]
        [InlineData(Rings.SapphireRingText, Rings.SapphireRingName)]
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
        [InlineData(Rings.IronRingText, ItemRarity.Normal)]
        [InlineData(Rings.ThirstyRubyRingOfSuccessText, ItemRarity.Magic)]
        [InlineData(Rings.StormTurnText, ItemRarity.Rare)]
        [InlineData(Rings.KaomsSignText, ItemRarity.Unique)]
        public void Parser_parses_rarity_correctly(string itemText, ItemRarity rarity)
        {
            ParseTextWithSut(itemText);

            _sut.Rarity.Should().Be(rarity);
        }

        // Item level always the same

        [Theory]
        [InlineData(Rings.IronRingText, 4)]
        [InlineData(Rings.SapphireRingText, 15)]
        public void Parser_parses_item_level_correctly(string itemText, int itemLevel)
        {
            ParseTextWithSut(itemText);

            _sut.ItemLevel.Should().Be(itemLevel);
        }

        [Theory]
        [InlineData(Weapons.DriftwoodWandText, true)]
        [InlineData(Weapons.DriftwoodMaulText, true)]
        [InlineData(Rings.IronRingText, false)]
        public void Parser_detects_weapons_correctly(string itemText, bool isWeapon)
        {
            ParseTextWithSut(itemText);

            _sut.IsWeapon.Should().Be(isWeapon);
        }

        // All weapons have physical damage, non-weapons should be zero
        // todo this is not true.  There are weapons without physical damage (at least one unique, maybe more).

        [Theory]
        [InlineData(Weapons.DriftwoodWandText, 4, 7)]
        [InlineData(Weapons.DriftwoodMaulText, 12, 19)]
        [InlineData(Rings.IronRingText, 0, 0)]
        public void Parser_detects_physical_damage_correctly(string itemText, int minPhysicalDamage, int maxPhysicalDamage)
        {
            ParseTextWithSut(itemText);

            _sut.Damage.MinPhysical.Should().Be(minPhysicalDamage);
            _sut.Damage.MaxPhysical.Should().Be(maxPhysicalDamage);
        }

        [Fact]
        public void Physical_damage_parse_works_for_augmented_items( )
        {
            ParseTextWithSut(Weapons.HeavyShortBowText);

            _sut.Damage.MinPhysical.Should().Be(5);
            _sut.Damage.MaxPhysical.Should().Be(14);
        }

        // Attack speed exists for all weapons.
        [Theory]
        [InlineData(Weapons.DriftwoodWandText, 1.30)]
        [InlineData(Weapons.DriftwoodMaulText, 1.10)]
        [InlineData(Rings.IronRingText, 0.0)]
        public void Parser_detects_attack_speed_correctly(string itemText, double attackSpeed)
        {
            ParseTextWithSut(itemText);

            _sut.AttackSpeed.Should().Be(attackSpeed);
        }

        // Elemental damage
        [Theory]
        [InlineData(Weapons.HypnoticWingText, 13, 38, 7, 13, 0, 0, 3, 32)]
        [InlineData(Weapons.CorpseBlastText, 19, 58, 27, 46, 7, 12, 4, 53)]
        public void Parser_detects_elemental_damage_correctly(string itemText,
            int minPhysicalDamage, int maxPhysicalDamage,
            int minFireDamage, int maxFireDamage,
            int minColdDamage, int maxColdDamage,
            int minLightningDamage, int maxLightningDamage
            )
        {
            ParseTextWithSut(itemText);

            _sut.Damage.MinFireDamage.Should().Be(minFireDamage);
            _sut.Damage.MaxFireDamage.Should().Be(maxFireDamage);
            _sut.Damage.MinColdDamage.Should().Be(minColdDamage);
            _sut.Damage.MaxColdDamage.Should().Be(maxColdDamage);
            _sut.Damage.MinLightningDamage.Should().Be(minLightningDamage);
            _sut.Damage.MaxLightningDamage.Should().Be(maxLightningDamage);

            _sut.Damage.MinPhysical.Should().Be(minPhysicalDamage);
            _sut.Damage.MaxPhysical.Should().Be(maxPhysicalDamage);
        }
    }
}