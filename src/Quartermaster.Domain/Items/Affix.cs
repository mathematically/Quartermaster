namespace Mathematically.Quartermaster.Domain.Items
{
    public class Affix
    {
        public AffixName Name { get; private set; }
        public string Text { get; private set; }
        public int Value { get; private set; }
        public int RollQuality { get; private set; }
        public int LevelOffset { get; private set; }

        public Affix(AffixName name, string text, int value, int rollQuality, int levelOffset)
        {
            Text = text;
            Name = name;
            Value = value;
            RollQuality = rollQuality;
            LevelOffset = levelOffset;
        }
    }
}