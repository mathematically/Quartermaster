using System.Collections.Generic;
using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Domain.Parser
{
    public interface IModParser
    {
        IModParseResult TryParse(int itemLevel, BaseItemType baseItemType, IEnumerable<string> modTextLines);
    }
}