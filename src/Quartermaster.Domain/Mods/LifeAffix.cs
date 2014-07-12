using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Domain.Mods
{
    public class LifeAffix : Affix
    {
        public LifeAffix()
        {
            Definition(" to maximum Life", @"\d+", new []
            {
                new AffixLevel(AffixLevelName.Healthy, 1, 10, 19),
                new AffixLevel(AffixLevelName.Sanguine, 11, 20, 29),
                new AffixLevel(AffixLevelName.Stalwart, 18, 30, 39),
                new AffixLevel(AffixLevelName.Stout, 24, 40, 49),
                new AffixLevel(AffixLevelName.Robust, 30, 50, 59),
                new AffixLevel(AffixLevelName.Rotund, 36, 60, 69),
                new AffixLevel(AffixLevelName.Virile, 44, 70, 79),
                new AffixLevel(AffixLevelName.Athletes, 54, 80, 89),
                new AffixLevel(AffixLevelName.Fecund, 64, 90, 99),
                new AffixLevel(AffixLevelName.Vigorous, 73, 100, 109),
            });
        }
    }
}