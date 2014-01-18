namespace Mathematically.Quartermaster.Domain.Items
{
    public class PoeItem : IPoeItem
    {
        public readonly static IWeaponDamage NoWeaponDamage = new NullWeaponDamage();

        public virtual string Name { get; private set; }
        public virtual ItemRarity Rarity { get; private set; }
        public virtual int ItemLevel { get; private set; }

        public IWeaponDamage Damage { get; private set; }

        public PoeItem(string name, ItemRarity rarity, int itemLevel)
        {
            Name = name;
            Rarity = rarity;
            ItemLevel = itemLevel;

            Damage = NoWeaponDamage;
        }

        public PoeItem(string name, ItemRarity rarity, int itemLevel, int minPhysicalDamage, int maxPhysicalDamage, double attackSpeed) 
            : this(name, rarity, itemLevel)
        {
            Damage = new WeaponDamage(attackSpeed, minPhysicalDamage, maxPhysicalDamage);
        }

        public PoeItem(string name, ItemRarity rarity, int itemLevel, int minPhysicalDamage, int maxPhysicalDamage, double attackSpeed,
            int minFireDamage, int maxFireDamage, int minColdDamage, int maxColdDamage, int minLightningDamage, int maxLightningDamage) 
            : this(name, rarity, itemLevel, minPhysicalDamage, maxPhysicalDamage, attackSpeed)
        {
            Damage = new WeaponDamage(attackSpeed, minPhysicalDamage, maxPhysicalDamage, minFireDamage, maxFireDamage, minColdDamage, maxColdDamage, minLightningDamage, maxLightningDamage);
        }

        public PoeItem(IPoeItemData itemData)
            : this(itemData.Name, itemData.Rarity, itemData.ItemLevel, itemData.Damage.MinPhysical, itemData.Damage.MaxPhysical, itemData.Damage.AttackSpeed,
                itemData.Damage.MinFireDamage, itemData.Damage.MaxFireDamage, itemData.Damage.MinColdDamage, itemData.Damage.MaxColdDamage,
                itemData.Damage.MinLightningDamage, itemData.Damage.MaxLightningDamage)
        {
        }

        protected PoeItem( )
        {
            Damage = NoWeaponDamage;
        }
    }
}