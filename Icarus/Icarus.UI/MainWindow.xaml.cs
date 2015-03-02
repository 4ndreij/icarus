using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Icarus.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string onlineImagePath = @"\Images\online.png";
        const string offlineImagePath = @"\Images\offline.png";

        const string upCommandMessage = "Go Up";
        const string downCommandMessage = "Go Down";
        const string leftCommandMessage = "Go Left";
        const string rightCommandMessage = "Go Right";
        const string fwdCommandMessage = "Go Forward";
        const string bwdCommandMessage = "Go Backward";

        public MainWindow()
        {
            InitializeComponent();
            ToggleButtonsState(false);
        }

        void ToggleButtonsState(bool enabled)
        {
            btnUp.IsEnabled = enabled;
            btnDown.IsEnabled = enabled;
            btnRight.IsEnabled = enabled;
            btnLeft.IsEnabled = enabled;
            btnForward.IsEnabled = enabled;
            btnBackward.IsEnabled = enabled;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            //var commandFactory = 
            //var startCommand = 

            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;

            SetDroneConnectionImage(onlineImagePath);
            ToggleButtonsState(true);
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            btnStop.IsEnabled = false;
            btnStart.IsEnabled = true;

            SetDroneConnectionImage(offlineImagePath);
            ToggleButtonsState(false);
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

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            AddCommandToList(upCommandMessage);
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            AddCommandToList(downCommandMessage);
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            AddCommandToList(leftCommandMessage);
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            AddCommandToList(rightCommandMessage);
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            AddCommandToList(fwdCommandMessage);
        }

        private void btnBackward_Click(object sender, RoutedEventArgs e)
        {
            AddCommandToList(bwdCommandMessage);
        }

        void AddCommandToList(string commandMessage)
        {
            lstMessageWindow.Items.Add(commandMessage + " - " + DateTime.Now.ToString());
            lstMessageWindow.SelectedIndex = lstMessageWindow.Items.Count - 1;
            lstMessageWindow.ScrollIntoView(lstMessageWindow.SelectedItem);

        }
    }
}
