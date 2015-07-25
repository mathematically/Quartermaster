using Mathematically.Quartermaster.Domain.Mods;

namespace Mathematically.Quartermaster.Domain.Affixes
{
    public class DamageScaling : Affix
    {
        public DamageScaling()
        {
            Definition("Local Physical Dmg+%", AffixPosition.Prefix, "% increased Physical Damage", @"\d+", new[]
            {
                new AffixTier(AffixTierName.Heavy, 1, 20, 49),
                new AffixTier(AffixTierName.Serrated, 11, 50, 69),
                new AffixTier(AffixTierName.Wicked, 23, 70, 89),
                new AffixTier(AffixTierName.Vicious, 35, 90, 109),
                new AffixTier(AffixTierName.Bloodthirsty, 46, 110, 129),
                new AffixTier(AffixTierName.Cruel, 60, 130, 149),
                new AffixTier(AffixTierName.Tyrannical, 73, 150, 169)
            });
        }
    }
}