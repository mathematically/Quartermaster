using System;
using System.Windows.Interop;

namespace Quartermaster.Infrastructure
{
    public interface IClipboardMonitor : IDisposable
    {
        event EventHandler<ClipboardChangedEventArgs> ClipboardTextArrived;
        void BindToVisual(IntPtr hWnd, HwndSource source);
    }
}