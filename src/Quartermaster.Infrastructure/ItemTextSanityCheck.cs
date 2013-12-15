using System;
using System.Linq;
using Mathematically.Quartermaster.Domain.Items;

namespace Quartermaster.Infrastructure
{
    public class ItemTextSanityCheck : IItemTextSanityCheck
    {
        // Check diff line endings in case we get some windows test in their somehow.
        private readonly string[] _allPlatformLineSplitChars = { "\r\n", "\n" };

        private const string RARITY_MARKER = "Rarity: ";
        private const string SECTION_DIVIDER = "--------";

        public bool LooksLikeGameText(string text)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            if (!text.Contains(RARITY_MARKER))
                return false;

            var lines = text.Split(_allPlatformLineSplitChars, StringSplitOptions.None);
            return lines.Count(line => line == SECTION_DIVIDER) >= 2;
        }
    }
}