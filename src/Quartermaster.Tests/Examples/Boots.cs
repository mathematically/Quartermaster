using Mathematically.Quartermaster.Domain.Affixes;
using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Tests.Examples
{
    public class Boots 
    {
        public static readonly Boots Instance = new Boots();

        public const string OblivionTrailText = @"Rarity: Rare
Oblivion Trail
Plated Greaves
--------
Armour: 87 (augmented)
--------
Requirements:
Level: 23
Str: 44
--------
Sockets: R-B-R 
--------
Item Level: 30
--------
30% increased Armour
+47 to maximum Life
8% increased Rarity of Items found
+21% to Lightning Resistance
";

        public static readonly PoeItem OblivionTrail = new PoeItem(
            "Oblivion Trail",
            ItemRarity.Rare,
            30,
            BaseItemType.PlatedGreaves,
            new[]
            {
                new ItemMod(new Life(), "+47 to maximum Life", 47, 30),
                new ItemMod(new LightningResistance(), "+21% to Lightning Resistance", 21, 30),
            }
            );

        public const string PandemoniumSoleText = @"Rarity: Rare
Pandemonium Sole
Mesh Boots
--------
Armour: 60 (augmented)
Energy Shield: 13
--------
Requirements:
Level: 28
Str (gem): 62
Int: 28
--------
Sockets: R-R R G 
--------
Item Level: 28
--------
+10 to Intelligence
+15 to Armour
+48 to maximum Life
18% increased Block and Stun Recovery
";
        public static readonly PoeItem PandemoniumSole = new PoeItem(
            "Pandemonium Sole",
            ItemRarity.Rare,
            28,
            BaseItemType.MeshBoots,
            new[] { new ItemMod(new Life(), "+48 to maximum Life", 48, 28) }
            );

    }
}