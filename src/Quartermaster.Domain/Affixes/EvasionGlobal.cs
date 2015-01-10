using Mathematically.Quartermaster.Domain.Mods;

namespace Mathematically.Quartermaster.Domain.Affixes
{
    public class EvasionGlobal : Affix
    {
        public EvasionGlobal()
        {
            Definition(AffixPosition.Suffix, "% increased Evasion", @"\d+", new[]
            {
                new AffixTier(AffixTierName.Agile, 1, 2, 4),
                new AffixTier(AffixTierName.Shades, 3, 8, 10), 
                new AffixTier(AffixTierName.Dancers, 18, 11, 13), 
                new AffixTier(AffixTierName.Ghosts, 19, 14, 16), 
            });
        }
    }
}