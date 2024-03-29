namespace DockingTempate {
    using System;
    using System.Collections.Generic;
    using Caliburn.Micro;
    using DockingTempate.Factory;
    using DockingTempate.Factory.Interfaces;
    using DockingTempate.ViewModels;
    using DockingTempate.ViewModels.Interfaces;

    public class AppBootstrapper : BootstrapperBase
    {
        SimpleContainer container;

        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            container = new SimpleContainer();

            container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<IDataFactory, DataFactory>()
                .Singleton<IPaneViewModelFactory, PaneViewModelFactory>()
                .Singleton<IExplorerViewModel, ExplorerViewModel>()
                .Singleton<IShellViewModel, ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<IShellViewModel>();
        }
    }
}