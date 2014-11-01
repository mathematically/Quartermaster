using System.Collections.Generic;

namespace Mathematically.Quartermaster.Domain.Mods
{
    public interface IAffix
    {
        AffixPosition Position { get; }
        string MatchText { get; }
        string ValueRegEx { get; }
        IEnumerable<AffixTier> Levels { get; }
        AffixTier this[int roll] { get; }
    }
}