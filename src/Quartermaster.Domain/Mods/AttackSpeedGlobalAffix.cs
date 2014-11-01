namespace Mathematically.Quartermaster.Domain.Mods
{
    public class AttackSpeedGlobalAffix : Affix
    {
        public AttackSpeedGlobalAffix()
        {
            Definition(AffixPosition.Suffix, "% increased Attack Speed", @"\d+", new[]
            {
                new AffixTier(AffixTierName.OfSkill, 1, 5, 7),
                new AffixTier(AffixTierName.OfEase, 11, 8, 10), 
                new AffixTier(AffixTierName.OfMastery, 22, 11, 13), 
                new AffixTier(AffixTierName.OfGrandmastery, 76, 14, 16), 
            });
        }
    }
}