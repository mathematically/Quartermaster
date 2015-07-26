using System.Collections.Generic;
using System.Linq;

namespace Mathematically.Quartermaster.Domain.Mods
{
    /// <summary>
    ///     An affix definition, that being the text and regex we need to find it in the game text
    ///     and the set of AffixLevels defined by the game.
    /// </summary>
    public class Affix : IAffix
    {
        public const bool Natural = !MasterCrafted;
        public const bool MasterCrafted = true;

        public string AffixName { get; private set; }
        public AffixPosition Position { get; private set; }
        public string MatchText { get; private set; }
        public string ValueRegEx { get; private set; }

        private readonly List<AffixTier> _levels = new List<AffixTier>();
        //private readonly List<AffixTier> _craftedLevels = new List<AffixTier>();

        protected void Definition(string affixName, AffixPosition position, string matchText, string valueRegEx,
            IEnumerable<AffixTier> tiers)
        {
            AffixName = affixName;
            Position = position;
            MatchText = matchText;
            ValueRegEx = valueRegEx;

            // Currently ignoring crafted levels as there is no way to tell
            // which is crafted from the tooltiup text (other than they are
            // last).  Not sure it matters though; you know it's crafted and 
            // what really matters is where is sits relative to a natural mod.
            _levels.AddRange(tiers.Where(l => l.MasterCrafted == false));
            //_craftedLevels.AddRange(tiers.Where(l => l.MasterCrafted));
        }

        public IEnumerable<AffixTier> Levels
        {
            get { return _levels; }
        }

        public AffixTier this[int roll]
        {
            get { return Levels.Single(l => roll >= l.Min && roll <= l.Max); }
        }
    }
}