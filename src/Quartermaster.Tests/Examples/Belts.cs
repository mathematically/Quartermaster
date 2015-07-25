using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using Mathematically.Quartermaster.Domain;
using Mathematically.Quartermaster.Domain.Affixes;
using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Tests.Examples
{
    public class Mods
    {
        private readonly ItemMod[] _mods;

        public Mods(ItemMod[] mods)
        {
            _mods = mods;
        }

        public ItemMod[] Sorted
        {
            get
            {
                var sorted = new SortedList<string, ItemMod>();

                _mods.ForEach(m =>
                {
                    // meg, change it if there can ever be three
                    var key = m.Affix.AffixName + 1;
                    if (sorted.ContainsKey(key))
                    {
                        key = m.Affix.AffixName + 2;
                    }

                    sorted.Add(key, m);
                });

                return sorted.Values.ToArray();
            }
        }
    }

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
            new Mods(new[]
            {
                new ItemMod(new Strength(), "+28 to Strength", 28, 74),
                new ItemMod(new Strength(), "+39 to Strength", 39, 74),
                new ItemMod(new Life(), "+84 to maximum Life", 84, 74),
                new ItemMod(new LightningResistance(), "+44% to Lightning Resistance", 44, 74),
                new ItemMod(new ChaosResistance(), "+29% to Chaos Resistance", 29, 74),
            }).Sorted
            );
    }
}