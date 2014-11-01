using System.ComponentModel;

namespace Mathematically.Quartermaster.Domain.Mods
{
    public enum AffixTierName
    {
        #region Prefixes

        #region Life
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

        #endregion

        #region DamageScaling

        Heavy,
        Serrated,
        Wicked,
        Vicious,
        Bloodthirsty,
        Cruel,
        Tyrannical,

        #endregion

        // There are bow versions of these as well

        #region Cold Damage

        Frosted,
        Chilled,
        [Description("Freezing")] FreezingCrafted,
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
        [Description("Flaming")] FlamingCrafted,
        Burning,
        Flaming,
        Scorching,
        Incinerating,
        Blasting,
        Cremating,

        // Lightning Damage
        Humming,
        Buzzing,
        [Description("Sparking")] SparkingCrafted,
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
        [Description("Glinting")] GlintingCrafted,
        [Description("Polished")] PolishedCrafted,
        Honed,
        Gleaming,
        Annealed,
        RazorSharp,
        Tempered,
        Flaring,

        // Local physical
        [Description("Unknown")] UnknownCrafted,
        [Description("Glinting")] GlintingLocal,
        [Description("Burnished")] BurnishedLocal,
        [Description("Polished")] PolishedLocalCrafted1,
        [Description("Polished")] PolishedLocalCrafted2,
        [Description("Polished")] PolishedLocalCrafted3,
        [Description("Polished")] PolishedLocal,
        [Description("Honed")] HonedLocal1,
        [Description("Honed")] HonedLocal2,
        [Description("Honed")] HonedLocal3,
        [Description("Gleaming")] GleamingLocal,
        [Description("Annealed")] AnnealedLocal,
        [Description("Razor Sharp")] RazorSharpLocal,
        [Description("Tempered")] TemperedLocal,
        [Description("Flaring")] FlaringLocal,

        #endregion

        #endregion

        #region Suffixes

        #region Attack Speed (Local and Global)

        OfSkill,
        OfEase,
        OfMastery,
        OfRenown,
        OfAcclaim,
        OfFame,
        OfInfamy,
        OfGrandmastery,
        OfCelebration,

        #endregion

        #endregion
    }
}