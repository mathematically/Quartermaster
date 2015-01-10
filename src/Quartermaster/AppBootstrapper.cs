using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Caliburn.Micro;
using Mathematically.Quartermaster.Domain;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.Domain.Mods;
using Mathematically.Quartermaster.Domain.Parser;
using Mathematically.Quartermaster.ViewModels;
using Quartermaster.Infrastructure;

namespace Mathematically.Quartermaster
{
    public class AppBootstrapper : BootstrapperBase
    {
        private StructureMap.IContainer _container;

        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container = new StructureMap.Container(x =>
            {
                // Caliburn's window manager so we can specify window options.
                x.For<IWindowManager>().Singleton().Use<QuartermasterWindowManager>();

                // The composition root for the domain
                x.For<IQuartermaster>().Singleton().Use<QuartermasterStore>();

                // Domain dependencies
                x.For<IAffixCompendium>().Singleton().Use<AffixCompendium>();
                x.For<IModParserCollection>().Singleton().Use<ModParsers>();
                x.For<IItemLexicon>().Singleton().Use<ItemTypeLexicon>();
                x.For<IItemTextSource>().Use<ClipboardItemTextSource>();
                x.For<IItemTextChecker>().Use<ItemTextChecker>();
                x.For<IPoeItemFactory>().Use<PoeItemFactory>();
                x.For<IPoeItemParser>().Use<PoeItemParser>();

                // Infrastructure objects.
                x.For<IClipboardMonitor>().Singleton().Use<ClipboardMonitor>();
            });
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            return string.IsNullOrEmpty(key)
                ? _container.GetInstance(serviceType)
                : _container.GetInstance(serviceType ?? typeof (object), key);
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.GetAllInstances(serviceType).Cast<object>();
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            base.OnStartup(sender, e);
            DisplayRootViewFor<QuartermasterViewModel>();
        }
    }
}