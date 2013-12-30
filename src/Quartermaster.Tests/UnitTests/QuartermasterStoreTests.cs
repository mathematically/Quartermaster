using ExpectedObjects;
using Mathematically.Quartermaster.Domain;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Tests.ExampleItems;
using Mathematically.Quartermaster.Tests.Fixtures;
using Xunit.Extensions;

namespace Mathematically.Quartermaster.Tests.UnitTests
{
    public class QuartermasterStoreTests : FakeQuartermasterFixture
    {
        // These tests have so much fakery they are not that useful and overlap with other, better tests.
        // So just do a couple.
        [Theory]
        [InlineData(Rings.IronRing, IronRingName, ItemRarity.Normal)]
        [InlineData(Rings.SapphireRing, SapphireRingName, ItemRarity.Normal)]
        public void If_the_clipboard_has_an_item_quartermaster_will_load_that_item_at_startup(string itemText, string itemName, ItemRarity rarity)
        {
            var expectedItem = GetExpectedItem(itemName);

            ConfigureFakeItemTextSourceWith(itemText);
            ConfigureFakeFactoryFor(itemName);

            var sut = new QuartermasterStore(ItemTextFactory, ItemTextSource);

            sut.Item.ShouldMatch(expectedItem);
        }
    }
}
