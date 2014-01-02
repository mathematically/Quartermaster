using System;
using System.Linq;

namespace Mathematically.Quartermaster.Domain.Items
{
    public class PoeItemParser : IPoeItemParser
    {
        // These line positions are always the same
        private const int RarityLineIndex = 0;
        private const int NameLineIndex = 1;

        private static readonly int RarityLabelLength = PoeText.RARITY_LABEL.Length;
        private static readonly int ItemLevelLabelLength = PoeText.ITEMLEVEL_LABEL.Length;
        private static readonly int PhysicalDamageLabelLength = PoeText.PHYSICAL_DAMAGE_LABEL.Length;
        private static readonly int AttackSpeedLabelLength = PoeText.ATTACKS_PER_SECOND_LABEL.Length;

        private string[] _textLines;

        public string Name { get; private set; }
        public ItemRarity Rarity { get; private set; }
        public int ItemLevel { get; private set; }
        public bool IsWeapon { get; private set; }
        public int MinPhysicalDamage { get; private set; }
        public int MaxPhysicalDamage { get; private set; }
        public double AttackSpeed { get; private set; }

        public void Parse(string itemText)
        {
            _textLines = itemText.Split(Constants.AllPlatformLineSplitChars, StringSplitOptions.None);

            Rarity = ParseRarity();
            Name = _textLines[NameLineIndex];
            ItemLevel = ParseItemLevel();

            WeaponParse();
        }

        private void WeaponParse( )
        {
            IsWeapon = DetectWeapon();

            if (IsWeapon)
            {
                ParseWeaponStats();
            }
        }

        private ItemRarity ParseRarity( )
        {
            string rawLineText = _textLines[RarityLineIndex];
            var rarityText = ExtractValueText(rawLineText, RarityLabelLength);

            return (ItemRarity) Enum.Parse(typeof (ItemRarity), rarityText);
        }

        private string ExtractValueText(string rawLineText, int markerLength)
        {
            return rawLineText.Substring(markerLength, rawLineText.Length - markerLength);
        }

        private int ParseItemLevel()
        {
            string rawLineText = _textLines.First(line => line.Contains(PoeText.ITEMLEVEL_LABEL));
            return ExtractIntegerValue(rawLineText, ItemLevelLabelLength);
        }

        private int ExtractIntegerValue(string rawLineText, int markerLength)
        {
            string valueText = ExtractValueText(rawLineText, markerLength);

            return int.Parse(valueText);
        }

        private bool DetectWeapon()
        {
            return _textLines.FirstOrDefault(line => line.Contains(PoeText.WEAPON_MARKER)) != null;
        }

        private void ParseWeaponStats()
        {
            ParsePhysicalDamage();
            ParseAttackSpeed();
        }

        private void ParsePhysicalDamage( )
        {
            var rawLineText = _textLines.FirstOrDefault(line => line.Contains(PoeText.PHYSICAL_DAMAGE_LABEL));
            var range = ExtractIntegerRange(rawLineText, PhysicalDamageLabelLength);

            MinPhysicalDamage = range.Item1;
            MaxPhysicalDamage = range.Item2;
        }

        private void ParseAttackSpeed()
        {
            var rawLineText = _textLines.FirstOrDefault(line => line.Contains(PoeText.ATTACKS_PER_SECOND_LABEL));

            AttackSpeed = ExtractDoubleValue(rawLineText, AttackSpeedLabelLength);
        }

        private Tuple<int, int> ExtractIntegerRange(string rawLineText, int markerLength)
        {
            string valueText = ExtractValueText(rawLineText, markerLength);
            var values = valueText.Split(new[] { PoeText.RANGE_DIVIDER }, StringSplitOptions.None);

            return new Tuple<int, int>(int.Parse(values[0]), int.Parse(values[1]));
        }

        private double ExtractDoubleValue(string rawLineText, int markerLength)
        {
            string valueText = ExtractValueText(rawLineText, markerLength);

            return double.Parse(valueText);
        }
    }
}