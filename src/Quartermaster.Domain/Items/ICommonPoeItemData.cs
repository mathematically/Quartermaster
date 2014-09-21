using System;
using System.Collections.Generic;
using System.Linq;
using Mathematically.Quartermaster.Domain.Mods;

namespace Mathematically.Quartermaster.Domain.Items
{
    /// <summary>
    /// The properties every item has regardless of type or level.
    /// </summary>
    public interface ICommonPoeItemData
    {
        string Name { get; }
        ItemRarity Rarity { get; }
        int ItemLevel { get; }
        BaseItemType BaseType { get; }
    }
    
    public enum ItemCategory
    {
        // Weapons
        Bow,
        OneHandAxe,
        TwoHandAxe,
        TwoHandMace,
        Wand,

        // Armour
        Boots,

        // Other
        Amulet,
        Ring,
    }

    public enum BaseItemType
    {
        #region Weapons

        // Bow
        // Note ShortBow can be HeavyShortBow
        CrudeBow, ShortBow, LongBow, CompositeBow, RecurveBow, BoneBow, RoyalBow, DeathBow, GroveBow, CompoundBow,
        SniperBow, IvoryBow, HighbornBow, DecimationBow, ThicketBow, CitadelBow, RangerBow, MarakethBow, SpineBow,
        ImperialBow, HarbingerBow,

        // One hand axes
        RustedHatchet, JadeHatchet, BoardingAxe, Cleaver, BroadAxe, ArmingAxe, DecorativeAxe, SpectralAxe, JasparAxe, 
        Tomahawk, WristChopper, WarAxe, ChestSplitter, CeremonialAxe, WraithAxe, KaruiAxe, SiegeAxe, ReaverAxe, 
        VaalHatcher, RoyalAxe, InfernalAxe,

        // Two hand axes
        StoneAxe, JadeChopper, Woodsplitter, Poleaxe, DoubleAxe, GildedAxe, ShadowAxe, JasperChopper, TimberAxe,
        HeadsmanAxe, Labrys, NobleAxe, AbyssalAxe, KaruiChopper, SunderingAxe, EzomyteAxe, VaalAxe, DespotAxe, VoidAxe,

        // Two Hand Maces
        DriftwoodMaul, TribalMaul, Mallet, Sledgehammer, SpikedMaul, BrassMaul, FrightMaul, TotemicMaul, GreatMallet,
        Steelhead, SpinyMaul, PlatedMaul, DreadMaul, KaruiMaul, ColossusMallet, Piledriver, Meatgrinder, ImperialMaul, 
        TerrorMaul,

        // Wands
        DriftwoodWand, GoatsHorn, CarvedWand, QuartzWand, SpiraledWand, SageWand, FaunsWand, EngravedWand, CrystalWand, 
        SerpentWand, OmenWand, DemonsHorn, ImbuedWand, OpalWand, TornadoWand, ProphecyWand,

        #endregion

        #region Armour

        // Boots
        IronGreaves, WoolShoes, RawhideBoots, ChainBoots, WrappedBoots, LeatherscaleBoots, SteelGreaves, VelvetSlippers,
        GoathideBoots, RingmailBoots, StrappedBoots, IronscaleBoots, DeerskinBoots, SilkSlippers, PlatedGreaves, 
        ClaspedBoots, MeshBoots, BronzescaleBoots, ScholarBoots, ReinforcedGreaves, ShackledBoots, NubukBoots, 
        SteelscaleBoots, RivetedBoots, AntiqueGreaves, SatinSlippers, EelskinBoots, ZealotBoots, TrapperBoots,
        SerpentscaleBoots, SharskinBoots, SamiteSlippers, AncientGreaves, AmbushBoots, SoldierBoots, WyrmscaleBoots,
        ConjurerBoots, GoliathGreaves, ShagreenBoots, CarnalBoots, LegionBoots, HydrascaleBoots, ArcanistSlippers, 
        StealthBoots, VaalGreaves, AssassinsBoots, CrusaderBoots, DragonscaleBoots, SorcererBoots, TitanGreaves,
        MurderBoots, SlinkBoots,


        #endregion

        #region Jewelry

        // Amulet
        PauaAmulet, CoralAmulet, AmberAmulet, LapisAmulet, JadeAmulet, GoldAmulet, AgateAmulet, CitrineAmulet, 
        TurqoiseAmulet, OnyxAmulet,

        // Rings
        // Note there are really three types of twostone depending on elements, although hopefully can avoid that complexity.
        IronRing, CoralRing, PauaRing, RubyRing, GoldRing, TopazRing, SapphireRing, TwoStoneRing,  MoonstoneRing, DiamondRing,
        PrismaticRing, AmethystRing, UnsetRing,

        #endregion
    }

    public class ItemTypeLexicon : IItemLexicon, IModItemLexicon
    {
        private static readonly Dictionary<BaseItemType, ItemCategory> Lexicon = new Dictionary<BaseItemType, ItemCategory>();

        public ItemTypeLexicon()
        {
            var values = Enum.GetValues(typeof (BaseItemType)).Cast<BaseItemType>().ToList();

            // WEAPONS
            values.Where(t => t >= BaseItemType.CrudeBow && t <= BaseItemType.HarbingerBow).ForEach(t => Lexicon.Add(t, ItemCategory.Bow));
            values.Where(t => t >= BaseItemType.RustedHatchet && t <= BaseItemType.InfernalAxe).ForEach(t => Lexicon.Add(t, ItemCategory.OneHandAxe));
            values.Where(t => t >= BaseItemType.StoneAxe && t <= BaseItemType.VoidAxe).ForEach(t => Lexicon.Add(t, ItemCategory.TwoHandAxe));
            values.Where(t => t >= BaseItemType.DriftwoodMaul && t <= BaseItemType.TerrorMaul).ForEach(t => Lexicon.Add(t, ItemCategory.TwoHandMace));
            values.Where(t => t >= BaseItemType.DriftwoodWand && t <= BaseItemType.ProphecyWand).ForEach(t => Lexicon.Add(t, ItemCategory.Wand));

            // ARMOUR
            values.Where(t => t >= BaseItemType.IronGreaves && t <= BaseItemType.SlinkBoots).ForEach(t => Lexicon.Add(t, ItemCategory.Boots));

            // JEWELRY
            values.Where(t => t >= BaseItemType.PauaAmulet && t <= BaseItemType.OnyxAmulet).ForEach(t => Lexicon.Add(t, ItemCategory.Amulet));
            values.Where(t => t >= BaseItemType.IronRing && t <= BaseItemType.UnsetRing).ForEach(t => Lexicon.Add(t, ItemCategory.Ring));
        }

        public ItemCategory GetItemCategory(BaseItemType forBaseType)
        {
            return Lexicon[forBaseType];
        }

        public bool IsValidOnBaseType(IAffix affix, BaseItemType baseItemType)
        {
            throw new NotImplementedException();
        }
    }

    public interface IItemLexicon
    {
        ItemCategory GetItemCategory(BaseItemType forBaseType);
    }

    public interface IModItemLexicon
    {
        bool IsValidOnBaseType(IAffix affix, BaseItemType baseItemType);
    }
}

