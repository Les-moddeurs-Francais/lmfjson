﻿using System;
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

                TextFolderChoose.Content = "Modid : " + mainGenerator.Modid.Replace('_', '-');

                Console.WriteLine("New Path Set : " + fileDialog.SelectedPath);
            }
        }

        /*
         * Gère le choix de model entre block et item 
         */
        private void ModelTypeBox_DropDownClosed(object sender, EventArgs e)
        {
            if (ModelTypeBox.SelectedItem is string)
            {
                string item = ((string)ModelTypeBox.SelectedItem).ToLower();

                if (item.Equals("block"))
                {
                    ModelVariantBox_Item.Visibility = Visibility.Hidden;
                    ModelVariantBox_Block.Visibility = Visibility.Visible;
                    currentMode = (GenerationModes)ModelVariantBox_Block.Items[0];
                }
                else if (item.Equals("item"))
                {
                    ModelVariantBox_Block.Visibility = Visibility.Hidden;
                    ModelVariantBox_Item.Visibility = Visibility.Visible;
                    currentMode = (GenerationModes)ModelVariantBox_Item.Items[0];
                }
            }

        }

        private void ModelVariantBox_Item_DropDownClosed(object sender, EventArgs e)
        {
            currentMode = (GenerationModes)ModelVariantBox_Item.SelectedItem;
        }

        private void ModelVariantBox_Block_DropDownClosed(object sender, EventArgs e)
        {
            currentMode = (GenerationModes)ModelVariantBox_Block.SelectedItem;
        }

        private void ButtonAddModel_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxModelName.Text != "")
            {
                string modelName = TextBoxModelName.Text.ToLower().Replace(' ', '_');
                if (mainGenerator.ModelsToGenerate.ContainsKey(modelName))
                {
                    MessageBox.Show("You've already entered this name !");
                    return;
                }

                mainGenerator.ModelsToGenerate.Add(modelName, currentMode);
                TextBoxModelName.Text = "";
                mainGenerator.OnModelAdd(TextBoxModelsToGenerate, modelName, currentMode);
                PlayClickSound();
            }
            else
            {
                MessageBox.Show("You must enter some name to generate a model !");
            }
        }

        private void ButtonGenerateModels_Click(object sender, RoutedEventArgs e)
        {
            bool success = mainGenerator.GenerateAll();
            if (success)
            {
                mainGenerator.ResetModels(TextBoxModelsToGenerate);
                PlayClickSound();
            }
        }

        private void TextBoxModelName_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                ButtonAddModel_Click(sender, e);
            }
        }
    }

}