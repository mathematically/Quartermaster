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
        public string AffixName { get; private set; }
        public AffixPosition Position { get; private set; }
        public string MatchText { get; private set; }
        public string ValueRegEx { get; private set; }

        private readonly List<AffixTier> _levels = new List<AffixTier>();

        protected void Definition(string affixName, AffixPosition position, string matchText, string valueRegEx,
            IEnumerable<AffixTier> levels)
        {
            AffixName = affixName;
            Position = position;
            MatchText = matchText;
            ValueRegEx = valueRegEx;

            _levels.AddRange(levels);
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