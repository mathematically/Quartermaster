using System;
using System.Dynamic;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using Caliburn.Micro;
using Mathematically.Quartermaster.Domain;
using Mathematically.Quartermaster.Domain.Items;
using Quartermaster.Infrastructure;

namespace Mathematically.Quartermaster.ViewModels
{
    public class QuartermasterViewModel : Screen, IDisposable
    {
        private HwndSource _hwndSource;

        private readonly IClipboardMonitor _monitor;
        private readonly IWindowManager _windowManager;
        private readonly IQuartermaster _quartermaster;
        private IPoeItem _item;

        public QuartermasterViewModel(IWindowManager windowManager, IQuartermaster quartermaster, IClipboardMonitor monitor)
        {
            _windowManager = windowManager;
            _quartermaster = quartermaster;
            _monitor = monitor;

            Item = quartermaster.Item;

            _quartermaster.PoeItemArrived += NewItemArrived;
        }

        protected override void OnViewLoaded(object view)
        {
            // Possibly a better way to do this in StructureMap? Basically we need to be late bound "enough"
            // to get access to the actual window/visual for its hwnd so we can use the clipboard.
            var window = GetView() as Window;
            if (window == null) throw new NullReferenceException("Window is null!?");

            var windowInteropHelper = new WindowInteropHelper(window);
            var hWnd = windowInteropHelper.Handle;

            _hwndSource = PresentationSource.FromVisual(window) as HwndSource;
            _monitor.BindToVisual(hWnd, _hwndSource);

            base.OnViewLoaded(view);
        }

        void NewItemArrived(object sender, PoeItemEventArgs e)
        {
            Item = e.PoeItem;
        }

        public IPoeItem Item
        {
            get { return _item; }
            private set
            {
                _item = value;
                NotifyOfPropertyChange(() => Item);
            }
        }

        public void HUD( )
        {
            dynamic settings = new ExpandoObject();

            settings.WindowStyle = WindowStyle.None;
            settings.Left = 10;
            settings.Top = 10;
            settings.AllowsTransparency = true;
            settings.Background = Brushes.Transparent;
            settings.SizeToContent = SizeToContent.WidthAndHeight;

            _windowManager.ShowWindow(new HUDViewModel(_quartermaster), null, settings);
        }

        public void Dispose()
        {
            _quartermaster.PoeItemArrived -= NewItemArrived;

            _hwndSource.Dispose();
            _quartermaster.Dispose();
        }
    }
}