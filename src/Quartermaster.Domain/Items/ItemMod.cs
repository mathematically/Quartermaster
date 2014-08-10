using System;
using System.Linq;
using Mathematically.Quartermaster.Domain.Mods;

namespace Mathematically.Quartermaster.Domain.Items
{
    /// <summary>
    /// ItemMod is an actual instance of a particular Affix.  That is an AffixLevel with an associated roll.
    /// </summary>
    public class ItemMod: IItemMod
    {
        private readonly IAffix _affix;
        private readonly AffixLevel _affixLevel;

        /// <summary>
        /// The name of the Affix level associated with this mod.
        /// </summary>
        public AffixLevelName Name { get; private set; }

        /// <summary>
        /// The original text from the item tooltip.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Tha numeric roll value.
        /// </summary>
        public int Roll { get; private set; }

        /// <summary>
        /// The quality of this mod with respect to the items level.  That is the maximum quality available for an item of this level.
        /// </summary>
        public int ModQualityLevel { get; private set; }

        /// <summary>
        /// The overall quality of this mod relative to the highest possible level for the associated affix.
        /// </summary>
        public int ModQuality { get; private set; }

        /// <summary>
        /// The number of levels below the best possible level for this affix.
        /// </summary>
        public int Offset { get; private set; }

        /// <summary>
        /// The number of levels below the best possible affix level for an item of this item level.
        /// </summary>
        public int LevelOffset { get; private set; }


        public ItemMod(IAffix affix, string modText, int roll, int itemLevel)
        {
            _affix = affix;
            _affixLevel = affix[roll];

            Name = _affixLevel.Name;
            Text = modText;
            Roll = roll;

            CalculateLevelOffset(affix, itemLevel);
            CalculateModQuality();
        }

        private void CalculateLevelOffset(IAffix affix, int itemLevel)
        {
            var actual = affix.Levels.Count(l => l.Min <= Roll);
            var bestThisItemLevel = affix.Levels.Count(l => l.Level <= itemLevel);

            Offset = affix.Levels.Count() - actual;
            LevelOffset = bestThisItemLevel - actual;
        }

        private void CalculateModQuality()
        {
            var levels = _affix.Levels.Count();
            var perLevel = 100/levels;

            ModQuality = CalculateQuality(perLevel, Offset);
            ModQualityLevel = CalculateQuality(perLevel, LevelOffset);
        }

        private int CalculateQuality(int perLevel, int offset)
        {
            return 100 - (perLevel * offset + 1) + ((_affixLevel.Max - Roll) * (perLevel / 100));
        }
    }
}