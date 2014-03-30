using System.Collections;
using FluentAssertions;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Tests.Examples;
using Xunit;
using Xunit.Extensions;

namespace Mathematically.Quartermaster.Tests.UnitTests
{
    [Trait("Item parser", "")]
    public class PoeItemParserTests : ItemParserTestBase
    {
        // Name parsing is always the same so two tests is enough

        [Theory]
        [InlineData(Rings.IronRingText, Rings.IronRingName)]
        [InlineData(Rings.SapphireRingText, Rings.SapphireRingName)]
        public void Parses_name_correctly(string itemText, string itemName)
        {
            ParseTextWithSut(itemText);

            SUT.Name.Should().Be(itemName);
        }

        // Parse one of each rarity

        [Theory]
        [InlineData(Rings.IronRingText, ItemRarity.Normal)]
        [InlineData(Rings.ThirstyRubyRingOfSuccessText, ItemRarity.Magic)]
        [InlineData(Rings.StormTurnText, ItemRarity.Rare)]
        [InlineData(Rings.KaomsSignText, ItemRarity.Unique)]
        public void Parses_rarity_correctly(string itemText, ItemRarity rarity)
        {
            ParseTextWithSut(itemText);

            SUT.Rarity.Should().Be(rarity);
        }

        // Item level always the same

        [Theory]
        [InlineData(Rings.IronRingText, 4)]
        [InlineData(Rings.SapphireRingText, 15)]
        public void Parses_item_level_correctly(string itemText, int itemLevel)
        {
            ParseTextWithSut(itemText);

            SUT.ItemLevel.Should().Be(itemLevel);
        }

        [Theory]
        [InlineData(Weapons.DriftwoodWandText, true)]
        [InlineData(Weapons.DriftwoodMaulText, true)]
        [InlineData(Rings.IronRingText, false)]
        public void Detects_weapons_correctly(string itemText, bool isWeapon)
        {
            ParseTextWithSut(itemText);

            SUT.IsWeapon.Should().Be(isWeapon);
        }

        // All weapons have physical damage, non-weapons should be zero
        // todo this is not true.  There are weapons without physical damage (at least one unique, maybe more).

        [Theory]
        [InlineData(Weapons.DriftwoodWandText, 4, 7)]
        [InlineData(Weapons.DriftwoodMaulText, 12, 19)]
        [InlineData(Rings.IronRingText, 0, 0)]
        public void Detects_physical_damage_correctly(string itemText, int minPhysicalDamage, int maxPhysicalDamage)
        {
            ParseTextWithSut(itemText);

            SUT.Damage.MinPhysical.Should().Be(minPhysicalDamage);
            SUT.Damage.MaxPhysical.Should().Be(maxPhysicalDamage);
        }

        [Fact]
        public void Physical_damage_parse_works_for_augmented_items( )
        {
            ParseTextWithSut(Weapons.HeavyShortBowText);

            SUT.Damage.MinPhysical.Should().Be(5);
            SUT.Damage.MaxPhysical.Should().Be(14);
        }

        // Attack speed exists for all weapons.
        [Theory]
        [InlineData(Weapons.DriftwoodWandText, 1.30)]
        [InlineData(Weapons.DriftwoodMaulText, 1.10)]
        [InlineData(Rings.IronRingText, 0.0)]
        public void Detects_attack_speed_correctly(string itemText, double attackSpeed)
        {
            ParseTextWithSut(itemText);

            SUT.Damage.AttackSpeed.Should().Be(attackSpeed);
        }

        // Elemental damage
        [Theory]
        [InlineData(Weapons.HypnoticWingText, 13, 38, 7, 13, 0, 0, 3, 32)]
        [InlineData(Weapons.CorpseBlastText, 19, 58, 27, 46, 7, 12, 4, 53)]
        public void Detects_elemental_damage_correctly(string itemText,
            int minPhysicalDamage, int maxPhysicalDamage,
            int minFireDamage, int maxFireDamage,
            int minColdDamage, int maxColdDamage,
            int minLightningDamage, int maxLightningDamage
            )
        {
            ParseTextWithSut(itemText);

            SUT.Damage.MinFireDamage.Should().Be(minFireDamage);
            SUT.Damage.MaxFireDamage.Should().Be(maxFireDamage);
            SUT.Damage.MinColdDamage.Should().Be(minColdDamage);
            SUT.Damage.MaxColdDamage.Should().Be(maxColdDamage);
            SUT.Damage.MinLightningDamage.Should().Be(minLightningDamage);
            SUT.Damage.MaxLightningDamage.Should().Be(maxLightningDamage);

            SUT.Damage.MinPhysical.Should().Be(minPhysicalDamage);
            SUT.Damage.MaxPhysical.Should().Be(maxPhysicalDamage);
        }
    }

}