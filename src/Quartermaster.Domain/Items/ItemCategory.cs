namespace Mathematically.Quartermaster.Domain.Items
{
    /// <summary>
    ///     The general category of item.  A superset of base type from http://www.pathofexile.com/item-data/weapon,
    ///     http://www.pathofexile.com/item-data/armour, etc.
    /// </summary>
    public enum ItemCategory
    {
        // Weapons
        Bow,
        OneHandAxe,
        TwoHandAxe,
        TwoHandMace,
        Wand,

        // Armour
        Boots,

        // Other
        Amulet,
        Ring,
    }
}