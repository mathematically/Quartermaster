using System;
using System.Linq;

namespace Mathematically.Quartermaster.Domain.Items
{
    public class PoeItemParser : IPoeItemParser
    {
        // These line positions are always the same
        private const int RarityLineIndex = 0;
        private const int NameLineIndex = 1;

        private static readonly int RarityMarkerLength = PoeText.RARITY_MARKER.Length;
        private static readonly int ItemLevelMarkerLength = PoeText.ITEMLEVEL_MARKER.Length;

        private string[] _textLines;

        public string Name { get; private set; }
        public ItemRarity Rarity { get; private set; }
        public int ItemLevel { get; private set; }
        public bool IsWeapon { get; private set; }

        public void Parse(string itemText)
        {
            _textLines = itemText.Split(Constants.AllPlatformLineSplitChars, StringSplitOptions.None);

            Rarity = ParseRarity();
            Name = _textLines[NameLineIndex];
            ItemLevel = ParseItemLevel();
            IsWeapon = DetectWeapon();
        }

        private ItemRarity ParseRarity( )
        {
            string rawLineText = _textLines[RarityLineIndex];
            var rarityText = ExtractMarkerValue(rawLineText, RarityMarkerLength);

            return (ItemRarity) Enum.Parse(typeof (ItemRarity), rarityText);
        }

        private string ExtractMarkerValue(string rawLineText, int markerLength)
        {
            return rawLineText.Substring(markerLength, rawLineText.Length - markerLength);
        }

        private int ParseItemLevel( )
        {
            string rawLineText = _textLines.First(line => line.Contains(PoeText.ITEMLEVEL_MARKER));
            return ExtractNumericMarkerValue(rawLineText, ItemLevelMarkerLength);
        }

        private int ExtractNumericMarkerValue(string rawLineText, int markerLength)
        {
            string valueText = ExtractMarkerValue(rawLineText, markerLength);
            return int.Parse(valueText);
        }

        private bool DetectWeapon()
        {
            return _textLines.FirstOrDefault(line => line.Contains(PoeText.WEAPON_MARKER)) != null;
        }
    }
}