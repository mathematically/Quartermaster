using ExpectedObjects;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Tests.Fixtures;
using NSubstitute;
using Xunit.Extensions;

namespace Mathematically.Quartermaster.Tests.UnitTests
{
    public class PoeItemFactoryTests : FakeQuartermasterFixture
    {
        private PoeItemFactory _sut;

        private void CreateSUT( )
        {
            _sut = new PoeItemFactory(ItemParser);
        }

        [Theory]
        [InlineData(ItemTextExamples.IronRing, IronRingName, ItemRarity.Normal)]
        [InlineData(ItemTextExamples.SapphireRing, SapphireRingName, ItemRarity.Normal)]
        [InlineData(ItemTextExamples.ThirstyRubyRingOfSuccess, ThirstyRubyRingOfSuccessName, ItemRarity.Magic)]
        public void Item_factory_generates_items_from_item_text(string itemText, string itemName, ItemRarity rarity)
        {
            var expectedItem = GetExpectedItem(itemName);
            ConfigureFakeParserWith(itemText, itemName, rarity);

            CreateSUT();
            var item = _sut.CreateItem(itemText);

            item.ShouldMatch(expectedItem);
        }
    }
}