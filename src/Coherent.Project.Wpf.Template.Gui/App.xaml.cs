using Coherent.Project.Wpf.Template.Gui;
using Coherent.Project.Wpf.Template.Gui.Views;
using SimpleInjector;
using System.Windows;

namespace Coherent.Project.Wpf.Template
{
    /// <summary>
    ///     Interaction logic for App.xaml
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


            Container container = Bootstrapper.CreateContainer();
            MainWindow mainWindow = container.GetInstance<MainWindow>();
            mainWindow.Show();
        }
    }
}