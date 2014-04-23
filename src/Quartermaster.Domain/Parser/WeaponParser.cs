using System;
using System.Collections.Generic;
using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Domain.Parser
{
    public class WeaponParser : PoeTextValueExtractor, IWeaponDamage
    {
        private GameText _gameText;
        private Range _physicalDamageRange;
        private Range _fireDamageRange;
        private Range _coldDamageRange;
        private Range _lightningDamageRange;
        private double _attackSpeed;

        // Default to the null object until/unless parsed.
        private WeaponDamage _damage = new NullWeaponDamage();

        public bool IsWeapon { get; private set; }

        public int MinPhysical
        {
            get { return _damage.MinPhysical; }
        }

        public int MaxPhysical
        {
            get { return _damage.MaxPhysical; }
        }

        public int MinFireDamage
        {
            get { return _damage.MinFireDamage; }
        }

        public int MaxFireDamage
        {
            get { return _damage.MaxFireDamage; }
        }

        public int MinColdDamage
        {
            get { return _damage.MinColdDamage; }
        }

        public int MaxColdDamage
        {
            get { return _damage.MaxColdDamage; }
        }

        public int MinLightningDamage
        {
            get { return _damage.MinLightningDamage; }
        }

        public int MaxLightningDamage
        {
            get { return _damage.MaxLightningDamage; }
        }

        public double AttackSpeed
        {
            get { return _damage.AttackSpeed; }
        }

        public double DPS
        {
            get { return _damage.DPS; }
        }

        public double PhysicalDPS
        {
            get { return _damage.PhysicalDPS; }
        }

        public double ElementalDPS
        {
            get { return _damage.ElementalDPS; }
        }

        public void Parse(GameText gameText)
        {
            _gameText = gameText;

            IsWeapon = DetectWeapon();

            if (IsWeapon)
            {
                ParseWeaponStats();
            }
        }

        private bool DetectWeapon()
        {
            return _gameText.OptionalLineWith(PoeText.WEAPON_MARKER) != null;
        }

        private void ParseWeaponStats()
        {
            _physicalDamageRange = new Range {Min = 0, Max = 0};
            _fireDamageRange = new Range {Min = 0, Max = 0};
            _coldDamageRange = new Range {Min = 0, Max = 0};
            _lightningDamageRange = new Range {Min = 0, Max = 0};

            ParseAttackSpeed();

            ParsePhysicalDamage();
            ParseElementalDamage();

            _damage = new WeaponDamage(_attackSpeed, _physicalDamageRange.Min, _physicalDamageRange.Max,
                _fireDamageRange.Min, _fireDamageRange.Max,
                _coldDamageRange.Min, _coldDamageRange.Max,
                _lightningDamageRange.Min, _lightningDamageRange.Max);
        }

        private void ParseAttackSpeed()
        {
            var line = _gameText.OptionalLineWith(PoeText.ATTACKS_PER_SECOND_LABEL);

            _attackSpeed = String.IsNullOrEmpty(line) ? 0.0 : DoubleFrom(line);
        }

        private void ParsePhysicalDamage()
        {
            var line = _gameText.OptionalLineWith(PoeText.PHYSICAL_DAMAGE_LABEL);
            if (String.IsNullOrEmpty(line)) return;

            _physicalDamageRange = IntegerRangeFrom(line);
        }

        private void ParseElementalDamage()
        {
            var line = _gameText.OptionalLineWith(PoeText.ELEMENTAL_DAMAGE_LABEL);
            if (String.IsNullOrEmpty(line)) return;

            BuildElementalDamage(line);
        }

        private void BuildElementalDamage(string line)
        {
            var elementalRanges = new List<Range>
            {
                // If we don't find a particular element we will use this for 0 dps in that element.
                new Range {Min = 0, Max = 0}
            };

            elementalRanges.AddRange(RangeSetFrom(line));

            // Damage mods are always in the order fire, cold, lightning
            var n = 1;

            // Assume that we find no damage for each element and will use the 0th range
            // which is the dummy null one we created.
            var fire = 0;
            var cold = 0;
            var lightning = 0;

            if (_gameText.OptionalLineWith(PoeText.FIRE_DAMAGE_LABEL) != null)
            {
                // Fire is the nth range specified on the item
                fire = n++;
            }

            if (_gameText.OptionalLineWith(PoeText.COLD_DAMAGE_LABEL) != null)
            {
                cold = n++;
            }

            if (_gameText.OptionalLineWith(PoeText.LIGHTNING_DAMAGE_LABEL) != null)
            {
                lightning = n;
            }

            _fireDamageRange = new Range
            {
                Min = elementalRanges[fire].Min,
                Max = elementalRanges[fire].Max
            };

            _coldDamageRange = new Range
            {
                Min = elementalRanges[cold].Min,
                Max = elementalRanges[cold].Max
            };


            _lightningDamageRange = new Range
            {
                Min = elementalRanges[lightning].Min,
                Max = elementalRanges[lightning].Max
            };
        }
    }
}