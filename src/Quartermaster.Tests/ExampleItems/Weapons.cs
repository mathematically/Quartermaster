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

        // A rare bow with elemental damage (Fire, Lightning)
        public const string HypnoticWing = @"Rarity: Rare
Hypnotic Wing
Grove Bow
--------
Bow
Physical Damage: 13-38
Elemental Damage: 7-13 (augmented), 3-32 (augmented)
Critical Strike Chance: 5%
Attacks per Second: 1.55
--------
Requirements:
Level: 35
Dex: 116
--------
Sockets: B-G G 
--------
Itemlevel: 35
--------
+1 to Level of Bow Gems in this item
+13 to Dexterity
Adds 7-13 Fire Damage
Adds 3-32 Lightning Damage
21% increased Global Critical Strike Multiplier
+13% to Fire Resistance
";

        public const double HypnoticWingDPS = 46.50;
        public const double HypnoticWingPhysicalDPS = 19.38;
        public const double HypnoticWingElementalDPS = 27.12;

        // Tri-elemental weapon
        public const string CorpseBlast = @"Rarity: Rare
Corpse Blast
Thicket Bow
--------
Bow
Physical Damage: 19-58
Elemental Damage: 27-46 (augmented), 7-12 (augmented), 4-53 (augmented)
Critical Strike Chance: 5%
Attacks per Second: 1.55
--------
Requirements:
Level: 63 (gem)
Str (gem): 99
Dex: 179
--------
Sockets: G-G-R-R G-G 
--------
Itemlevel: 59
--------
Adds 27-46 Fire Damage
Adds 7-12 Cold Damage
Adds 4-53 Lightning Damage
+32% to Cold Resistance
";

        public const double CorpseBlastDPS = 86.80;
        public const double CorpseBlastPhysicalDPS = 30.22;
        public const double CorpseBlastElementalDPS = 56.58;

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
        // Actually 8.075 but we are just doing everything at 2 dp for simplicity's sake.
        public const double BeastThrasherDPS = 8.08; 
    }
}
