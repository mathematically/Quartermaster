using System.Windows;
using System.Windows.Threading;
using NLog;

namespace Mathematically.Quartermaster
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public App()
        {
            Dispatcher.UnhandledException += DispatcherOnUnhandledException;
        }

        private void DispatcherOnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs args)
        {
            args.Handled = true;
            Log.ErrorException("Unhandled exception", args.Exception);
        }
    }
}
