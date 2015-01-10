using System;
using System.Collections.Generic;
using System.Linq;
using ExpectedObjects;
using Grean.Exude;
using Mathematically.Quartermaster.Domain.Affixes;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Domain.Mods;
using Xunit;

namespace Mathematically.Quartermaster.Tests.UnitTests
{
    [Trait("Affix parsing", "")]
    public class AffixParsingTests : ItemParserTestBase
    {
        private const string FakeRingText = @"Rarity: Magic
Fake Ring
--------
Requirements:
Level: {0}
--------
Itemlevel: {1}
--------
{2}";

        [FirstClassTests]
        public IEnumerable<ITestCase> Life_mods_parse_correctly()
        {
            yield return new TestCase(_ => ParseLife("+40 to maximum Life", AffixTierName.Stout, value: 40, itemLevel: 24, rollQuality: 10, modOffset: 0, whenTesting: "lower bound"));
            yield return new TestCase(_ => ParseLife("+44 to maximum Life", AffixTierName.Stout, value: 44, itemLevel: 24, rollQuality: 50, modOffset: 0, whenTesting: "middle rollValue #1"));
            yield return new TestCase(_ => ParseLife("+47 to maximum Life", AffixTierName.Stout, value: 47, itemLevel: 24, rollQuality: 80, modOffset: 0, whenTesting: "middle rollValue #2"));
            yield return new TestCase(_ => ParseLife("+49 to maximum Life", AffixTierName.Stout, value: 49, itemLevel: 24, rollQuality: 100, modOffset: 0, whenTesting: "upper bound"));
                
            yield return new TestCase(_ => ParseLife("+40 to maximum Life", AffixTierName.Stout, value: 40, itemLevel: 30, rollQuality: 10, modOffset: -1, whenTesting: "mod offset - 1"));
        }

        private void ParseLife(string affixText, AffixTierName affixName, int value, int itemLevel, int rollQuality, int modOffset, string whenTesting)
        {
            var fakeItemText = string.Format(FakeRingText, itemLevel, itemLevel, affixText);
            Console.WriteLine("Tesing {0} on affix {1} with fake item text {2}", whenTesting, affixName, fakeItemText);

            ParseTextWithSut(fakeItemText);

            var affix = SUT.Mods.First();

            var expectedAffix = new ItemMod(new Life(), affixText, value, itemLevel).ToExpectedObject();
            affix.ShouldMatch(expectedAffix);
        }
    }
}