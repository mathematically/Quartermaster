using System;
using System.Reflection;
using ExpectedObjects;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Domain.Mods;
using Mathematically.Quartermaster.Domain.Parser;
using Xunit;
using Xunit.Extensions;

namespace Mathematically.Quartermaster.Tests.Examples
{
    [Trait("When example items are copied", "")]
    public class When_example_items_are_copied
    {
        [Theory]
        [InlineData("Corpse Blast")]
        [InlineData("Heavy Short Bow")]
        [InlineData("Driftwood Maul")]
        [InlineData("Driftwood Wand")]
        public void Weapons_are_parsed_correctly(string expectedItemName)
        {
            var expectedItem = ExampleItemReflectionHelper.GetItem(Weapons.Instance, expectedItemName);
            var gameText = ExampleItemReflectionHelper.GetItemText(Weapons.Instance, expectedItemName);

            DoParseTest(gameText, expectedItem);
        }

        [Theory]
        [InlineData("Horror Medallion")]
        public void Amulets_are_parsed_correctly(string expectedItemName)
        {
            var expectedItem = ExampleItemReflectionHelper.GetItem(Amulets.Instance, expectedItemName);
            var gameText = ExampleItemReflectionHelper.GetItemText(Amulets.Instance, expectedItemName);

            DoParseTest(gameText, expectedItem);
        }

        [Theory]
        [InlineData("Pandemonium Sole")]
        public void Boots_are_parsed_correctly(string expectedItemName)
        {
            var expectedItem = ExampleItemReflectionHelper.GetItem(Boots.Instance, expectedItemName);
            var gameText = ExampleItemReflectionHelper.GetItemText(Boots.Instance, expectedItemName);

            DoParseTest(gameText, expectedItem);
        }

        [Theory]
        [InlineData("Storm Turn")]
        [InlineData("Sapphire Ring")]
        [InlineData("Iron Ring")]
        [InlineData("Thirsty Ruby Ring Of Success")]
        public void Rings_are_parsed_correctly(string expectedItemName)
        {
            var expectedItem = ExampleItemReflectionHelper.GetItem(Rings.Instance, expectedItemName);
            var gameText = ExampleItemReflectionHelper.GetItemText(Rings.Instance, expectedItemName);

            DoParseTest(gameText, expectedItem);
        }

        private static void DoParseTest(string gameText, PoeItem expectedItem)
        {
            Console.WriteLine(gameText);

            var compendium = new AffixCompendium();
            var lexicon = new ItemTypeLexicon();
            var parsers = new ModParsers(lexicon, compendium);
            var itemFactory = new PoeItemFactory(lexicon, parsers);

            var actualItem = itemFactory.CreateItem(gameText);

            // Note that the mods on the expected object must be in the same order as the mods on the parsed item.
            // Which is actually determined by the order the parsers are run.  This is crap but not sure how to fix it right now.
            actualItem.ShouldMatch(expectedItem.ToExpectedObject());
        }
    }
}