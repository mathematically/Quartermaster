using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Domain.Mods;
using Mathematically.Quartermaster.Domain.Parser;

namespace Mathematically.Quartermaster.Tests.UnitTests
{
    public class ItemParserTestBase
    {
        protected PoeItemParser SUT;

        private void CreateSUT(string itemText)
        {
            var compendium = new AffixCompendium();
            var lexicon = new ItemTypeLexicon();
            var parsers = new ModParserCollection(lexicon, compendium);

            SUT = new PoeItemParser(lexicon, parsers, itemText);
        }

        protected void ParseTextWithSut(string itemText)
        {
            CreateSUT(itemText);
            SUT.Parse();
        }
    }
}