using Mathematically.Quartermaster.Domain.Mods;

namespace Mathematically.Quartermaster.Domain.Affixes
{
    public class ColdResistance : Affix
    {
        public ColdResistance()
        {
            Definition(AffixPosition.Suffix, "% to Cold Resistance", @"\d+", new[]
            {
                new AffixTier(AffixTierName.Inuit, 1, 6, 11),
                new AffixTier(AffixTierName.Seal, 14, 12, 17),
                new AffixTier(AffixTierName.Penguin, 26, 18, 23),
                new AffixTier(AffixTierName.Yeti, 38, 24, 29),
                new AffixTier(AffixTierName.Walrus, 50, 30, 35),
                new AffixTier(AffixTierName.Bear, 60, 36, 41),
                new AffixTier(AffixTierName.Ice, 72, 42, 45),
            });
        }
    }
}