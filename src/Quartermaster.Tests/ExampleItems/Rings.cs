namespace Mathematically.Quartermaster.Tests.ExampleItems
{
    public static class Rings
    {
        // Pretty much the most basic item possible.
        internal const string IronRing = @"Rarity: Normal
Iron Ring
--------
Itemlevel: 4
--------
Adds 1-4 Physical Damage
";

        // Another simple ring with an item requirement.
        internal const string SapphireRing = @"Rarity: Normal
Sapphire Ring
--------
Requirements:
Level: 11
--------
Itemlevel: 15
--------
+28% to Cold Resistance
";

        // A magic ring
        internal const string ThirstyRubyRingOfSuccess = @"Rarity: Magic
Thirsty Ruby Ring of Success
--------
Requirements:
Level: 11
--------
Itemlevel: 16
--------
+30% to Fire Resistance
--------
+3 Life gained on Kill
1% of Physical Attack Damage Leeched as Mana
";
    }
}