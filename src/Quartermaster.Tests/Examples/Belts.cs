using System.Collections.Generic;
using System.Linq;
using Mathematically.Quartermaster.Domain;
using Mathematically.Quartermaster.Domain.Affixes;
using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Tests.Examples
{
    public class Belts
    {
        public static readonly Belts Instance = new Belts();

        public const string MaelströmBindText = @"Rarity: Rare
Maelström Bind
Heavy Belt
--------
Requirements:
Level: 57
--------
Item Level: 74
--------
+28 to Strength
--------
+39 to Strength
+84 to maximum Life
+3 to maximum Energy Shield
+44% to Lightning Resistance
+29% to Chaos Resistance
9% increased Flask Life Recovery rate
";

        public static readonly PoeItem MaelströmBind = new PoeItem(
            "Maelström Bind",
            ItemRarity.Rare,
            74,
            BaseItemType.HeavyBelt,
            new[]
            {
                new ItemMod(new Strength(), "+28 to Strength", 28, 74),
                new ItemMod(new Strength(), "+39 to Strength", 39, 74),
                new ItemMod(new Life(), "+84 to maximum Life", 84, 74),
                new ItemMod(new LightningResistance(), "+44% to Lightning Resistance", 44, 74),
                new ItemMod(new ChaosResistance(), "+29% to Chaos Resistance", 29, 74),
            });

        // todo note the implicit mod here.  Need to handle those properly.
        public const string PlagueLocketText = @"        Rarity: Rare
Plague Locket
Rustic Sash
--------
Requirements:
Level: 35
--------
Item Level: 70
--------
18% increased Physical Damage
--------
+75 to Armour
+72 to maximum Life
+20% to Fire Resistance
+9% to Cold Resistance
+16% to Lightning Resistance

";

        public static readonly PoeItem PlagueLocket = new PoeItem(
            "Plague Locket",
            ItemRarity.Rare,
            35,
            BaseItemType.RusticSash,
            new[]
            {
                new ItemMod(new Life(), "+72 to maximum Life", 72, 70),
            });




    }
}