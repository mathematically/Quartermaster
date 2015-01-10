using Mathematically.Quartermaster.Domain.Mods;

namespace Mathematically.Quartermaster.Domain.Affixes
{
    public class FireResistance : Affix
    {
        public FireResistance()
        {
            Definition(AffixPosition.Suffix, "% to Fire Resistance", @"\d+", new[]
            {
                new AffixTier(AffixTierName.Whelping, 1, 6, 11),
                new AffixTier(AffixTierName.Salamander, 14, 12, 17),
                new AffixTier(AffixTierName.Drake, 26, 18, 23),
                new AffixTier(AffixTierName.Kiln, 38, 24, 29),
                new AffixTier(AffixTierName.Furnace, 50, 30, 35),
                new AffixTier(AffixTierName.Volcano, 60, 36, 41),
                new AffixTier(AffixTierName.Magma, 72, 42, 45),
            });
        }
    }
}