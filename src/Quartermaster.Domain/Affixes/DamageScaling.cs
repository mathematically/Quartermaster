using Mathematically.Quartermaster.Domain.Mods;

namespace Mathematically.Quartermaster.Domain.Affixes
{
    public class DamageScaling : Affix
    {
        public DamageScaling()
        {
            Definition("Local Physical Dmg+%", AffixPosition.Prefix, "% increased Physical Damage", @"\d+", new[]
            {
                new AffixTier(AffixTierName.Heavy, 1, 40, 49),
                new AffixTier(AffixTierName.Serrated, 11, 50, 64),
                new AffixTier(AffixTierName.Wicked, 23, 65, 84),
                new AffixTier(AffixTierName.Vicious, 35, 85, 109),
                new AffixTier(AffixTierName.Bloodthirsty, 46, 110, 134),
                new AffixTier(AffixTierName.Cruel, 60, 135, 154),
                new AffixTier(AffixTierName.Tyrannical, 73, 155, 169),
                new AffixTier(AffixTierName.Merciless, 83, 170, 179),
            });
        }
    }
}