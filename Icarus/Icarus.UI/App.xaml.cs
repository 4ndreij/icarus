using Icarus.Core.DroneConfiguration;
using Icarus.Core.Interfaces;
using log4net;
using StructureMap;
using System.Configuration;
using System.Windows;
using System.Windows.Threading;

namespace Icarus.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IContainer Container;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var bootstrapper = new Bootstrapper();
            Container = bootstrapper.Bootstrap(Constants.DroneConfiguration);
        
            Logger.Info("Application Started");
        }

        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Logger.Error("Generic app error - Event Application_DispatcherUnhandledException", e.Exception);
        }

        ILog Logger
        {
            get
            {
                return Container.GetInstance<ILog>();
            }
        }
    }
}
