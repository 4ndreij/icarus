using Icarus.Core.Interfaces;
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
        IContainer container;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var log4netConfigFile = ConfigurationManager.AppSettings["log4ConfigurationFile"];
            var bootstrapper = new Bootstrapper();
            container = bootstrapper.Bootstrap(log4netConfigFile);
            var logger = container.GetInstance<IAppLogger>();
            logger.LogInfo("App event", "Application Started");
        }

        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            var logger = container.GetInstance<IAppLogger>();
            logger.LogError("Generic app error caught", "Event Application_DispatcherUnhandledException", e.Exception);
        }
    }
}
