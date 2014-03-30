using System.Collections.Generic;

namespace Mathematically.Quartermaster.Domain.Items
{
    public interface IItemModData
    {
        IEnumerable<Affix> Affixes { get; }
    }
}