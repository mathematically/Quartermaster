using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using Caliburn.Micro;

namespace Mathematically.Quartermaster
{
// ReSharper disable once ClassNeverInstantiated.Global
    public class QuartermasterWindowManager : WindowManager
    {
        protected override Window CreateWindow(object rootModel, bool isDialog, object context,
            IDictionary<string, object> settings)
        {
            var options = new Dictionary<string, object>
            {
                {"Title", "Quartermaster v" + Assembly.GetExecutingAssembly().GetName().Version},
                {"WindowStyle", WindowStyle.ToolWindow},
                {"MinWidth", 300},
                {"MinHeight", 300},
            };

            return base.CreateWindow(rootModel, isDialog, context, options);
        }
    }
}