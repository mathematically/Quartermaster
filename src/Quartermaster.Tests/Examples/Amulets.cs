using Mathematically.Quartermaster.Domain.Affixes;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Domain.Mods;

namespace Mathematically.Quartermaster.Tests.Examples
{
    public static class Amulets
    {
        // Basic rare amulet
        internal const string HorrorMedallionText = @"Rarity: Rare
Horror Medallion
Jade Amulet
--------
Requirements:
Level: 5
--------
Itemlevel: 7
--------
+22 to Dexterity
--------
Adds 1-2 Physical Damage
+9 to Strength
+9 to Dexterity
+11% to Cold Resistance
";
        public static readonly PoeItem HorrorMedallion = new PoeItem("Horror Medallion", ItemRarity.Rare, 7, BaseItemType.JadeAmulet, new[] { new ItemMod(new ColdResistance(), "+11% to Cold Resistance", 11, 7) });
    }
}