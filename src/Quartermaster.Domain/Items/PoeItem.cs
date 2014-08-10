using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mathematically.Quartermaster.Domain.Items
{
    public class PoeItem : IPoeItem
    {
        public static readonly IEnumerable<ItemMod> NoAffixes = new List<ItemMod>();
        private readonly static IWeaponDamage NoWeaponDamage = new NullWeaponDamage();

        private readonly List<ItemMod> _mods;

        public virtual string Name { get; private set; }
        public virtual ItemRarity Rarity { get; private set; }
        public virtual int ItemLevel { get; private set; }

        public IWeaponDamage Damage { get; private set; }

        public IEnumerable<IItemMod> Mods { get { return _mods; } }

        public PoeItem(string name, ItemRarity rarity, int itemLevel, IEnumerable<IItemMod> affixes)
        {
            Name = name;
            Rarity = rarity;
            ItemLevel = itemLevel;

            Damage = NoWeaponDamage;

            _mods = affixes.Cast<ItemMod>().ToList();
        }

        public PoeItem(string name, ItemRarity rarity, int itemLevel, int minPhysicalDamage, int maxPhysicalDamage, double attackSpeed, IEnumerable<IItemMod> affixes)
            : this(name, rarity, itemLevel, affixes)
        {
            Damage = new WeaponDamage(attackSpeed, minPhysicalDamage, maxPhysicalDamage);
        }

        public PoeItem(string name, ItemRarity rarity, int itemLevel, int minPhysicalDamage, int maxPhysicalDamage, double attackSpeed,
            int minFireDamage, int maxFireDamage, int minColdDamage, int maxColdDamage, int minLightningDamage, int maxLightningDamage, IEnumerable<IItemMod> affixes)
            : this(name, rarity, itemLevel, minPhysicalDamage, maxPhysicalDamage, attackSpeed, affixes)
        {
            Damage = new WeaponDamage(attackSpeed, minPhysicalDamage, maxPhysicalDamage, minFireDamage, maxFireDamage, minColdDamage, maxColdDamage, minLightningDamage, maxLightningDamage);
        }

        public PoeItem(IPoeItemData itemData)
            : this(itemData.Name, itemData.Rarity, itemData.ItemLevel, itemData.Damage.MinPhysical, itemData.Damage.MaxPhysical, itemData.Damage.AttackSpeed,
                itemData.Damage.MinFireDamage, itemData.Damage.MaxFireDamage, itemData.Damage.MinColdDamage, itemData.Damage.MaxColdDamage,
                itemData.Damage.MinLightningDamage, itemData.Damage.MaxLightningDamage, itemData.Mods)
        {
        }

        protected PoeItem( )
        {
            Damage = NoWeaponDamage;
        }
    }
}