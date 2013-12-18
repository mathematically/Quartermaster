using ExpectedObjects;
using Mathematically.Quartermaster.Domain;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Tests.Fixtures;
using NSubstitute;
using Xunit;

namespace Mathematically.Quartermaster.Tests.UnitTests
{
    public class QuartermasterStoreTests : QuartermasterFixture
    {
        private readonly IItemTextSource _itemTextSource = Substitute.For<IItemTextSource>();

        [Fact]
        public void If_the_clipboard_has_an_item_quartermaster_will_load_that_item_at_startup()
        {
            _itemTextSource.ItemText.Returns(ItemTextExamples.IronRing);
            _itemTextSource.HasItemText().Returns(true);

            var sut = new QuartermasterStore(_itemTextSource);

            sut.Item.ShouldMatch(ExpectedIronRingItem);
        }
    }
}
