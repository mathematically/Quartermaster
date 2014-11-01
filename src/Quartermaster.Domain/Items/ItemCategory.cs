namespace Mathematically.Quartermaster.Domain.Items
{
    /// <summary>
    ///     The general category of item.  A superset of base type from http://www.pathofexile.com/item-data/weapon,
    ///     http://www.pathofexile.com/item-data/armour, etc. and a subset of Weapon, Armour or Other.
    /// </summary>
    public enum ItemCategory
    {
        // Weapons
        OneHandAxe,
        TwoHandAxe,
        Bow,
        Claw,
        TwoHandMace,
        Wand,

        // Armour
        Boots,
        Belts,

        // Other
        Amulet,
        Ring,
    }

}