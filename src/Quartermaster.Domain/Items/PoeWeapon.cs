namespace Mathematically.Quartermaster.Domain.Items
{
    public class PoeWeapon : PoeItem, IPoeWeapon
    {
        private readonly int _minPhysicalDamage;
        private readonly int _maxPhysicalDamage;

        private readonly double _dps;
        private readonly double _attackSpeed;

        public virtual int MinPhysicalDamage
        {
            get { return _minPhysicalDamage; }
        }

        public virtual int MaxPhysicalDamage
        {
            get { return _maxPhysicalDamage; }
        }

        public virtual double AttackSpeed
        {
            get { return _attackSpeed; }
        }

        public virtual double DPS
        {
            get { return _dps; }
        }


        public PoeWeapon(IPoeUniversalItemData itemData): base(itemData)
        {
            _minPhysicalDamage = itemData.MinPhysicalDamage;
            _maxPhysicalDamage = itemData.MaxPhysicalDamage;
            _attackSpeed = itemData.AttackSpeed;

            _dps = CalculateDPS();
        }

        protected PoeWeapon()
        {
        }

        private double CalculateDPS( )
        {
            var damageRange = MaxPhysicalDamage - MinPhysicalDamage;
            var averageDamage = damageRange/2.0;

            return averageDamage * AttackSpeed;
        }
    }
}