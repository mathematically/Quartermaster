using ExpectedObjects;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Tests.ExampleItems;
using Mathematically.Quartermaster.Tests.Fixtures;
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
        [InlineData(Rings.IronRing, IronRingName, ItemRarity.Normal, 4)]
        [InlineData(Rings.SapphireRing, SapphireRingName, ItemRarity.Normal, 15)]
        [InlineData(Rings.ThirstyRubyRingOfSuccess, ThirstyRubyRingOfSuccessName, ItemRarity.Magic, 16)]
        public void Item_factory_generates_items_from_item_text(string itemText, string itemName, ItemRarity rarity, int itemLevel)
        {
            var expectedItem = GetExpectedItem(itemName);
            ConfigureFakeParserWith(itemText, itemName, rarity, itemLevel);
            CreateSUT();

            var item = _sut.CreateItem(itemText);

            item.ShouldMatch(expectedItem);
        }
    }
}