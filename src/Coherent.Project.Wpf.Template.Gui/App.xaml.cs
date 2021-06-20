using Coherent.Project.Wpf.Template.Gui;
using Coherent.Project.Wpf.Template.Gui.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Coherent.Project.Wpf.Template
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //var builder = Bootstrapper.CreateBuilder();

            //using (var container = builder.Build())
            //{
            //    //var autofacResolver = container.Resolve<AutofacDependencyResolver>();

            //    //// Set a lifetime scope (either the root or any of the child ones) to Autofac resolver
            //    //// This is needed, because the previous steps did not Update the ContainerBuilder since they became immutable in Autofac 5+
            //    //// https://github.com/autofac/Autofac/issues/811
            //    //autofacResolver.SetLifetimeScope(container);

            //    var mainWindow = container.Resolve<MainWindow>();
            //    mainWindow.Show();
            //}



            var container = Bootstrapper.CreateContainer();
            var mainWindow = container.GetInstance<MainWindow>();
            mainWindow.Show();


        }
    }
}
