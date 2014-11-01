using Mathematically.Quartermaster.Domain.Mods;

namespace Mathematically.Quartermaster.Domain.Items
{
    /// <summary>
    ///     Allows lookup and cross referencing of base types, item categories, etc.  E.g. so we can tell if a mod
    ///     is valid on a particular item, etc.
    /// </summary>
    public interface IItemLexicon
    {
        ItemCategory GetItemCategory(BaseItemType forBaseType);
        bool IsValidOnBaseType(IAffix affix, BaseItemType baseItemType);
    }
}