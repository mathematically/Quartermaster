using System.Collections.Generic;
using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Domain.Parser
{
    public interface IModParseResult
    {
        bool HasDiscoveredMods { get; }
        IEnumerable<string> RemainingModTextLines { get; }
        IEnumerable<IItemMod> DiscoveredMods { get; }
    }
}