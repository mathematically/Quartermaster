using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Domain.Parser
{
    public class ModsParser : PoeTextValueExtractor, IItemModData
    {
        private readonly GameText _gameText;
        private readonly List<Affix> _affixes = new List<Affix>();

        private List<int> ModLevels = new List<int> {1, 11, 18, 24, 30, 36, 44, 54, 64, 73};

        public ModsParser(GameText gameText)
        {
            _gameText = gameText;
        }

        public void Parse(int itemLevel)
        {
            var lifeModText = _gameText.OptionalLineWith("to maximum Life");

            if (lifeModText != null)
            {
                var match = Regex.Match(lifeModText, @"\d+");

                if (match.Success)
                {
                    var modValue = Convert.ToInt32(match.Value);
                    var rollQuality = 100 - ((49 - modValue)*10);

                    var bestLevelThisItem = ModLevels.Last(l => l <= itemLevel);
                    var levelThisMod = ModLevels.Last(l => l <= 24);

                    var best = ModLevels.IndexOf(bestLevelThisItem);
                    var actual = ModLevels.IndexOf(levelThisMod);

                    var levelOffset = actual - best;

                    _affixes.Add(new Affix(AffixName.Stout, lifeModText, modValue, rollQuality, levelOffset));
                }
            }
        }

        public IEnumerable<Affix> Affixes
        {
            get { return _affixes; }
        }
    }
}