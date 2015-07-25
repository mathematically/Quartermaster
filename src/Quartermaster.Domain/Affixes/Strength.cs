using Mathematically.Quartermaster.Domain.Mods;

namespace Mathematically.Quartermaster.Domain.Affixes
{
    public class Strength : Affix
    {
        public Strength()
        {
            Definition("Additional Strength", AffixPosition.Suffix, " to Strength", @"\d+", new[]
            {
                new AffixTier(AffixTierName.Brute, 1, 8, 12),
                new AffixTier(AffixTierName.Wrestler, 11, 13, 17),
                new AffixTier(AffixTierName.Bear, 22, 18, 22),
                new AffixTier(AffixTierName.Lion, 33, 23, 27),
                new AffixTier(AffixTierName.Gorilla, 44, 28, 32),
                new AffixTier(AffixTierName.Goliath, 55, 33, 37),
                new AffixTier(AffixTierName.Leviathan, 66, 38, 42),
                new AffixTier(AffixTierName.Titan, 74, 43, 50),
            });
        }
    }
}