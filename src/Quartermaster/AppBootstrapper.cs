﻿using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using Mathematically.Quartermaster.Domain;
using Mathematically.Quartermaster.Domain.Items;
using Mathematically.Quartermaster.ViewModels;
using Quartermaster.Infrastructure;

namespace Mathematically.Quartermaster
{
    public class AppBootstrapper : Bootstrapper<QuartermasterViewModel>
    {
        private StructureMap.IContainer _container;

        protected override void Configure()
        {
            _container = new StructureMap.Container(x =>
            {
                // Caliburn's window manager so we can specify window options.
                x.For<IWindowManager>().Use<QuartermasterWindowManager>();

                // The composition root for the domain
                x.For<IQuartermaster>().Singleton().Use<QuartermasterStore>();

                // Domain dependencies
                x.For<IItemTextSource>().Use<ClipboardItemTextSource>();
                x.For<IItemTextChecker>().Use<ItemTextChecker>();

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
    }
}