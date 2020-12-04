using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Forms;

namespace LMFJSON
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {

        private MediaPlayer soundPlayer { get; set; }
        private string appdataPath { get; set; }
        internal src.Generator mainGenerator { get; set; }


        public MainWindow()
        {
            appdataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            soundPlayer = new MediaPlayer();
            mainGenerator = new src.Generator();
            InitializeComponent();
        }

        private void Rectangle_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void TwitterButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PlayClickSound();
            System.Diagnostics.Process.Start("https://www.twitter.com/ZOm__YT");
            this.PlayClickSound();
        }

        private void DiscordButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.discord.gg/E9N4zRF");
            this.PlayClickSound();
        }

        private void YoutubeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/c/ZomZD");
            this.PlayClickSound();
        }

        private void CloseButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //Fermeture de l'application
            this.PlayClickSound();
            this.Close();
        }

        private void PlayClickSound()
        {
            this.soundPlayer.Open(new Uri("Resources/assets/sounds/click_sound.wav", UriKind.Relative));
            this.soundPlayer.Play();
        }

        private void ButtonFileChoose_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fileDialog = new FolderBrowserDialog();
            DialogResult result = fileDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                mainGenerator.OutputFolderPath = fileDialog.SelectedPath;
                Console.WriteLine("New Path Set : " + fileDialog.SelectedPath);
            }
        }
    }

}