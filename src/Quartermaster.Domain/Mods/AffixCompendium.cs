using System.Collections.Generic;
using Mathematically.Quartermaster.Domain.Affixes;

namespace Mathematically.Quartermaster.Domain.Mods
{
    public class AffixCompendium : IAffixCompendium
    {
        private static readonly Dictionary<AffixType, IAffix> Compendium = new Dictionary<AffixType, IAffix>
        {
            // Prefixes
            {AffixType.DamageScaling, new DamageScaling()},
            {AffixType.EvasionGlobal, new EvasionGlobal()},
            {AffixType.Life, new Life()},

            // Suffixes
            {AffixType.AttackSpeedGlobal, new AttackSpeedGlobal()},
            {AffixType.AttackSpeedLocal, new AttackSpeedLocal()},
            {AffixType.ColdResistance, new ColdResistance()},
            {AffixType.FireResistance, new FireResistance()},
            {AffixType.LightningResistance, new LightningResistance()},
            {AffixType.ChaosResistance, new ChaosResistance()},
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