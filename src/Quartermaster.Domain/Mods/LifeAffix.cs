using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Domain.Mods
{
    public class LifeAffix : Affix
    {
        public LifeAffix()
        {
            Definition(" to maximum Life", @"\d+", new []
            {
                new AffixLevel(AffixName.Healthy, 1, 10, 19),
                new AffixLevel(AffixName.Sanguine, 11, 20, 29),
                new AffixLevel(AffixName.Stalwart, 18, 30, 39),
                new AffixLevel(AffixName.Stout, 24, 40, 49),
                new AffixLevel(AffixName.Robust, 30, 50, 59),
                new AffixLevel(AffixName.Rotund, 36, 60, 69),
                new AffixLevel(AffixName.Virile, 44, 70, 79),
                new AffixLevel(AffixName.Athletes, 54, 80, 89),
                new AffixLevel(AffixName.Fecund, 64, 90, 99),
                new AffixLevel(AffixName.Vigorous, 73, 100, 109),
            });
        }
    }
}