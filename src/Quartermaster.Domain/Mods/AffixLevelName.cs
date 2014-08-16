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

    }
}