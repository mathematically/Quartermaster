using System.Collections.Generic;
using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Domain.Parser
{
    public interface IModParser
    {
        bool TryParse(int itemLevel, BaseItemType baseItemType, string modText, out IItemMod parsedMod);
    }
}