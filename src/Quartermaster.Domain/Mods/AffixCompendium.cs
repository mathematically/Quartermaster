using System.Collections.Generic;

namespace Mathematically.Quartermaster.Domain.Mods
{
    public class AffixCompendium : IAffixCompendium
    {
        private static readonly Dictionary<AffixType, IAffix> Compendium = new Dictionary<AffixType, IAffix>
        {
            // Prefixes
            {AffixType.DamageScaling, new DamageScalingAffix()},
            {AffixType.Life, new LifeAffix()},

            // Suffixes
            {AffixType.AttackSpeedGlobal, new AttackSpeedGlobalAffix()},
            {AffixType.AttackSpeedLocal, new AttackSpeedLocalAffix()},
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