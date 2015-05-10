using Mathematically.Quartermaster.Domain.Affixes;
using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Tests.Examples
{
    public class Rings
    {
        public static readonly Rings Instance = new Rings();

        // Pretty much the most basic item possible.
        public const string IronRingText = @"Rarity: Normal
Iron Ring
--------
Itemlevel: 4
--------
Adds 1-4 Physical Damage
";

        public const string IronRingName = "Iron Ring";


        public static readonly PoeItem IronRing = new PoeItem(
            IronRingName,
            ItemRarity.Normal,
            4,
            BaseItemType.IronRing,
            PoeItem.NoAffixes
            );

        // Another simple ring with a level requirement.
        public const string SapphireRingText = @"Rarity: Normal
Sapphire Ring
--------
Requirements:
Level: 16
--------
Itemlevel: 15
--------
+16% to Cold Resistance
";

        public const string SapphireRingName = "Sapphire Ring";

        public static readonly PoeItem SapphireRing = new PoeItem(
            SapphireRingName,
            ItemRarity.Normal,
            15,
            BaseItemType.SapphireRing,
            new[] {new ItemMod(new ColdResistance(), "+16% to Cold Resistance", 16, 15)}
            );

        // A magic ring
        public const string ThirstyRubyRingOfSuccessText = @"Rarity: Magic
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

        public static readonly PoeItem ThirstyRubyRingOfSuccess = new PoeItem(
            "Thirsty Ruby Ring of Success",
            ItemRarity.Magic,
            16,
            BaseItemType.RubyRing,
            new[]
            {
                new ItemMod(new FireResistance(), "+30% to Fire Resistance", 30, 16)
            }
            );

        // A rare ring
        public const string StormTurnText = @"Rarity: Rare
Storm Turn
Ruby Ring
--------
Requirements:
Level: 48
--------
Itemlevel: 63
--------
+27% to Fire Resistance
--------
Adds 3-4 Physical Damage
+31 to Intelligence
Adds 7-11 Cold Damage
+15 to maximum Life
+16% to all Elemental Resistances
+38% to Lightning Resistance
";

        public static readonly PoeItem StormTurn = new PoeItem("Storm Turn", ItemRarity.Rare, 63, BaseItemType.RubyRing,
            new[]
            {
                new ItemMod(new Life(), "+15 to maximum Life", 15, 63),
                new ItemMod(new FireResistance(), "+27% to Fire Resistance", 27, 63),
                new ItemMod(new LightningResistance(),  "+38% to Lightning Resistance", 38, 63),
                new ItemMod(new AllElementsResistance(),  "+16% to all Elemental Resistances", 16, 63),
            }
            );

        // A unique ring
        public const string KaomsSignText = @"Rarity: Unique
Kaom's Sign
Coral Ring
--------
Itemlevel: 6
--------
+24 to maximum Life
--------
+16 to Strength
2% of Physical Attack Damage Leeched as Life
+1 maximum Endurance Charge
--------
A token from the sea
A sign for Kaom
to lead his Karui to Wraeclast.
";

//        public static readonly PoeItem KaomsSign = new PoeItem(
//            "Kaom's Sign",
//            ItemRarity.Unique,
//            6,
//            PoeItem.NoAffixes,
//            new[] { new ItemMod(AffixTierName.KaomsSignLife, "+24 to maximum Life", 24, 40, 0) }
//            );
    }
}