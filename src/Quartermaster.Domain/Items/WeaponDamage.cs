using System;

namespace Mathematically.Quartermaster.Domain.Items
{
    public class WeaponDamage : IWeaponDamage
    {
        private readonly double _dps;
        private readonly double _physicalDPS;
        private readonly double _elementalDPS;

        public virtual double AttackSpeed { get; private set; }
        public virtual int MinPhysical { get; private set; }
        public virtual int MaxPhysical { get; private set; }
        public virtual int MinFireDamage { get; private set; }
        public virtual int MaxFireDamage { get; private set; }
        public virtual int MinColdDamage { get; private set; }
        public virtual int MaxColdDamage { get; private set; }
        public virtual int MinLightningDamage { get; private set; }
        public virtual int MaxLightningDamage { get; private set; }

        public double DPS
        {
            get { return _dps; }
        }

        public double PhysicalDPS
        {
            get { return _physicalDPS; }
        }

        public double ElementalDPS
        {
            get { return _elementalDPS; }
        }

        public WeaponDamage(double attackSpeed, int minPhysicalDamage, int maxPhysicalDamage)
        {
            AttackSpeed = attackSpeed;
            MinPhysical = minPhysicalDamage;
            MaxPhysical = maxPhysicalDamage;

            _physicalDPS = CalculatePhysicalDPS();
            _elementalDPS = 0;
            _dps = _physicalDPS + _elementalDPS;
        }

        public WeaponDamage(double attackSpeed, int minPhysical, int maxPhysical, int minFireDamage, int maxFireDamage,
            int minColdDamage, int maxColdDamage, int minLightningDamage, int maxLightningDamage)
        {
            AttackSpeed = attackSpeed;
            MinPhysical = minPhysical;
            MaxPhysical = maxPhysical;
            MinFireDamage = minFireDamage;
            MaxFireDamage = maxFireDamage;
            MinColdDamage = minColdDamage;
            MaxColdDamage = maxColdDamage;
            MinLightningDamage = minLightningDamage;
            MaxLightningDamage = maxLightningDamage;

            _physicalDPS = CalculatePhysicalDPS();
            _elementalDPS = CalculateElementalDPS();
            _dps = _physicalDPS + _elementalDPS;
        }

        private double CalculatePhysicalDPS()
        {
            var damageTotal = MaxPhysical + MinPhysical;
            var averageDamage = damageTotal/2.0;

            return Math.Round(averageDamage*AttackSpeed, 2);
        }

        private double CalculateElementalDPS()
        {
            var fireDamageTotal = MaxFireDamage + MinFireDamage;
            var averageFireDamage = fireDamageTotal / 2.0;

            var coldDamageTotal = MaxColdDamage + MinColdDamage;
            var averageColdDamage = coldDamageTotal / 2.0;  

            var lightningDamageTotal = MaxLightningDamage + MinLightningDamage;
            var averageLightningDamage = lightningDamageTotal / 2.0;


            return Math.Round((averageFireDamage + averageColdDamage + averageLightningDamage)*AttackSpeed, 2);
        }

        protected WeaponDamage()
        {
        }
    }
}