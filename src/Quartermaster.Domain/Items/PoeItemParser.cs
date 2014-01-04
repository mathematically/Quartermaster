using System;
using System.Linq;

namespace Mathematically.Quartermaster.Domain.Items
{
    public class PoeItemParser : IPoeItemParser
    {
        // These line positions are always the same
        private const int RarityLineIndex = 0;
        private const int NameLineIndex = 1;

        private string[] _textLines;
        private readonly ValueExtractor _extract = new ValueExtractor();

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
            var rarityText = _extract.TextFrom(_textLines[RarityLineIndex]);

            return (ItemRarity) Enum.Parse(typeof (ItemRarity), rarityText);
        }

        private int ParseItemLevel()
        {
            var line = FindLineWith(PoeText.ITEMLEVEL_LABEL);
            return _extract.IntegerFrom(line);
        }

        private string FindLineWith(string label)
        {
            return _textLines.First(line => line.Contains(label));
        }

        private string FindOptionalLineWith(string label)
        {
            return _textLines.FirstOrDefault(line => line.Contains(label));
        }

        private bool DetectWeapon()
        {
            return FindOptionalLineWith(PoeText.WEAPON_MARKER) != null;
        }

        private void ParseWeaponStats()
        {
            ParsePhysicalDamage();
            ParseAttackSpeed();
        }

        private void ParsePhysicalDamage( )
        {
            var line = FindOptionalLineWith(PoeText.PHYSICAL_DAMAGE_LABEL);

            if (String.IsNullOrEmpty(line))
            {
                MinPhysicalDamage = 0;
                MaxPhysicalDamage = 0;
            }
            else
            {
                var range = _extract.IntegerRangeFrom(line);

                MinPhysicalDamage = range.Item1;
                MaxPhysicalDamage = range.Item2;
            }
        }

        private void ParseAttackSpeed()
        {
            var line = FindOptionalLineWith(PoeText.ATTACKS_PER_SECOND_LABEL);

            if (String.IsNullOrEmpty(line))
            {
                AttackSpeed = 0.0;
            }
            else
            {
                AttackSpeed = _extract.DoubleFrom(line);
            }
        }
    }
}