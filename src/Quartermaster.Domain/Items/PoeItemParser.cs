using System;

namespace Mathematically.Quartermaster.Domain.Items
{
    public class PoeItemParser : IPoeItemParser
    {
        private const int RarityLineIndex = 0;
        private const int NameLineIndex = 1;

        private static readonly int RarityMarkerLength = PoeText.RARITY_MARKER.Length;

        private string[] _textLines;

        public string Name { get; private set; }
        public ItemRarity Rarity { get; private set; }

        public void Parse(string itemText)
        {
            _textLines = itemText.Split(PoeText.AllPlatformLineSplitChars, StringSplitOptions.None);

            Rarity = ParseRarity();
            Name = _textLines[NameLineIndex];
        }

        private ItemRarity ParseRarity( )
        {
            string rawLineText = _textLines[RarityLineIndex];
            string rarityText = rawLineText.Substring(RarityMarkerLength, rawLineText.Length - RarityMarkerLength);

            return (ItemRarity) Enum.Parse(typeof (ItemRarity), rarityText);
        }
    }
}