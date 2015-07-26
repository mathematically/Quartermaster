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

        public bool TryParse(int itemLevel, BaseItemType baseItemType, string modText, out IItemMod parsedMod)
        {
            if (IsOnThisItem(modText, baseItemType))
            {
                var roll = GetAffixRoll(modText);
                parsedMod = new ItemMod(_affix, roll.Item1, roll.Item2, itemLevel);
                return true;
            }

            parsedMod = null;
            return false;
        }

        private bool IsOnThisItem(string modText, BaseItemType baseItemType)
        {
            var isOnThisItem = modText.Contains(_affix.MatchText);

            // Some mods look the same in the tooltip but differ in terms of what base type they can appear on.
            // Most commonly local and global versions of the same mod on weapons and non-weapons.
            var isValidOnBaseType = _itemLexicon.IsValidOnBaseType(_affix, baseItemType);

            return isOnThisItem && isValidOnBaseType;
        }

        private Tuple<string, int> GetAffixRoll(string modText)
        {
            var match = Regex.Match(modText, _affix.ValueRegEx);

            if (!match.Success)
            {
                throw new ArgumentException(string.Format("Could not match {0} in {1}", _affix.MatchText, modText));
            }

            return new Tuple<string, int>(modText, Convert.ToInt32(match.Value));
        }

    }
}