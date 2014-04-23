using System.Collections.Generic;

namespace Mathematically.Quartermaster.Domain.Items
{
    public interface IItemModData
    {
        IEnumerable<ItemMod> Mods { get; }
    }
}