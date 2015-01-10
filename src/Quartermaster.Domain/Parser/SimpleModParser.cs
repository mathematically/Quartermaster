using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Domain.Mods;

namespace Mathematically.Quartermaster.Domain.Parser
{
    /// <summary>
    /// Parses generic mods that can always be matched using the match text and regex on the associated affix.
    /// </summary>
    public class SimpleModParser : IModParser
    {
        private readonly IItemLexicon _itemLexicon;
        private readonly IAffix _affix;

        public SimpleModParser(IItemLexicon itemLexicon, IAffix affix)
        {
            _itemLexicon = itemLexicon;
            _affix = affix;
        }

        public IModParseResult TryParse(int itemLevel, BaseItemType baseItemType, IEnumerable<string> modTextLines)
        {
            var lines = modTextLines.ToList();

            if (IsOnThisItem(lines, baseItemType))
            {
                var roll = GetAffixRoll(lines);
                lines.Remove(roll.Item1);

                return new ModParseResult(lines, new[] { new ItemMod(_affix, roll.Item1, roll.Item2, itemLevel) });
            }

            return new ModParseResult(lines, Enumerable.Empty<IItemMod>());
        }

        private bool IsOnThisItem(IEnumerable<string> modTextLines, BaseItemType baseItemType)
        {
            var isOnThisItem = modTextLines.FirstOrDefault(line => line.Contains(_affix.MatchText)) != null;

            // Some mods look the same in the tooltip but differ in terms of what base type they can appear on.
            // Most commonly local and global versions of the same mod on weapons and non-weapons.
            var isValidOnBaseType = _itemLexicon.IsValidOnBaseType(_affix, baseItemType);

            return isOnThisItem && isValidOnBaseType;
        }

        private Tuple<string, int> GetAffixRoll(IEnumerable<string> modTextLines)
        {
            var rollText = modTextLines.First(line => line.Contains(_affix.MatchText));
            var match = Regex.Match(rollText, _affix.ValueRegEx);

            if (!match.Success)
            {
                throw new ArgumentException(string.Format("Could not match {0} in {1}", _affix.MatchText, rollText));
            }

            return new Tuple<string, int>(rollText, Convert.ToInt32(match.Value));
        }
    }
}