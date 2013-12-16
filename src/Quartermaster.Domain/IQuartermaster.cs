using System;
using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Domain
{
    /// <summary>
    /// Compositional root and main entry point to the Quartermaster domain.
    /// </summary>
    public interface IQuartermaster: IDisposable
    {
        IPoeItem Item { get; }
        event EventHandler<PoeItemEventArgs> PoeItemArrived;
    }
}