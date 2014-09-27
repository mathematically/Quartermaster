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
        private readonly AffixLevel _affixLevel;

        public IAffix Affix { get; private set; }

        /// <summary>
        /// The name of the Affix level associated with this mod.
        /// </summary>
        public AffixLevelName Name { get; private set; }

        /// <summary>
        /// The original text from the item tooltip.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// The numeric roll value.
        /// </summary>
        public int Roll { get; private set; }

        /// <summary>
        /// The maximum roll value for this affix.
        /// </summary>
        public int MaxRoll { get; private set; }

        /// <summary>
        /// The maximum roll value for the given level of this affix.
        /// </summary>
        public int MaxRollLevel { get; private set; }

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
            Affix = affix;
            _affixLevel = affix[roll];

            Name = _affixLevel.Name;
            Text = modText;
            Roll = roll;
            MaxRoll = affix.Levels.Last().Max;
            MaxRollLevel = _affixLevel.Max;

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
            var r = (double) Roll;
            var max = (double) Affix.Levels.Last().Max;
            var lmax = (double) _affixLevel.Max;

            ModQuality = (int) ((r/max)*100.0);
            ModQualityLevel = (int)((r / lmax) * 100.0);
        }
    }
}