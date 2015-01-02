using System.Collections.Generic;
using System.Linq;
using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Domain.Parser
{
    public class ModParseResult : IModParseResult
    {
        public ModParseResult(IEnumerable<string> remainingModTextLines, IEnumerable<IItemMod> discoveredMods)
        {
            RemainingModTextLines = remainingModTextLines;
            DiscoveredMods = discoveredMods;
        }

        public bool HasDiscoveredMods
        {
            get { return DiscoveredMods.Any(); }
        }

        public IEnumerable<string> RemainingModTextLines { get; private set; }
        public IEnumerable<IItemMod> DiscoveredMods  { get; private set; }
    }
}