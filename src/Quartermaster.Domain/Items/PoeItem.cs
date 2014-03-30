using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mathematically.Quartermaster.Domain.Items
{
    public class PoeItem : IPoeItem
    {
        public static readonly IEnumerable<Affix> NoAffixes = new List<Affix>();
        private readonly static IWeaponDamage NoWeaponDamage = new NullWeaponDamage();

        private readonly List<Affix> _affixes;

        public virtual string Name { get; private set; }
        public virtual ItemRarity Rarity { get; private set; }
        public virtual int ItemLevel { get; private set; }

        public IWeaponDamage Damage { get; private set; }

        public IEnumerable<Affix> Affixes { get { return _affixes; } }

        public PoeItem(string name, ItemRarity rarity, int itemLevel, IEnumerable<Affix> affixes)
        {
            Name = name;
            Rarity = rarity;
            ItemLevel = itemLevel;

            Damage = NoWeaponDamage;

            _affixes = affixes.ToList();
        }

        public PoeItem(string name, ItemRarity rarity, int itemLevel, int minPhysicalDamage, int maxPhysicalDamage, double attackSpeed, IEnumerable<Affix> affixes)
            : this(name, rarity, itemLevel, affixes)
        {
            Damage = new WeaponDamage(attackSpeed, minPhysicalDamage, maxPhysicalDamage);
        }

        public PoeItem(string name, ItemRarity rarity, int itemLevel, int minPhysicalDamage, int maxPhysicalDamage, double attackSpeed,
            int minFireDamage, int maxFireDamage, int minColdDamage, int maxColdDamage, int minLightningDamage, int maxLightningDamage, IEnumerable<Affix> affixes)
            : this(name, rarity, itemLevel, minPhysicalDamage, maxPhysicalDamage, attackSpeed, affixes)
        {
            Damage = new WeaponDamage(attackSpeed, minPhysicalDamage, maxPhysicalDamage, minFireDamage, maxFireDamage, minColdDamage, maxColdDamage, minLightningDamage, maxLightningDamage);
        }

        public PoeItem(IPoeItemData itemData)
            : this(itemData.Name, itemData.Rarity, itemData.ItemLevel, itemData.Damage.MinPhysical, itemData.Damage.MaxPhysical, itemData.Damage.AttackSpeed,
                itemData.Damage.MinFireDamage, itemData.Damage.MaxFireDamage, itemData.Damage.MinColdDamage, itemData.Damage.MaxColdDamage,
                itemData.Damage.MinLightningDamage, itemData.Damage.MaxLightningDamage, itemData.Affixes)
        {
        }

        protected PoeItem( )
        {
            Damage = NoWeaponDamage;
        }
    }
}