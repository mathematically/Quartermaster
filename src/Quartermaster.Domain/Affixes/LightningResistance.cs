using Mathematically.Quartermaster.Domain.Mods;

namespace Mathematically.Quartermaster.Domain.Affixes
{
    public class LightningResistance : Affix
    {
        public LightningResistance()
        {
            Definition(AffixPosition.Suffix, "% to Lightning Resistance", @"\d+", new[]
            {
                new AffixTier(AffixTierName.Cloud, 1, 6, 11),
                new AffixTier(AffixTierName.Squall, 14, 12, 17),
                new AffixTier(AffixTierName.Storm, 26, 18, 23),
                new AffixTier(AffixTierName.Thunderhead, 38, 24, 29),
                new AffixTier(AffixTierName.Tempest, 50, 30, 35),
                new AffixTier(AffixTierName.Maelstrom, 60, 36, 41),
                new AffixTier(AffixTierName.Lightning, 72, 42, 45),
            });
        }
    }
}