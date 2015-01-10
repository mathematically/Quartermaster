using System;
using System.Collections.Generic;
using ExpectedObjects;
using Grean.Exude;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Domain.Mods;
using Mathematically.Quartermaster.Domain.Parser;
using Xunit;

namespace Mathematically.Quartermaster.Tests.Examples
{
    [Trait("When example items are copied", "")]
    public class When_example_items_are_copied
    {
        [FirstClassTests]
        public static IEnumerable<ITestCase> Items_are_parsed_correctly()
        {
            yield return new TestCase(_ => Item_parsed_correctly(Amulets.HorrorMedallionText, Amulets.HorrorMedallion));
            yield return new TestCase(_ => Item_parsed_correctly(Boots.OblivionTrailText, Boots.OblivionTrail));
            yield return new TestCase(_ => Item_parsed_correctly(Boots.PandemoniumSoleText, Boots.PandemoniumSole));
            yield return new TestCase(_ => Item_parsed_correctly(Rings.IronRingText, Rings.IronRing));
//                new
//                {
//                    GameText = Rings.SapphireRingText,
//                    ExpectedItem = Rings.SapphireRing
//                },
//                new
//                {
//                    GameText = Rings.ThirstyRubyRingOfSuccessText,
//                    ExpectedItem = Rings.ThirstyRubyRingOfSuccess
//                },
//                new
//                {
//                    GameText = Rings.StormTurnText,
//                    ExpectedItem = Rings.StormTurn
//                },
//                new
//                {
//                    GameText = Rings.KaomsSignText,
//                    ExpectedItem = Rings.KaomsSign
//                },
//                new
//                {
//                    GameText = Weapons.DriftwoodMaulText,
//                    ExpectedItem = Weapons.DriftwoodMaul
//                },
//                new
//                {
//                    GameText = Weapons.DriftwoodWandText,
//                    ExpectedItem = Weapons.DriftwoodWand
//                },
//                new
//                {
//                    GameText = Weapons.HeavyShortBowText,
//                    ExpectedItem = Weapons.HeavyShortBow
//                },
//                new
//                {
//                    GameText = Weapons.CorpseBlastText,
//                    ExpectedItem = Weapons.CorpseBlast
//                },
        }
//        [FirstClassTests]
//        public static TestCase<When_example_items_are_copied>[] Items_are_parsed_correctly()
//        {
//            var testCases = new[]
//            {
//                new
//                {
//                    GameText = Amulets.HorrorMedallionText,
//                    ExpectedItem = Amulets.HorrorMedallion
//                },
//                new
//                {
//                    GameText = Boots.OblivionTrailText,
//                    ExpectedItem = Boots.OblivionTrail
//                },
//                new
//                {
//                    GameText = Boots.PandemoniumSoleText,
//                    ExpectedItem = Boots.PandemoniumSole
//                },
//                new
//                {
//                    GameText = Rings.IronRingText,
//                    ExpectedItem = Rings.IronRing
//                },
//                new
//                {
//                    GameText = Rings.SapphireRingText,
//                    ExpectedItem = Rings.SapphireRing
//                },
//                new
//                {
//                    GameText = Rings.ThirstyRubyRingOfSuccessText,
//                    ExpectedItem = Rings.ThirstyRubyRingOfSuccess
//                },
//                new
//                {
//                    GameText = Rings.StormTurnText,
//                    ExpectedItem = Rings.StormTurn
//                },
//                new
//                {
//                    GameText = Rings.KaomsSignText,
//                    ExpectedItem = Rings.KaomsSign
//                },
//                new
//                {
//                    GameText = Weapons.DriftwoodMaulText,
//                    ExpectedItem = Weapons.DriftwoodMaul
//                },
//                new
//                {
//                    GameText = Weapons.DriftwoodWandText,
//                    ExpectedItem = Weapons.DriftwoodWand
//                },
//                new
//                {
//                    GameText = Weapons.HeavyShortBowText,
//                    ExpectedItem = Weapons.HeavyShortBow
//                },
//                new
//                {
//                    GameText = Weapons.CorpseBlastText,
//                    ExpectedItem = Weapons.CorpseBlast
//                },
//            };
//
//            return
//                testCases.Select(
//                    testData =>
//                        new TestCase<When_example_items_are_copied>(
//                            expect => expect.Item_parsed_correctly(testData.GameText, testData.ExpectedItem))).ToArray();
//        }

        private static void Item_parsed_correctly(string gameText, PoeItem expectedItem)
        {
            Console.WriteLine(gameText);

            var compendium = new AffixCompendium();
            var lexicon = new ItemTypeLexicon();
            var parsers = new ModParsers(lexicon, compendium);
            var itemFactory = new PoeItemFactory(lexicon, parsers);
            var actualItem = itemFactory.CreateItem(gameText);
            actualItem.ShouldMatch(expectedItem.ToExpectedObject());
        }
    }
}