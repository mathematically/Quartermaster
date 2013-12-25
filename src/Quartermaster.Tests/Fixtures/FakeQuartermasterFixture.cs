using Mathematically.Quartermaster.Domain.Items;
using NSubstitute;

namespace Mathematically.Quartermaster.Tests.Fixtures
{
    public class FakeQuartermasterFixture: QuartermasterFixture
    {
        protected readonly IItemTextSource ItemTextSource = Substitute.For<IItemTextSource>();
        protected readonly IPoeItemFactory ItemTextFactory = Substitute.For<IPoeItemFactory>();
        protected readonly IPoeItemParser ItemParser = Substitute.For<IPoeItemParser>();

        protected void ConfigureFakeParserWith(string itemText, string itemName, ItemRarity rarity)
        {
            ItemParser.When(itemParser => itemParser.Parse(Arg.Is<string>(s => s == itemText)))
                .Do(callInfo =>
                {
                    ItemParser.Name.Returns(itemName);
                    ItemParser.Rarity.Returns(rarity);

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