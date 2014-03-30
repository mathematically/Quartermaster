using Mathematically.Quartermaster.Domain.Parser;

namespace Mathematically.Quartermaster.Tests.UnitTests
{
    public class ItemParserTestBase
    {
        protected PoeItemParser SUT;

        private void CreateSUT(string itemText)
        {
            SUT = new PoeItemParser(itemText);
        }

        protected void ParseTextWithSut(string itemText)
        {
            CreateSUT(itemText);
            SUT.Parse();
        }
    }
}