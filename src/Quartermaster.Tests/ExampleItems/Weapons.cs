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

        internal const double DriftwoodWandDPS = ((7 - 4) / 2.0) * 1.3;

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
        internal const double DriftwoodMaulDPS = ((19 - 12) / 2.0) * 1.1;
    }
}