namespace Mathematically.Quartermaster.Domain
{
    public static class PoeText
    {
        public const string RARITY_MARKER = "Rarity: ";
        public const string SECTION_DIVIDER = "--------";
        public const string ITEMLEVEL_MARKER = "Itemlevel: ";

        // Check diff line endings in case we get some windows text in their somehow.
        public static readonly string[] AllPlatformLineSplitChars = { "\r\n", "\n" };
    }
}