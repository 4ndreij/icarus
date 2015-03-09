using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Icarus.Core.Enums;
using Icarus.Core.Interfaces;
using System.Windows;
using Icarus.Infrastructure.ProviderLoader;
using Icarus.Infrastructure.ProviderLoader.ProviderLoaderExceptions;
using Microsoft.Win32;
using AR.Drone.Client;

namespace Icarus.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IInputProviderAdapter inputProviderAdapter;
        private readonly Dispatcher dispatcher;

        public MainWindow()
        {
            InitializeComponent();

            dispatcher = Application.Current.MainWindow.Dispatcher;
        }

        void inputProviderAdapter_OnCommandProcessed(object sender, Core.EventArguments.ProcessedCommandArgs e)
        {
            switch (e.CommandType)
            {
                case CommandType.Start:
                    dispatcher.BeginInvoke(new Action(() =>
                                                          {
                                                              lstMessageWindow.Items.Add("Start...");
                                                              SetDroneConnectionImage(Constants.OnlineImagePath);
                                                          }));
                    break;
                case CommandType.Stop:
                    dispatcher.BeginInvoke(new Action(() =>
                                                          {
                                                              lstMessageWindow.Items.Add("Stop...");
                                                              SetDroneConnectionImage(Constants.OfflineImagePath);
                                                          }));
                    break;
                    case CommandType.Hover:
                    dispatcher.BeginInvoke(new Action(() => lstMessageWindow.Items.Add("Hovering....")));
                    break;
                    case CommandType.MoveBackward:
                    dispatcher.BeginInvoke(new Action(() => lstMessageWindow.Items.Add("Moving backward....")));
                    break;  
                    case CommandType.MoveDown:
                    dispatcher.BeginInvoke(new Action(() => lstMessageWindow.Items.Add("Descending....")));
                    break;
                    case CommandType.MoveForward:
                    dispatcher.BeginInvoke(new Action(() => lstMessageWindow.Items.Add("Moving forward...")));
                    break;
                    case CommandType.MoveLeft:
                    dispatcher.BeginInvoke(new Action(() => lstMessageWindow.Items.Add("Moving left...")));
                    break;
                    case CommandType.MoveRight:
                    dispatcher.BeginInvoke(new Action(() => lstMessageWindow.Items.Add("Moving right...")));
                    break;
                    case CommandType.MoveUp:
                    dispatcher.BeginInvoke(new Action(() => lstMessageWindow.Items.Add("Ascending...")));
                    break;
            }
        }

        void SetDroneConnectionImage(string imagePath)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var image = Image.FromFile(currentDirectory + imagePath);
            var imageMem = new MemoryStream();
            image.Save(imageMem, ImageFormat.Png);
            var bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.StreamSource = new MemoryStream(imageMem.ToArray());
            bmp.EndInit();
            imgConnectionStatus.Source = bmp;
        }

        private void btnLoadProvider_Click(object sender, RoutedEventArgs e)
        {
            var fileName = FileDialog();
            LoadAndSetupProvider(fileName);
        }

        private void LoadAndSetupProvider(string path)
        {
            try
            {
                var providerLoaderAgent = new ProviderLoaderAgent<IInputProvider>(path);
                var inputProviderType = providerLoaderAgent.GetInputProvider();
                var inputProvider = (IInputProvider)Activator.CreateInstance(inputProviderType);
                
                App.Container.Configure(x => x.For<IInputProvider>()
                    .Use(t => inputProvider));

                inputProviderAdapter = App.Container.GetInstance<IInputProviderAdapter>();
                inputProviderAdapter.SubscribeInputProvider(inputProvider);
                inputProviderAdapter.OnCommandProcessed += inputProviderAdapter_OnCommandProcessed;

                lblProvider.Content = inputProviderType.FullName;
            }
            catch (AssemblyNotSupportedException assemblyNotSupportedException)
            {
                MessageBox.Show(string.Format("The assembly on path \"{0}\" could not be loaded.", assemblyNotSupportedException.Path));
            }
            catch (ProviderNotFoundException providerNotFoundException)
            {
                MessageBox.Show(string.Format("The assembly \"{0}\" on path \"{1}\" does not contain a valid input provider.", providerNotFoundException.Assembly.FullName,
                                              providerNotFoundException.Path));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Other blaaa:" + ex);
            }
        }

        private void btnLoadDrone_Click(object sender, RoutedEventArgs e)
        {
            var fileName = FileDialog();
            LoadAndSetupDrone(fileName);
        }

        string FileDialog()
        {
            var openFileDialog = new OpenFileDialog
            {
                Multiselect = false
            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                return openFileDialog.FileName;
            }
            return null;
        }

        void LoadAndSetupDrone(string path)
        {
            try
            {
                var providerLoaderAgent = new ProviderLoaderAgent<IDrone>(path);
                var droneProvider = providerLoaderAgent.GetInputProvider();
                var droneClient = App.Container.GetInstance<DroneClient>();
                var drone = (IDrone)Activator.CreateInstance(droneProvider, droneClient);

                App.Container.Configure(x => x.For<IDrone>().Use(t => drone));

                lblDrone.Content = droneProvider.FullName;
            }
            catch (AssemblyNotSupportedException assemblyNotSupportedException)
            {
                MessageBox.Show(string.Format("The assembly on path \"{0}\" could not be loaded.", assemblyNotSupportedException.Path));
            }
            catch (ProviderNotFoundException providerNotFoundException)
            {
                MessageBox.Show(string.Format("The assembly \"{0}\" on path \"{1}\" does not contain a valid drone.", providerNotFoundException.Assembly.FullName,
                                              providerNotFoundException.Path));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Other blaaa blaaa blaaa:" + ex);
            }
        }
    }
}
