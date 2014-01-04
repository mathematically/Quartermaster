using Mathematically.Quartermaster.Domain.Items;
using NSubstitute;

namespace Mathematically.Quartermaster.Tests.Fixtures
{
    public class FakeQuartermasterFixture: TestItemsFixture
    {
        protected readonly IItemTextSource ItemTextSource = Substitute.For<IItemTextSource>();
        protected readonly IPoeItemFactory ItemTextFactory = Substitute.For<IPoeItemFactory>();
        protected readonly IPoeItemParser ItemParser = Substitute.For<IPoeItemParser>();

        protected void ConfigureFakeParserWith(string itemText, string itemName, ItemRarity rarity, int itemLevel)
        {
            ItemParser.When(itemParser => itemParser.Parse(Arg.Is<string>(s => s == itemText)))
                .Do(callInfo =>
                {
                    ItemParser.Name.Returns(itemName);
                    ItemParser.Rarity.Returns(rarity);
                    ItemParser.ItemLevel.Returns(itemLevel);

                });
        }

        protected void ConfigureFakeWeaponParserWith(string itemText, string itemName, ItemRarity rarity, int itemLevel)
        {
            ItemParser.When(itemParser => itemParser.Parse(Arg.Is<string>(s => s == itemText)))
                .Do(callInfo =>
                {
                    ItemParser.Name.Returns(itemName);
                    ItemParser.Rarity.Returns(rarity);
                    ItemParser.ItemLevel.Returns(itemLevel);
                    ItemParser.IsWeapon.Returns(true);

                });
        }

        protected void ConfigureFakeFactoryFor(string itemName)
        {
            ItemTextFactory.CreateItem(Arg.Any<string>()).Returns(GetItem(itemName));
        }


        protected void ConfigureFakeItemTextSourceWith(string itemText)
        {
            ItemTextSource.ItemText.Returns(itemText);
            ItemTextSource.HasItemText().Returns(true);
        }
    }
}