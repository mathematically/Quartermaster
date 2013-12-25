using System;
using FluentAssertions;
using Mathematically.Quartermaster.Tests.Fixtures;
using Ploeh.AutoFixture.Xunit;
using Quartermaster.Infrastructure;
using Xunit.Extensions;

namespace Mathematically.Quartermaster.Tests.UnitTests
{
    public class ItemTextAnalyserTests
    {
        [Theory]
        [InlineAutoData("")]
        [InlineAutoData("any text")]
        [InlineAutoData("Rarity: " + "\r\n" + "--------")] // This example very close to the loose heuristic we use so should fail
        public void Analyser_ignores_bad_text(string testText, ItemTextChecker sut)
        {
            sut.LooksLikeGameText(testText).Should().BeFalse();

        }

        [Theory]
        [InlineAutoData(ItemTextExamples.IronRing)]
        [InlineAutoData(ItemTextExamples.IronRing)]
        [InlineAutoData("Rarity: " + "\r\n" + "--------" + "\r\n" + "--------")] // This is just the sanity check text so this should pass.
        [InlineAutoData("Rarity: " + "\n" + "--------" + "\n" + "--------")] // Do it with linux and windows line endings just in case.
        public void Analyser_allows_good_text(string testText, ItemTextChecker sut)
        {
            sut.LooksLikeGameText(testText).Should().BeTrue();
        }
    }
}