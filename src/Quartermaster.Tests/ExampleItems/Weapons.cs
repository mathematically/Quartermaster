namespace Mathematically.Quartermaster.Tests.ExampleItems
{
    public static class Weapons
    {
        // About as simple as a weapon can be
        internal const string DriftwoodWand = @"Rarity: Normal
Driftwood Wand
--------
Wand
Physical Damage: 4-7
Critical Strike Chance: 8%
Attacks per Second: 1.30
--------
Sockets: B 
--------
Itemlevel: 4
--------
11% increased Spell Damage
";

        public const double DriftwoodWandDPS = 1.95;

        // Another simple example weapon
        internal const string DriftwoodMaul = @"Rarity: Normal
Driftwood Maul
--------
Two Handed Mace
Physical Damage: 12-19
Critical Strike Chance: 5%
Attacks per Second: 1.10
--------
Requirements:
Strength: 20
--------
Sockets: R-B 
--------
Itemlevel: 4
--------
20% increased Stun Duration on enemies
";
        public const double DriftwoodMaulDPS = 3.85;

        // Blue weapon with augmented weapons stats
        internal const string HeavyShortBow = @"Rarity: Magic
Heavy Short Bow
--------
Bow
Physical Damage: 5-14 (augmented)
Critical Strike Chance: 5%
Attacks per Second: 1.55
--------
Requirements:
Level: 5
Dex: 26
--------
Sockets: G 
--------
Itemlevel: 7
--------
23% increased Physical Damage
";

        public const double HeavyShortBowDPS = 6.98;

        // Rare weapon with all sorts of stats
        public const string BeastThrasher = @"Rarity: Rare
Beast Thresher
Tribal Maul
--------
Two Handed Mace
Quality: +1% (augmented)
Physical Damage: 31-48 (augmented)
Critical Strike Chance: 5%
Attacks per Second: 0.95
--------
Requirements:
Level: 8
Str: 35
--------
Sockets: R R 
--------
Itemlevel: 8
--------
20% increased Stun Duration on enemies
--------
+1 to Level of Melee Gems in this item
29% increased Physical Damage
Adds 2-4 Physical Damage
7% reduced Enemy Stun Threshold
+11% to Cold Resistance
14% increased Stun Duration on enemies
";
        public const double BeastThrasherDPS = 8.08; // Actually 8.075

    }
}