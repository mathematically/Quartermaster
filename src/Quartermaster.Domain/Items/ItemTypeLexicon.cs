using System;
using System.Collections.Generic;
using System.Linq;
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

        public ItemTypeLexicon()
        {
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

            // ARMOUR
            values.Where(t => t >= BaseItemType.IronGreaves && t <= BaseItemType.SlinkBoots)
                .ForEach(t => Lexicon.Add(t, ItemCategory.Boots));

            // JEWELRY
            values.Where(t => t >= BaseItemType.PauaAmulet && t <= BaseItemType.OnyxAmulet)
                .ForEach(t => Lexicon.Add(t, ItemCategory.Amulet));
            values.Where(t => t >= BaseItemType.IronRing && t <= BaseItemType.UnsetRing)
                .ForEach(t => Lexicon.Add(t, ItemCategory.Ring));
        }

        public ItemCategory GetItemCategory(BaseItemType forBaseType)
        {
            return Lexicon[forBaseType];
        }

        public bool IsValidOnBaseType(IAffix affix, BaseItemType baseItemType)
        {
            throw new NotImplementedException();
        }
    }
}