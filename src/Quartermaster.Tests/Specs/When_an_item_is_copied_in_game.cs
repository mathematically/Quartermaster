using System;
using ExpectedObjects;
using FluentAssertions;
using Mathematically.Quartermaster.Tests.Examples;
using Xunit;
using Xunit.Extensions;

namespace Mathematically.Quartermaster.Tests.Specs
{
    [Trait("When an item is copied in game", "")]
    public class When_an_item_is_copied_in_game : And_quartermaster_has_started
    {
        // Note we don't need to test everything here as the example items test the actual parsing.
        // This is just testing in a more integrated manner.
        [Theory]
        [InlineData("Corpse Blast", Weapons.CorpseBlastDPS)]
        [InlineData("Driftwood Maul", Weapons.DriftwoodMaulDPS)]
        [InlineData("Driftwood Wand", Weapons.DriftwoodWandDPS)]
        [InlineData("Heavy Short Bow", Weapons.HeavyShortBowDPS)]
        public void Copying_game_text_into_clipboard_produces_correct_weapon(string expectedItemName, double dps)
        {
            var expectedItem = ExampleItemReflectionHelper.GetItem(Weapons.Instance, expectedItemName);
            var gameText = ExampleItemReflectionHelper.GetItemText(Weapons.Instance, expectedItemName);

            Console.WriteLine(gameText);
            CopyIntoClipboard(gameText);

            Quartermaster.Item.ShouldMatch(expectedItem.ToExpectedObject());
            Quartermaster.Item.Damage.DPS.Should().Be(dps);

            QuartermasterViewModel.Item.ShouldMatch(expectedItem.ToExpectedObject());
            QuartermasterViewModel.ShouldRaisePropertyChangeFor(x => x.Item);
        }

        [Theory]
        [InlineData(Rings.IronRingText, false)]
        [InlineData(Weapons.DriftwoodMaulText, true)]
        public void DPS_should_only_be_set_for_weapons(string gameItemText, bool isWeapon)
        {
            CopyIntoClipboard(gameItemText);

            if (isWeapon)
                QuartermasterViewModel.Item.Damage.DPS.Should().NotBe(0.0);
            else
                QuartermasterViewModel.Item.Damage.DPS.Should().Be(0.0);

            QuartermasterViewModel.ShouldRaisePropertyChangeFor(x => x.Item);
        }
    }
}