using System;

namespace Mathematically.Quartermaster.Domain.Items
{
    public class PoeItem : IPoeItem
    {
        private readonly string _name;
        private readonly ItemRarity _rarity;
        private readonly int _itemLevel;
        private readonly int _minPhysicalDamage;
        private readonly int _maxPhysicalDamage;
        private readonly double _attackSpeed;

        private readonly double _dps;

        public virtual string Name
        {
            get { return _name; }
        }

        public virtual ItemRarity Rarity
        {
            get { return _rarity; }
        }

        public virtual int ItemLevel
        {
            get { return _itemLevel; }
        }

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

        public PoeItem(string name, ItemRarity rarity, int itemLevel)
        {
            _maxPhysicalDamage = 0;
            _name = name;
            _rarity = rarity;
            _itemLevel = itemLevel;
        }

        public PoeItem(string name, ItemRarity rarity, int itemLevel, int minPhysicalDamage, int maxPhysicalDamage, double attackSpeed) 
            : this(name, rarity, itemLevel)
        {
            _minPhysicalDamage = minPhysicalDamage;
            _maxPhysicalDamage = maxPhysicalDamage;
            _attackSpeed = attackSpeed;

            _dps = CalculateDPS();
        }

        public PoeItem(IPoeItemData itemData)
            : this(itemData.Name, itemData.Rarity, itemData.ItemLevel, itemData.MinPhysicalDamage, itemData.MaxPhysicalDamage, itemData.AttackSpeed)
        {
        }

        protected PoeItem( )
        {
        }

        private double CalculateDPS( )
        {
            var damageRange = MaxPhysicalDamage - MinPhysicalDamage;
            var averageDamage = damageRange/2.0;

            return Math.Round(averageDamage*AttackSpeed, 2);
        }
    }
}