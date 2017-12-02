using Mathematically.Quartermaster.Domain.Mods;

namespace Mathematically.Quartermaster.Domain.Affixes
{
    public class Life : Affix
    {
        public Life()
        {
            Definition("Base Max Life", AffixPosition.Prefix, " to maximum Life", @"\d+", new[]
            {
                new AffixTier(AffixTierName.Hale, 1, 3, 9),
                new AffixTier(AffixTierName.Healthy, 5, 10, 19),
                new AffixTier(AffixTierName.Sanguine, 11, 20, 29),
                new AffixTier(AffixTierName.HealthyCrafted, 15, 15, 24, MasterCrafted),
                new AffixTier(AffixTierName.StalwartCrafted, 15, 35, 44, MasterCrafted),
                new AffixTier(AffixTierName.Stalwart, 18, 30, 39),
                new AffixTier(AffixTierName.Stout, 24, 40, 49),
                new AffixTier(AffixTierName.SanguineCrafted, 25, 25, 34, MasterCrafted),
                new AffixTier(AffixTierName.StoutCrafted, 25, 45, 54, MasterCrafted),
                new AffixTier(AffixTierName.Robust, 30, 50, 59),
                new AffixTier(AffixTierName.RobustCrafted, 35, 55, 64, MasterCrafted),
                new AffixTier(AffixTierName.Rotund, 36, 60, 69),
                new AffixTier(AffixTierName.Virile, 44, 70, 79),
                new AffixTier(AffixTierName.Athletes, 54, 80, 89),
                new AffixTier(AffixTierName.Fecund, 64, 90, 99),
                new AffixTier(AffixTierName.Vigorous, 73, 100, 109),
                new AffixTier(AffixTierName.Rapturous, 81, 110, 119),
            });
        }
    }
}