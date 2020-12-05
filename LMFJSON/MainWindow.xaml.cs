using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

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
        private GenerationModes currentMode { get; set; }


        public MainWindow()
        {
            appdataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            soundPlayer = new MediaPlayer();
            mainGenerator = new src.Generator();
            currentMode = GenerationModes.GENERATED;
            InitializeComponent();
        }

        private void Rectangle_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void TwitterButton_Click(object sender, RoutedEventArgs e)
        {
            PlayClickSound();
            System.Diagnostics.Process.Start("https://www.twitter.com/ZOm__YT");
            this.PlayClickSound();
        }

        private void DiscordButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.discord.gg/E9N4zRF");
            this.PlayClickSound();
        }

        private void YoutubeButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/c/ZomZD");
            this.PlayClickSound();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
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
            System.Windows.Forms.FolderBrowserDialog fileDialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = fileDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                mainGenerator.OutputFolderPath = fileDialog.SelectedPath;
                mainGenerator.OnOutputPathChanged();

                Label modidLabel = (Label)FindName("TextFolderChoose");
                modidLabel.Content = "Modid : " + mainGenerator.Modid;

                Console.WriteLine("New Path Set : " + fileDialog.SelectedPath);
            }
        }

        /*
         * Gère le choix de model entre block et item 
         */
        private void ModelTypeBox_DropDownClosed(object sender, EventArgs e)
        {
            object element = FindName("ModelTypeBox");
            if (element is ComboBox)
            {

                ComboBox box = (ComboBox)element;
                if (box.SelectedItem is string)
                {
                    string item = ((string)box.SelectedItem).ToLower();

                    ComboBox itemBox = (ComboBox) FindName("ModelVariantBox_Item");
                    ComboBox blockBox = (ComboBox) FindName("ModelVariantBox_Block");

                    if (item.Equals("block"))
                    {
                        itemBox.Visibility = Visibility.Hidden;
                        blockBox.Visibility = Visibility.Visible;
                        currentMode = (GenerationModes)blockBox.Items[0];
                    }
                    else if (item.Equals("item"))
                    {
                        blockBox.Visibility = Visibility.Hidden;
                        itemBox.Visibility = Visibility.Visible;
                        currentMode = (GenerationModes)itemBox.Items[0];
                    }
                }
            }
        }

        private void ModelVariantBox_Item_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)FindName("ModelVariantBox_Item");
            currentMode = (GenerationModes)box.SelectedItem;
        }

        private void ModelVariantBox_Block_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)FindName("ModelVariantBox_Block");
            currentMode = (GenerationModes)box.SelectedItem;
        }

        private void ButtonAddModel_Click(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)FindName("TextBoxModelName");
            TextBox textBoxModelsToGenerate = (TextBox)FindName("TextBoxModelsToGenerate");
            if(textBox.Text != "")
            {
                string modelName = textBox.Text.ToLower();
                if(mainGenerator.ModelsToGenerate.ContainsKey(modelName))
                {
                    MessageBox.Show("You've already entered this name !");
                    return;
                }

                mainGenerator.ModelsToGenerate.Add(modelName, currentMode);
                textBox.Text = "";
                mainGenerator.OnModelAdd(textBoxModelsToGenerate, modelName, currentMode);
                PlayClickSound();
            }
            else
            {
                MessageBox.Show("You must enter some name to generate a model !");
            }
        }

        private void ButtonGenerateModels_Click(object sender, RoutedEventArgs e)
        {
            mainGenerator.GenerateAll();
        }

        private void TextBoxModelName_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == System.Windows.Input.Key.Enter)
            {
                ButtonAddModel_Click(sender, e);
            }
        }
    }

}