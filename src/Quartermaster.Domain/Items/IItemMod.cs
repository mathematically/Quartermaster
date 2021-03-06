using Mathematically.Quartermaster.Domain.Mods;

namespace Mathematically.Quartermaster.Domain.Items
{
    public interface IItemMod
    {
        IAffix Affix { get; }

        /// <summary>
        /// The name of the Affix level associated with this mod.
        /// </summary>
        AffixTierName Name { get; }

        /// <summary>
        /// The original text from the item tooltip.
        /// </summary>
        string Text { get; }

        /// <summary>
        /// Tha numeric roll value.
        /// </summary>
        int Roll { get; }

        /// <summary>
        /// The quality of this mod with respect to the item's level.  That is the maximum quality available for an item of this level.
        /// </summary>
        int ModQualityLevel { get; }

        /// <summary>
        /// The overall quality of this mod relative to the highest possible level for the associated affix.
        /// </summary>
        int ModQuality { get; }

        /// <summary>
        /// The number of levels below the best possible level for this affix.
        /// </summary>
        int Offset { get; }

        /// <summary>
        /// The number of levels below the best possible affix level for an item of this item level.
        /// </summary>
        int LevelOffset { get; }

        /// <summary>
        /// The maximum roll value.
        /// </summary>
        int MaxRoll { get; }

        /// <summary>
        /// The maximum roll value.
        /// </summary>
        int MaxRollLevel { get; }
    }
}