using System;
using System.Dynamic;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using Caliburn.Micro;
using Mathematically.Quartermaster.Domain;
using Quartermaster.Infrastructure;

namespace Mathematically.Quartermaster.ViewModels
{
    public class QuartermasterViewModel : ItemViewModel
    {
        private HwndSource _hwndSource;

        private readonly IClipboardMonitor _monitor;
        private readonly IWindowManager _windowManager;

        private readonly HUDViewModel _hud;

        public QuartermasterViewModel(IWindowManager windowManager, IQuartermaster quartermaster, IClipboardMonitor monitor): base(quartermaster)
        {
            _windowManager = windowManager;
            _monitor = monitor;

            _hud = new HUDViewModel(quartermaster);
        }

        protected override void OnViewLoaded(object view)
        {
            // Possibly a better way to do this, but basically we need to be late bound "enough"
            // to get access to the actual window/visual for its hwnd so we can use the clipboard.
            var window = GetView() as Window;
            if (window == null) throw new NullReferenceException("Window is null!?");

            var windowInteropHelper = new WindowInteropHelper(window);
            var hWnd = windowInteropHelper.Handle;

            _hwndSource = PresentationSource.FromVisual(window) as HwndSource;
            _monitor.BindToVisual(hWnd, _hwndSource);

            base.OnViewLoaded(view);
        }

        public void HUD()
        {
            if (_hud.IsActive)
            {
                CloseHUD();
            }
            else
            {
                OpenHUD();
            }
        }

        private void OpenHUD()
        {
            dynamic settings = new ExpandoObject();

            settings.WindowStyle = WindowStyle.None;
            settings.Left = 10;
            settings.Top = 10;
            settings.Topmost = true;
            settings.AllowsTransparency = true;
            settings.Background = Brushes.Transparent;
            settings.SizeToContent = SizeToContent.WidthAndHeight;
            settings.ShowInTaskbar = false;

            _windowManager.ShowWindow(_hud, null, settings);
        }

        private void CloseHUD()
        {
            _hud.TryClose();
        }

        protected override void OnDeactivate(bool close)
        {
            if (close)
            {
                CloseHUD();
            }
        }
    }
}