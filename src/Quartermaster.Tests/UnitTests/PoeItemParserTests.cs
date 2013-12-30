using System.Windows.Media.Animation;
using FluentAssertions;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Tests.ExampleItems;
using Mathematically.Quartermaster.Tests.Fixtures;
using NSubstitute;
using Xunit.Extensions;

namespace Mathematically.Quartermaster.Tests.UnitTests
{
    public class PoeItemParserTests : QuartermasterFixture
    {
        private PoeItemParser _sut;

        private void CreateSUT( )
        {
            _sut = new PoeItemParser();
        }

        // Name parsing is always the same so two tests is enough

        [Theory]
        [InlineData(Rings.IronRing, IronRingName)]
        [InlineData(Rings.SapphireRing, SapphireRingName)]
        public void Parser_parses_name_correctly(string itemText, string itemName)
        {
            ParseTextWithSut(itemText);

            _sut.Name.Should().Be(itemName);
        }

        private void ParseTextWithSut(string itemText)
        {
            CreateSUT();
            _sut.Parse(itemText);
        }

        // Parse one of each rarity

        [Theory]
        [InlineData(Rings.IronRing, ItemRarity.Normal)]
        [InlineData(Rings.ThirstyRubyRingOfSuccess, ItemRarity.Magic)]
        public void Parser_parses_rarity_correctly(string itemText, ItemRarity rarity)
        {
            ParseTextWithSut(itemText);

            _sut.Rarity.Should().Be(rarity);
        }

        // Item level always the same
        [Theory]
        [InlineData(Rings.IronRing, 4)]
        [InlineData(Rings.SapphireRing, 15)]
        public void Parser_parses_item_level_correctly(string itemText, int itemLevel)
        {
            ParseTextWithSut(itemText);

            _sut.ItemLevel.Should().Be(itemLevel);
        }
    }
}