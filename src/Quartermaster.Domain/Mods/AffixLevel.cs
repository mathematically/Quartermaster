using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Domain.Mods
{
    /// <summary>
    /// AffixLevel is the name, associated item level and roll range of an affix.
    /// </summary>
    public struct AffixLevel
    {
        public AffixLevelName Name { get; private set; }

        public int Level { get; private set; }
        public int Min { get; private set; }
        public int Max { get; private set; }

        public AffixLevel(AffixLevelName name, int level, int min, int max) : this()
        {
            Name = name;
            Level = level;
            Min = min;
            Max = max;
        }
    }
}