using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Icarus.Core.Enums;
using Icarus.Core.Interfaces;
using System.Windows;

namespace Icarus.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly WindowMessages messages;
        readonly IInputProviderAdapter inputProviderAdapter;
        private readonly Dispatcher dispatcher;

        public MainWindow()
        {
            InitializeComponent();
            messages = new WindowMessages();
            dispatcher = Application.Current.MainWindow.Dispatcher;
            inputProviderAdapter = App.Container.GetInstance<IInputProviderAdapter>();
            inputProviderAdapter.OnCommandProcessed += inputProviderAdapter_OnCommandProcessed;
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
    }
}
