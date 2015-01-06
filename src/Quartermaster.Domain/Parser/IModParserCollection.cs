using System.Collections.Generic;

namespace Mathematically.Quartermaster.Domain.Parser
{
    public interface IModParserCollection
    {
        IEnumerable<IModParser> All { get; }
    }
}