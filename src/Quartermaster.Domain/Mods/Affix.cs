using System.Collections.Generic;
using System.Linq;

namespace Mathematically.Quartermaster.Domain.Mods
{
    /// <summary>
    /// An affix definition, that being the text and regex we need to find it in the game text
    /// and the set of AffixLevels defined in the game.
    /// </summary>
    public class Affix : IAffix
    {
        public string MatchText { get; private set; }
        public string ValueRegEx { get; private set; }

        private readonly List<AffixLevel> _levels = new List<AffixLevel>();

        protected void Definition(string matchText, string valueRegEx, IEnumerable<AffixLevel> levels)
        {
            MatchText = matchText;
            ValueRegEx = valueRegEx;

            _levels.AddRange(levels);
        }

        public IEnumerable<AffixLevel> Levels
        {
            get { return _levels; }
        }

        public AffixLevel this[int roll]
        {
            get { return Levels.Single(l => roll >= l.Min  && roll <= l.Max); }
        }
    }
}