namespace Mathematically.Quartermaster.Domain.Mods
{
    /// <summary>
    /// AffixTier is the name, associated item level and roll range of an affix.
    /// </summary>
    public struct AffixTier
    {
        public AffixTierName Name { get; private set; }

        public int Level { get; private set; }
        public int Min { get; private set; }
        public int Max { get; private set; }

        public bool MasterCrafted { get; private set; }

        public AffixTier(AffixTierName name, int level, int min, int max, bool masterCrafted = Affix.Natural) : this()
        {
            Name = name;
            Level = level;
            Min = min;
            Max = max;
            MasterCrafted = masterCrafted;
        }
    }
}