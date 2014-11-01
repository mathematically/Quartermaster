namespace Mathematically.Quartermaster.Domain.Mods
{
    public class AttackSpeedLocalAffix : Affix
    {
        public AttackSpeedLocalAffix()
        {
            Definition(AffixPosition.Suffix, "% increased Attack Speed", @"\d+", new[]
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