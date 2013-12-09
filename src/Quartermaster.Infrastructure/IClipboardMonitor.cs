using System;

namespace Quartermaster.Infrastructure
{
    public interface IClipboardMonitor : IDisposable
    {
        event EventHandler<ClipboardChangedEventArgs> ClipboardTextArrived;
    }
}