using Mathematically.Quartermaster.Domain.Mods;

namespace Mathematically.Quartermaster.Domain.Affixes
{
    public class AttackSpeedLocal : Affix
    {
        public AttackSpeedLocal()
        {
            Definition("Local Attack Speed +%", AffixPosition.Suffix, "% increased Attack Speed", @"\d+", new[]
            {
                new AffixTier(AffixTierName.OfSkill, 1, 6, 9),
                new AffixTier(AffixTierName.OfEase, 11, 5, 10), 
                new AffixTier(AffixTierName.OfMastery, 22, 11, 13), 
                new AffixTier(AffixTierName.OfRenown, 30, 14, 16), 
                new AffixTier(AffixTierName.OfAcclaim, 37, 17, 19), 
                new AffixTier(AffixTierName.OfFame, 45, 20, 22), 
                new AffixTier(AffixTierName.OfInfamy, 60, 23, 25), 
                new AffixTier(AffixTierName.OfCelebration, 77, 26, 27), 
            });
        }
    }
}