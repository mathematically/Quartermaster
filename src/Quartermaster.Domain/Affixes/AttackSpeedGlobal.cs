using Mathematically.Quartermaster.Domain.Mods;

namespace Mathematically.Quartermaster.Domain.Affixes
{
    public class AttackSpeedGlobal : Affix
    {
        public AttackSpeedGlobal()
        {
            Definition("Attack Speed +%", AffixPosition.Suffix, "% increased Attack Speed", @"\d+", new[]
            {
                new AffixTier(AffixTierName.OfSkill, 1, 5, 7),
                new AffixTier(AffixTierName.OfEase, 11, 8, 10), 
                new AffixTier(AffixTierName.OfMastery, 22, 11, 13), 
                new AffixTier(AffixTierName.OfGrandmastery, 76, 14, 16), 
            });
        }
    }
}