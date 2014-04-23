using System;
using System.Linq;
using ExpectedObjects;
using FluentAssertions;
using Grean.Exude;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Tests.Examples;
using Xunit;
using Xunit.Extensions;

namespace Mathematically.Quartermaster.Tests.Specs
{
    [Trait("When an item is copied in game", "")]
    public class When_an_item_is_copied_in_game : QuartermasterStarted
    {
        [FirstClassTests]
        public static TestCase<When_an_item_is_copied_in_game>[] The_item_is_displayed_in_the_main_window()
        {
            // Note we don't need to test everything here as the example items test the actual parsing.

            var testCases = new[]
            {
                new
                {
                    GameText = Weapons.DriftwoodWandText,
                    ExpectedItem = Weapons.DriftwoodWand,
                    DPS = Weapons.DriftwoodWandDPS,
                },
                new
                {
                    GameText = Weapons.DriftwoodMaulText,
                    ExpectedItem = Weapons.DriftwoodMaul,
                    DPS = Weapons.DriftwoodMaulDPS,
                },
                new
                {
                    GameText = Weapons.HeavyShortBowText,
                    ExpectedItem = Weapons.HeavyShortBow,
                    DPS = Weapons.HeavyShortBowDPS,
                },
                new
                {
                    GameText = Weapons.HypnoticWingText,
                    ExpectedItem = Weapons.HypnoticWing,
                    DPS = Weapons.HypnoticWingDPS,
                },
                new
                {
                    GameText = Weapons.CorpseBlastText,
                    ExpectedItem = Weapons.CorpseBlast,
                    DPS = Weapons.CorpseBlastDPS,
                },
                new
                {
                    GameText = Weapons.CorpseBlastText,
                    ExpectedItem = Weapons.CorpseBlast,
                    DPS = Weapons.CorpseBlastDPS,
                },
                new
                {
                    GameText = Rings.IronRingText,
                    ExpectedItem = Rings.IronRing,
                    DPS = 0.0,
                },
                // Uniques!!!
//                new
//                {
//                    GameText = Rings.KaomsSignText,
//                    ExpectedItem = Rings.KaomsSign,
//                    DPS = 0.0,
//                },
                new
                {
                    GameText = Rings.SapphireRingText,
                    ExpectedItem = Rings.SapphireRing,
                    DPS = 0.0,
                },
                new
                {
                    GameText = Rings.ThirstyRubyRingOfSuccessText,
                    ExpectedItem = Rings.ThirstyRubyRingOfSuccess,
                    DPS = 0.0,
                },
            };

            return
                testCases.Select(
                        c => new TestCase<When_an_item_is_copied_in_game>(
                        expect => expect.Copying_game_text_into_clipboard_produces_correct_item(c.GameText, c.ExpectedItem, c.DPS))
                    ).ToArray();
        }

        private void Copying_game_text_into_clipboard_produces_correct_item(string gameItemText, PoeItem expectedItem,
            double dps)
        {
            Console.WriteLine(gameItemText);

            CopyIntoClipboard(gameItemText);

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