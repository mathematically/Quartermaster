namespace Mathematically.Quartermaster.Domain.Mods
{
    public class DamageScalingAffix : Affix
    {
        public DamageScalingAffix()
        {
            Definition(AffixPosition.Prefix, "% increased Physical Damage", @"\d+", new[]
            {
                new AffixLevel(AffixLevelName.Heavy, 1, 20, 49),
                new AffixLevel(AffixLevelName.Serrated, 11, 50, 69),
                new AffixLevel(AffixLevelName.Wicked, 23, 70, 89),
                new AffixLevel(AffixLevelName.Vicious, 35, 90, 109),
                new AffixLevel(AffixLevelName.Bloodthirsty, 46, 110, 129),
                new AffixLevel(AffixLevelName.Cruel, 60, 130, 149),
                new AffixLevel(AffixLevelName.Tyrannical, 73, 150, 169),
            });
        }
    }
}