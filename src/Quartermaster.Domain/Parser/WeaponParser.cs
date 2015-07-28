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

        public int MinPhysical => _damage.MinPhysical;

        public int MaxPhysical => _damage.MaxPhysical;

        public int MinFireDamage => _damage.MinFireDamage;

        public int MaxFireDamage => _damage.MaxFireDamage;

        public int MinColdDamage => _damage.MinColdDamage;

        public int MaxColdDamage => _damage.MaxColdDamage;

        public int MinLightningDamage => _damage.MinLightningDamage;

        public int MaxLightningDamage => _damage.MaxLightningDamage;

        public double AttackSpeed => _damage.AttackSpeed;

        public double DPS => _damage.DPS;

        public double PhysicalDPS => _damage.PhysicalDPS;

        public double ElementalDPS => _damage.ElementalDPS;

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
            return _gameText.OptionalLineWith(TooltipText.WEAPON_MARKER) != null;
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
            var line = _gameText.OptionalLineWith(TooltipText.ATTACKS_PER_SECOND_LABEL);

            _attackSpeed = String.IsNullOrEmpty(line) ? 0.0 : DoubleFrom(line);
        }

        private void ParsePhysicalDamage()
        {
            var physicalDamageLine = _gameText.OptionalLineWith(TooltipText.PHYSICAL_DAMAGE_LABEL);
            if (String.IsNullOrEmpty(physicalDamageLine)) return;

            _physicalDamageRange = IntegerRangeFrom(physicalDamageLine);
        }

        private void ParseElementalDamage()
        {
            var elementalDamageLine = _gameText.OptionalLineWith(TooltipText.ELEMENTAL_DAMAGE_LABEL);
            if (String.IsNullOrEmpty(elementalDamageLine)) return;

            BuildElementalDamage(elementalDamageLine);
        }

        private void BuildElementalDamage(string line)
        {
            var elementalRangeMap = BuildElementalRangeMap(line);

            // Assume that we find no damage for each element and will use the 0th range
            // which is the dummy null one we created.
            var fire = 0;
            var cold = 0;
            var lightning = 0;

            // Elemental damage mods are always in the order fire, cold, lightning.  We start looking at the 1st element.
            var n = 1;

            if (_gameText.HasOptionalLineWith(TooltipText.FIRE_DAMAGE_LABEL))
            {
                // Fire is the nth range specified on the item
                fire = n++;
            }

            if (_gameText.HasOptionalLineWith(TooltipText.COLD_DAMAGE_LABEL))
            {
                cold = n++;
            }

            if (_gameText.HasOptionalLineWith(TooltipText.LIGHTNING_DAMAGE_LABEL))
            {
                lightning = n;
            }

            _fireDamageRange = new Range
            {
                Min = elementalRangeMap[fire].Min,
                Max = elementalRangeMap[fire].Max
            };

            _coldDamageRange = new Range
            {
                Min = elementalRangeMap[cold].Min,
                Max = elementalRangeMap[cold].Max
            };


            _lightningDamageRange = new Range
            {
                Min = elementalRangeMap[lightning].Min,
                Max = elementalRangeMap[lightning].Max
            };
        }

        private List<Range> BuildElementalRangeMap(string line)
        {
            var elementalRangeMap = new List<Range>
            {
                // If we don't find a particular element we will use this for 0 dps in that element.
                new Range {Min = 0, Max = 0}
            };

            elementalRangeMap.AddRange(RangeSetFrom(line));
            return elementalRangeMap;
        }
    }
}