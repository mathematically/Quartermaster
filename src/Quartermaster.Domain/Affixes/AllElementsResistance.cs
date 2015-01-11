using Mathematically.Quartermaster.Domain.Mods;

namespace Mathematically.Quartermaster.Domain.Affixes
{
    public class AllElementsResistance : Affix
    {
        public AllElementsResistance()
        {
            Definition(AffixPosition.Suffix, "% to all Elemental Resistances", @"\d+", new[]
            {
                new AffixTier(AffixTierName.Crystal, 12, 3, 5),
                new AffixTier(AffixTierName.Prism, 24, 6, 8),
                new AffixTier(AffixTierName.Kaleidoscope, 36, 9, 11),
                new AffixTier(AffixTierName.Variegation, 48, 12, 14),
                new AffixTier(AffixTierName.Rainbow, 60, 15, 16),
            });
        }
    }
}