using System;
using System.Linq;
using Mathematically.Quartermaster.Domain;
using Mathematically.Quartermaster.Domain.Parser;

namespace Quartermaster.Infrastructure
{
    public class ItemTextChecker : IItemTextChecker
    {
        public bool LooksLikeGameText(string itemText)
        {
            if (string.IsNullOrEmpty(itemText))
                return false;

            if (!itemText.Contains(TooltipText.RARITY_LABEL))
                return false;

            var lines = itemText.Split(Constants.AllPlatformLineSplitChars, StringSplitOptions.None);
            var hasAtLeastTwoSectionDividers = lines.Count(line => line == TooltipText.SECTION_DIVIDER) >= 2;

            return hasAtLeastTwoSectionDividers;
        }
    }
}