using Mathematically.Quartermaster.Domain.Mods;

namespace Mathematically.Quartermaster.Domain.Affixes
{
    public class ChaosResistance : Affix
    {
        public ChaosResistance()
        {
            Definition("Base Chaos Dmg Resistance %", AffixPosition.Suffix, "% to Chaos Resistance", @"\d+", new[]
            {
                new AffixTier(AffixTierName.Lost, 16, 5, 10),
                new AffixTier(AffixTierName.Banishment, 30, 11, 15),
                new AffixTier(AffixTierName.Eviction, 44, 16, 20),
                new AffixTier(AffixTierName.Expulsion, 56, 21, 25),
                new AffixTier(AffixTierName.Exile, 65, 26, 30),
            });
        }
    }
}