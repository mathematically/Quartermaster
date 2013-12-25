using System.Windows.Media.Animation;
using FluentAssertions;
using Mathematically.Quartermaster.Domain.Items;
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
        [InlineData(ItemTextExamples.IronRing, IronRingName)]
        [InlineData(ItemTextExamples.SapphireRing, SapphireRingName)]
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
        [InlineData(ItemTextExamples.IronRing, ItemRarity.Normal)]
        [InlineData(ItemTextExamples.ThirstyRubyRingOfSuccess, ItemRarity.Magic)]
        public void Parser_parses_rarity_correctly(string itemText, ItemRarity rarity)
        {
            ParseTextWithSut(itemText);

            _sut.Rarity.Should().Be(rarity);
        }
    }
}