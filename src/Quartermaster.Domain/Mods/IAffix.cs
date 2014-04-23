using System.Collections.Generic;

namespace Mathematically.Quartermaster.Domain.Mods
{
    public interface IAffix
    {
        string MatchText { get; }
        string ValueRegEx { get; }
        IEnumerable<AffixLevel> Levels { get; }
        AffixLevel this[int roll] { get; }
    }
}