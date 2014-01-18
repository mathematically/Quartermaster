using System;
using System.Collections.Generic;
using System.Linq;
using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Domain.Parser
{
    public class PoeItemParser : IPoeItemParser
    {
        // These line positions are always the same
        private const int RarityLineIndex = 0;
        private const int NameLineIndex = 1;

        private string[] _textLines;
        private readonly PoeTextValueExtractor _extract = new PoeTextValueExtractor();

        public string Name { get; private set; }
        public ItemRarity Rarity { get; private set; }
        public int ItemLevel { get; private set; }
        public bool IsWeapon { get; private set; }
        public int MinPhysicalDamage { get; private set; }
        public int MaxPhysicalDamage { get; private set; }
        public double AttackSpeed { get; private set; }
        public IElementalDamage Elemental { get; private set; }

        public void Parse(string itemText)
        {
            _textLines = itemText.Split(Constants.AllPlatformLineSplitChars, StringSplitOptions.None);

            BasePropertiesParse();
            WeaponParse();
        }

        private void BasePropertiesParse( )
        {
            Name = _textLines[NameLineIndex];
            Rarity = ParseRarity();
            ItemLevel = ParseItemLevel();
        }

        private ItemRarity ParseRarity( )
        {
            var rarityText = _extract.ValueTextFrom(_textLines[RarityLineIndex]);

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

        private void WeaponParse( )
        {
            IsWeapon = DetectWeapon();

            if (IsWeapon)
            {
                ParseWeaponStats();
            }
            else
            {
                ResetWeaponStats();
            }
        }

        private bool DetectWeapon()
        {
            return FindOptionalLineWith(PoeText.WEAPON_MARKER) != null;
        }

        private void ParseWeaponStats()
        {
            ParsePhysicalDamage();
            ParseElementalDamage();
            ParseAttackSpeed();
        }

        private void ResetWeaponStats( )
        {
            MinPhysicalDamage = 0;
            MaxPhysicalDamage = 0;
            AttackSpeed = 0.0;
            Elemental = PoeItem.ZeroElementalDamage;
        }

        private void ParsePhysicalDamage()
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

                MinPhysicalDamage = range.Min;
                MaxPhysicalDamage = range.Max;
            }
        }

        private void ParseElementalDamage()
        {
            var line = FindOptionalLineWith(PoeText.ELEMENTAL_DAMAGE_LABEL);

            Elemental = String.IsNullOrEmpty(line) ? new NullElementalDamage() : BuildElementalDamage(line);
        }

        private IElementalDamage BuildElementalDamage(string line)
        {
            var elementalRanges = new List<Range>()
            {
                // If we don't find a particular element we will use this for 0 dps in that element.
                new Range {Min = 0, Max = 0}
            };

            elementalRanges.AddRange(_extract.RangeSetFrom(line));

            // Damage mods are always in the order fire, cold, lightning
            var n = 1;
            var fire = 0;
            var cold = 0;
            var lightning = 0;

            if (FindOptionalLineWith(PoeText.FIRE_DAMAGE_LABEL) != null)
            {
                // Fire is the nth range
                fire = n++;
            }

            if (FindOptionalLineWith(PoeText.COLD_DAMAGE_LABEL) != null)
            {
                cold = n++;
            }

            if (FindOptionalLineWith(PoeText.LIGHTNING_DAMAGE_LABEL) != null)
            {
                lightning = n;
            }

            return new ElementalDamage(
                elementalRanges[fire].Min, elementalRanges[fire].Max,
                elementalRanges[cold].Min, elementalRanges[cold].Max,
                elementalRanges[lightning].Min, elementalRanges[lightning].Max
                );
        }

        private void ParseAttackSpeed()
        {
            var line = FindOptionalLineWith(PoeText.ATTACKS_PER_SECOND_LABEL);

            AttackSpeed = String.IsNullOrEmpty(line) ? 0.0 : _extract.DoubleFrom(line);
        }
    }

}