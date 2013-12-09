using System;
using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Domain
{
    public interface IQuartermaster: IDisposable
    {
        IPoeItem Item { get; }
    }
}