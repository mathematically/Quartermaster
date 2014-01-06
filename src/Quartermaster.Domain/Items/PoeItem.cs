using System;

namespace Mathematically.Quartermaster.Domain.Items
{
    public class PoeItem : IPoeItem
    {
        public readonly static IElementalDamage ZeroElementalDamage = new NullElementalDamage();

        private readonly string _name;
        private readonly ItemRarity _rarity;
        private readonly int _itemLevel;
        private readonly int _minPhysicalDamage;
        private readonly int _maxPhysicalDamage;
        private readonly double _attackSpeed;
        private readonly IElementalDamage _elemental = ZeroElementalDamage;

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

        public IElementalDamage Elemental
        {
            get { return _elemental; }
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

        public PoeItem(string name, ItemRarity rarity, int itemLevel, int minPhysicalDamage, int maxPhysicalDamage, double attackSpeed,
            int minFireDamage, int maxFireDamage, int minColdDamage, int maxColdDamage, int minLightningDamage, int maxLightningDamage) 
            : this(name, rarity, itemLevel)
        {
            _minPhysicalDamage = minPhysicalDamage;
            _maxPhysicalDamage = maxPhysicalDamage;
            _attackSpeed = attackSpeed;
            _elemental = new ElementalDamage(minFireDamage, maxFireDamage, minColdDamage, maxColdDamage, minLightningDamage, maxLightningDamage);

            _dps = CalculateDPS();
        }

        public PoeItem(IPoeItemData itemData)
            : this(itemData.Name, itemData.Rarity, itemData.ItemLevel, itemData.MinPhysicalDamage, itemData.MaxPhysicalDamage, itemData.AttackSpeed,
                itemData.Elemental.MinFireDamage, itemData.Elemental.MaxFireDamage, itemData.Elemental.MinColdDamage, itemData.Elemental.MaxColdDamage,
                itemData.Elemental.MinLightningDamage, itemData.Elemental.MaxLightningDamage)
        {
        }

        protected PoeItem( )
        {
        }

        private double CalculateDPS( )
        {
            var damageRange = MaxPhysicalDamage + Elemental.MaxFireDamage + Elemental.MaxColdDamage + Elemental.MaxLightningDamage - 
                MinPhysicalDamage - Elemental.MinFireDamage - Elemental.MinColdDamage - Elemental.MinLightningDamage;

            var averageDamage = damageRange / 2.0;

            return Math.Round(averageDamage*AttackSpeed, 2);
        }
    }

}