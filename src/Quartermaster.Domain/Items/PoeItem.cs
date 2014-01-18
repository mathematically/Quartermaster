using System;

namespace Mathematically.Quartermaster.Domain.Items
{
    public class PoeItem : IPoeItem
    {
        public readonly static IElementalDamage ZeroElementalDamage = new NullElementalDamage();

        public virtual string Name { get; private set; }
        public virtual ItemRarity Rarity { get; private set; }
        public virtual int ItemLevel { get; private set; }

        public virtual int MinPhysicalDamage { get; private set; }
        public virtual int MaxPhysicalDamage { get; private set; }
        public virtual double AttackSpeed { get; private set; }
        public virtual double DPS { get; private set; }

        public IElementalDamage Elemental { get; private set; }

        public PoeItem(string name, ItemRarity rarity, int itemLevel)
        {
            Elemental = ZeroElementalDamage;
            MaxPhysicalDamage = 0;
            Name = name;
            Rarity = rarity;
            ItemLevel = itemLevel;
        }

        public PoeItem(string name, ItemRarity rarity, int itemLevel, int minPhysicalDamage, int maxPhysicalDamage, double attackSpeed) 
            : this(name, rarity, itemLevel)
        {
            MinPhysicalDamage = minPhysicalDamage;
            MaxPhysicalDamage = maxPhysicalDamage;
            AttackSpeed = attackSpeed;

            DPS = CalculateDPS();
        }

        public PoeItem(string name, ItemRarity rarity, int itemLevel, int minPhysicalDamage, int maxPhysicalDamage, double attackSpeed,
            int minFireDamage, int maxFireDamage, int minColdDamage, int maxColdDamage, int minLightningDamage, int maxLightningDamage) 
            : this(name, rarity, itemLevel)
        {
            MinPhysicalDamage = minPhysicalDamage;
            MaxPhysicalDamage = maxPhysicalDamage;
            AttackSpeed = attackSpeed;
            Elemental = new ElementalDamage(minFireDamage, maxFireDamage, minColdDamage, maxColdDamage, minLightningDamage, maxLightningDamage);

            DPS = CalculateDPS();
        }

        public PoeItem(IPoeItemData itemData)
            : this(itemData.Name, itemData.Rarity, itemData.ItemLevel, itemData.MinPhysicalDamage, itemData.MaxPhysicalDamage, itemData.AttackSpeed,
                itemData.Elemental.MinFireDamage, itemData.Elemental.MaxFireDamage, itemData.Elemental.MinColdDamage, itemData.Elemental.MaxColdDamage,
                itemData.Elemental.MinLightningDamage, itemData.Elemental.MaxLightningDamage)
        {
        }

        protected PoeItem( )
        {
            Elemental = ZeroElementalDamage;
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