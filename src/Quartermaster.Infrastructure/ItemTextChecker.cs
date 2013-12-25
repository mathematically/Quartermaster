using System;
using System.Linq;
using Mathematically.Quartermaster.Domain.Items;

namespace Quartermaster.Infrastructure
{
    public class ItemTextChecker : IItemTextChecker
    {
        // Check diff line endings in case we get some windows test in their somehow.
        private readonly string[] _allPlatformLineSplitChars = { "\r\n", "\n" };

        private const string RARITY_MARKER = "Rarity: ";
        private const string SECTION_DIVIDER = "--------";

        public bool LooksLikeGameText(string itemText)
        {
            if (string.IsNullOrEmpty(itemText))
                return false;

            if (!itemText.Contains(RARITY_MARKER))
                return false;

            var lines = itemText.Split(_allPlatformLineSplitChars, StringSplitOptions.None);
            var hasAtLeastTwoSectionDividers = lines.Count(line => line == SECTION_DIVIDER) >= 2;

            return hasAtLeastTwoSectionDividers;
        }
    }
}