using System.Collections.Generic;

namespace Mathematically.Quartermaster.Domain.Mods
{
    public interface IAffixCompendium
    {
        IEnumerable<IAffix> Affixes { get; }
        IAffix GetAffix(AffixType ofType);
    }
}