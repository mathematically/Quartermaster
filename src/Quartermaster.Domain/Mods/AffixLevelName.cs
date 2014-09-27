using System.ComponentModel;

namespace Mathematically.Quartermaster.Domain.Mods
{
    public enum AffixPosition
    {
        Prefix, Suffix
    }

    public enum AffixType
    {
        Life, DamageScaling
    }

    public enum AffixLevelName
    {
        // Life
        Healthy,
        Sanguine,
        Stalwart,
        Stout,
        Robust,
        Rotund,
        Virile,
        Athletes,
        Fecund,
        Vigorous,

        KaomsSignLife,

        // Damage Scaling
        Heavy,
        Serrated,
        Wicked,
        Vicious,
        Bloodthirsty,
        Cruel,
        Tyrannical,

        // There are bow versions of these as well

        // Cold Damage
        Frosted,
        Chilled,
        [Description("Freezing")]
        FreezingCrafted,
        Icy,
        Frigid,
        Freezing,
        Frozen,
        Glaciated,
        Polar,
        Entombing,

        // Fire Damage
        Heated,
        Smouldering,
        Smoking,
        [Description("Flaming")]
        FlamingCrafted,
        Burning,
        Flaming,
        Scorching,
        Incinerating,
        Blasting,
        Cremating,

        // Lightning Damage
        Humming,
        Buzzing,
        [Description("Sparking")]
        SparkingCrafted,
        Snapping,
        Crackling,
        Sparking,
        Arcing,
        Shocking,
        Discharging,
        Electrocuting,

        // Physical
        Glinting,
        Burnished,
        Polished,
        [Description("Glinting")]
        GlintingCrafted,
        [Description("Polished")]
        PolishedCrafted,
        Honed,
        Gleaming,
        Annealed,
        RazorSharp,
        Tempered,
        Flaring,

        // Local physical
        [Description("Unknown")]
        UnknownCrafted,
        [Description("Glinting")]
        GlintingLocal,
        [Description("Burnished")]
        BurnishedLocal,
        [Description("Polished")]
        PolishedLocalCrafted1,
        [Description("Polished")]
        PolishedLocalCrafted2,
        [Description("Polished")]
        PolishedLocalCrafted3,
        [Description("Polished")]
        PolishedLocal,
        [Description("Honed")]
        HonedLocal1,
        [Description("Honed")]
        HonedLocal2,
        [Description("Honed")]
        HonedLocal3,
        [Description("Gleaming")]
        GleamingLocal,
        [Description("Annealed")]
        AnnealedLocal,
        [Description("Razor Sharp")]
        RazorSharpLocal,
        [Description("Tempered")]
        TemperedLocal,
        [Description("Flaring")]
        FlaringLocal,
    }
}