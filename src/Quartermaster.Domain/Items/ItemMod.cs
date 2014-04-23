using System.Linq;
using Mathematically.Quartermaster.Domain.Mods;

namespace Mathematically.Quartermaster.Domain.Items
{
    public class ItemMod
    {
        public AffixName Name { get; private set; }
        public string Text { get; private set; }
        public int RollValue { get; private set; }
        public int RollQuality { get; private set; }
        public int LevelOffset { get; private set; }

        public ItemMod(AffixName name, string rollText, int rollValue, int rollQuality, int levelOffset)
        {
            Name = name;
            Text = rollText;
            RollValue = rollValue;
            RollQuality = rollQuality;
            LevelOffset = levelOffset;
        }

        public ItemMod(IAffix affix, int itemLevel, string rollText, int rollValue)
        {
            var affixLevel = affix[rollValue];

            Name = affixLevel.Name;
            Text = rollText;
            RollValue = rollValue;
            RollQuality = affixLevel.CalculateQuality(rollValue);

            var best = affix.Levels.Count(l => l.Level <= itemLevel);
            var actual = affix.Levels.Count(l => l.Min <= rollValue);
            LevelOffset = actual - best;
        }
    }
}