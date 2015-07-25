namespace Mathematically.Quartermaster.Domain.Items
{
    /// <summary>
    ///     The general category of item.  A superset of base type from http://www.pathofexile.com/item-data/weapon,
    ///     http://www.pathofexile.com/item-data/armour, etc. and a subset of Weapon, Armour or Other.
    /// </summary>
    public enum ItemCategory
    {
        // Weapons
        OneHandAxes,
        TwoHandAxes,
        Bows,
        Claws,
        TwoHandMaces,
        Wands,

        // Armour
        Boots,
        Belts,

        // Other
        Amulets,
        Rings,
    }
}