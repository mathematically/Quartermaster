using System.Collections.Generic;

namespace Mathematically.Quartermaster.Domain.Mods
{
    public static class AffixCompendium
    {
        private static readonly Dictionary<AffixType, IAffix> Compendium = new Dictionary<AffixType, IAffix>
        {
            {AffixType.Life, new LifeAffix()},
            {AffixType.DamageScaling, new DamageScalingAffix()},
        };

        public static IEnumerable<IAffix> Affixes
        {
            get { return Compendium.Values; }
        }

        public static IAffix GetAffix(AffixType ofType)
        {
            return Compendium[ofType];
        }
    }
}