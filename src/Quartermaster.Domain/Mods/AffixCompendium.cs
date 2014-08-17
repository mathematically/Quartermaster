using System.Collections.Generic;

namespace Mathematically.Quartermaster.Domain.Mods
{
    public class AffixCompendium: IAffixCompendium
    {
        private static readonly Dictionary<AffixType, IAffix> Compendium = new Dictionary<AffixType, IAffix>
        {
            {AffixType.Life, new LifeAffix()},
            {AffixType.DamageScaling, new DamageScalingAffix()},
        };

        public IEnumerable<IAffix> Affixes
        {
            get { return Compendium.Values; }
        }

        public IAffix GetAffix(AffixType ofType)
        {
            return Compendium[ofType];
        }
    }
}