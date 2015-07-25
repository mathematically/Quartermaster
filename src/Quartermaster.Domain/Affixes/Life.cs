using Mathematically.Quartermaster.Domain.Mods;

namespace Mathematically.Quartermaster.Domain.Affixes
{
    public class Life : Affix
    {
        public Life()
        {
            Definition("Base Max Life", AffixPosition.Prefix, " to maximum Life", @"\d+", new[]
            {
                new AffixTier(AffixTierName.Healthy, 1, 10, 19),
                new AffixTier(AffixTierName.Sanguine, 11, 20, 29),
                new AffixTier(AffixTierName.Stalwart, 18, 30, 39),
                new AffixTier(AffixTierName.Stout, 24, 40, 49),
                new AffixTier(AffixTierName.Robust, 30, 50, 59),
                new AffixTier(AffixTierName.Rotund, 36, 60, 69),
                new AffixTier(AffixTierName.Virile, 44, 70, 79),
                new AffixTier(AffixTierName.Athletes, 54, 80, 89),
                new AffixTier(AffixTierName.Fecund, 64, 90, 99),
                new AffixTier(AffixTierName.Vigorous, 73, 100, 109)
            });
        }
    }
}