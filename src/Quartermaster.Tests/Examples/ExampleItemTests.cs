using System;
using System.Diagnostics;
using System.Linq;
using ExpectedObjects;
using Grean.Exude;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Domain.Parser;

namespace Mathematically.Quartermaster.Tests.Examples
{
    public class ExampleItemTests
    {
        [FirstClassTests]
        public static TestCase<ExampleItemTests>[] RunTests()
        {
            var testCases = new[]
            {
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
                    GameText = Rings.KaomsSignText,
                    ExpectedItem = Rings.KaomsSign
                },
            };

            return testCases.Select(t => new TestCase<ExampleItemTests>(s => s.Item_can_be_parsed_from_game_text(t.GameText, t.ExpectedItem))).ToArray();
        }

        private void Item_can_be_parsed_from_game_text(string gameText, PoeItem expectedItem)
        {
            try
            {
                var itemParser = new PoeItemParser();
                var itemFactory = new PoeItemFactory(itemParser);

                var actualItem = itemFactory.CreateItem(gameText);
                actualItem.ShouldMatch(expectedItem.ToExpectedObject());

            }
            catch (Exception)
            {
                Debug.WriteLine(gameText);    
                throw;
            }
        }
    }
}
