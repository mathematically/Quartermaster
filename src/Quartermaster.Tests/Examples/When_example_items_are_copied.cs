﻿using System.Linq;
using ExpectedObjects;
using Grean.Exude;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Domain.Parser;
using Xunit;

namespace Mathematically.Quartermaster.Tests.Examples
{
    [Trait("When example items are copied", "")]
    public class When_example_items_are_copied
    {
        [FirstClassTests]
        public static TestCase<When_example_items_are_copied>[] Items_are_parsed_correctly()
        {
            var testCases = new[]
            {
                new
                {
                    GameText = Amulets.HorrorMedallionText,
                    ExpectedItem = Amulets.HorrorMedallion
                },
                new
                {
                    GameText = Boots.OblivionTrailText,
                    ExpectedItem = Boots.OblivionTrail
                },
                new
                {
                    GameText = Boots.PandemoniumSoleText,
                    ExpectedItem = Boots.PandemoniumSole
                },
                new
                {
                    GameText = Rings.IronRingText,
                    ExpectedItem = Rings.IronRing
                },
                new
                {
                    GameText = Rings.SapphireRingText,
                    ExpectedItem = Rings.SapphireRing
                },
                new
                {
                    GameText = Rings.ThirstyRubyRingOfSuccessText,
                    ExpectedItem = Rings.ThirstyRubyRingOfSuccess
                },
                new
                {
                    GameText = Rings.StormTurnText,
                    ExpectedItem = Rings.StormTurn

                },
                new
                {
                    GameText = Rings.KaomsSignText,
                    ExpectedItem = Rings.KaomsSign
                },
                new
                {
                    GameText = Weapons.DriftwoodMaulText,
                    ExpectedItem = Weapons.DriftwoodMaul
                },
                new
                {
                    GameText = Weapons.DriftwoodWandText,
                    ExpectedItem = Weapons.DriftwoodWand
                },
                new
                {
                    GameText = Weapons.HeavyShortBowText,
                    ExpectedItem = Weapons.HeavyShortBow
                },
                new
                {
                    GameText = Weapons.CorpseBlastText,
                    ExpectedItem = Weapons.CorpseBlast
                },
            };

            return
                testCases.Select(
                    testData =>
                        new TestCase<When_example_items_are_copied>(
                            expect => expect.Item_parsed_correctly(testData.GameText, testData.ExpectedItem))).ToArray();
        }

        private void Item_parsed_correctly(string gameText, PoeItem expectedItem)
        {
            var itemParser = new PoeItemParser();
            var itemFactory = new PoeItemFactory(itemParser);

            var actualItem = itemFactory.CreateItem(gameText);
            actualItem.ShouldMatch(expectedItem.ToExpectedObject());
        }
    }
}