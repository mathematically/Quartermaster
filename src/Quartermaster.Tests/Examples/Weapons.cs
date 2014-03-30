using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Tests.Examples
{
    public static class Weapons
    {
        #region DRIFTWOOD WAND

        // About as simple as a weapon can be
        internal const string DriftwoodWandText = @"Rarity: Normal
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

        public static readonly PoeItem DriftwoodWand = new PoeItem(
            "Driftwood Wand",
            ItemRarity.Normal,
            itemLevel: 4,
            minPhysicalDamage: 4,
            maxPhysicalDamage: 7,
            attackSpeed: 1.30,
            affixes: PoeItem.NoAffixes);

        public const double DriftwoodWandDPS = 1.95;

        #endregion

        #region DRIFTWOOD MAUL

        // Another simple example weapon
        internal const string DriftwoodMaulText = @"Rarity: Normal
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

        public static readonly PoeItem DriftwoodMaul = new PoeItem(
            "Driftwood Maul",
            ItemRarity.Normal,
            itemLevel: 4,
            minPhysicalDamage: 12,
            maxPhysicalDamage: 19,
            attackSpeed: 1.1,
            affixes: PoeItem.NoAffixes);

        public const double DriftwoodMaulDPS = 3.85;


        #endregion

        #region HEAVY SHORT BOW

        // Blue weapon with augmented weapons stats
        internal const string HeavyShortBowText = @"Rarity: Magic
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

        public static readonly PoeItem HeavyShortBow = new PoeItem(
            "Heavy Short Bow",
            ItemRarity.Magic,
            itemLevel: 7,
            minPhysicalDamage: 5,
            maxPhysicalDamage: 14,
            attackSpeed: 1.55,
            affixes: PoeItem.NoAffixes);

        public const double HeavyShortBowDPS = 6.98;


        #endregion

        #region HYPNOTIC WING

        // A rare bow with elemental damage (Fire, Lightning)
        public const string HypnoticWingText = @"Rarity: Rare
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

        public static readonly PoeItem HypnoticWing = new PoeItem(
            "Hypnotic Wing",
            ItemRarity.Rare,
            itemLevel: 35,
            minPhysicalDamage: 13,
            maxPhysicalDamage: 38,
            attackSpeed: 1.55,
            minFireDamage: 7, maxFireDamage: 13,
            minColdDamage: 0, maxColdDamage: 0,
            minLightningDamage: 3, maxLightningDamage: 32,
            affixes: PoeItem.NoAffixes);

        public const double HypnoticWingDPS = 46.50;
        public const double HypnoticWingPhysicalDPS = 19.38;
        public const double HypnoticWingElementalDPS = 27.12;


        #endregion

        #region CORPSE BLAST

        // Tri-elemental weapon
        public const string CorpseBlastText = @"Rarity: Rare
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

        public static readonly PoeItem CorpseBlast = new PoeItem(
            "Corpse Blast",
            ItemRarity.Rare,
            itemLevel: 59,
            minPhysicalDamage: 19,
            maxPhysicalDamage: 58,
            attackSpeed: 1.55,
            minFireDamage: 27, maxFireDamage: 46,
            minColdDamage: 7, maxColdDamage: 12,
            minLightningDamage: 4, maxLightningDamage: 53,
            affixes: PoeItem.NoAffixes);

        public const double CorpseBlastDPS = 86.80;
        public const double CorpseBlastPhysicalDPS = 30.22;
        public const double CorpseBlastElementalDPS = 56.58;


        #endregion
 
        // Rare weapon with all sorts of stats
        public const string BeastThrasherText = @"Rarity: Rare
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
        public const string BeastThresherName = "Beast Thresher";
        public const double BeastThrasherDPS = 8.08; // Actually 8.075 but we are just doing everything at 2 dp.
    }
}