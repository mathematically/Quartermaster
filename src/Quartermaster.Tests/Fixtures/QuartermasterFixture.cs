using ExpectedObjects;
using Mathematically.Quartermaster.Domain.Items;
using Ploeh.AutoFixture;

namespace Mathematically.Quartermaster.Tests.Fixtures
{
    public class QuartermasterFixture
    {
        protected readonly Fixture Auto = new Fixture();

        protected readonly ExpectedObject ExpectedIronRingItem = new PoeItem(

            "Iron Ring",
            ItemRarity.Normal

            ).ToExpectedObject();

        protected readonly ExpectedObject NoItem = new EmptyPoeItem().ToExpectedObject();
    }
}