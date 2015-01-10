using System;
using System.Collections.Generic;
using System.Linq;
using Mathematically.Quartermaster.Domain.Affixes;
using Mathematically.Quartermaster.Domain.Mods;

namespace Mathematically.Quartermaster.Domain.Items
{
    /// <summary>
    ///     Allows lookup and cross referencing of base types, item categories, etc.  E.g. so we can tell if a mod
    ///     is valid on a particular item, etc.
    /// </summary>
    public class ItemTypeLexicon : IItemLexicon
    {
        private static readonly Dictionary<BaseItemType, ItemCategory> Lexicon =
            new Dictionary<BaseItemType, ItemCategory>();

        private static readonly HashSet<ItemCategory> Weapons = new HashSet<ItemCategory>
        {
            ItemCategory.Bow,
            ItemCategory.Claw,
            ItemCategory.OneHandAxe,
            ItemCategory.TwoHandAxe,
            ItemCategory.TwoHandMace,
            ItemCategory.Wand,
        };

        private static readonly HashSet<ItemCategory> Armours = new HashSet<ItemCategory>
        {
            ItemCategory.Belts,
            ItemCategory.Boots,
        };

        private static readonly HashSet<ItemCategory> Other = new HashSet<ItemCategory>
        {
            ItemCategory.Amulet,
            ItemCategory.Ring,
        };

        private static readonly HashSet<ItemCategory> _belts = new HashSet<ItemCategory>
        {
            ItemCategory.Belts,
        };

        private static readonly Dictionary<Type, HashSet<ItemCategory>> AffixItemCategoryValidCombos = new Dictionary
            <Type, HashSet<ItemCategory>>();

        private static readonly HashSet<ItemCategory> _nonWeapons = new HashSet<ItemCategory>(Armours.Union(Other));
        private static readonly HashSet<ItemCategory> _nonWeaponsExceptBelts = new HashSet<ItemCategory>(_nonWeapons.Except(_belts));

        public ItemTypeLexicon()
        {
            if (Lexicon.Any())
                return;

            var values = Enum.GetValues(typeof (BaseItemType)).Cast<BaseItemType>().ToList();

            // WEAPONS
            values.Where(t => t >= BaseItemType.CrudeBow && t <= BaseItemType.HarbingerBow)
                .ForEach(t => Lexicon.Add(t, ItemCategory.Bow));
            values.Where(t => t >= BaseItemType.RustedHatchet && t <= BaseItemType.InfernalAxe)
                .ForEach(t => Lexicon.Add(t, ItemCategory.OneHandAxe));
            values.Where(t => t >= BaseItemType.StoneAxe && t <= BaseItemType.VoidAxe)
                .ForEach(t => Lexicon.Add(t, ItemCategory.TwoHandAxe));
            values.Where(t => t >= BaseItemType.DriftwoodMaul && t <= BaseItemType.TerrorMaul)
                .ForEach(t => Lexicon.Add(t, ItemCategory.TwoHandMace));
            values.Where(t => t >= BaseItemType.DriftwoodWand && t <= BaseItemType.ProphecyWand)
                .ForEach(t => Lexicon.Add(t, ItemCategory.Wand));
            values.Where(t => t >= BaseItemType.NailedFist && t <= BaseItemType.TerrorClaw)
                .ForEach(t => Lexicon.Add(t, ItemCategory.Claw));

            // ARMOUR
            values.Where(t => t >= BaseItemType.IronGreaves && t <= BaseItemType.SlinkBoots)
                .ForEach(t => Lexicon.Add(t, ItemCategory.Boots));

            // JEWELRY
            values.Where(t => t >= BaseItemType.PauaAmulet && t <= BaseItemType.OnyxAmulet)
                .ForEach(t => Lexicon.Add(t, ItemCategory.Amulet));
            values.Where(t => t >= BaseItemType.IronRing && t <= BaseItemType.UnsetRing)
                .ForEach(t => Lexicon.Add(t, ItemCategory.Ring));

            // Use local attack speed for weapons and global attack speed for other items. Does not appear on belts.
            AffixItemCategoryValidCombos.Add(typeof(AttackSpeedLocal), Weapons);
            AffixItemCategoryValidCombos.Add(typeof(AttackSpeedGlobal), _nonWeaponsExceptBelts);
        }

        public ItemCategory GetItemCategory(BaseItemType forBaseType)
        {
            return Lexicon[forBaseType];
        }

        public bool IsValidOnBaseType(IAffix affix, BaseItemType baseItemType)
        {
            var affixType = affix.GetType();

            if (!AffixItemCategoryValidCombos.ContainsKey(affixType))
            {
                // No list of valid combos, so affix is valid on all types.
                return true;
            }

            // If the affix has valid combos then the item category must be listed there for this
            // affix to be valid on this type.
            return AffixItemCategoryValidCombos[affixType].Contains(GetItemCategory(baseItemType));
        }
    }
}