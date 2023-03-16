using MDE.Types;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System;
using System.Collections.Generic;
namespace MDE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ChangeContentToCreateRecipe(object sender, RoutedEventArgs e)
        {
            this.ContentFirstLoad.Visibility = Visibility.Hidden;
            this.ContentCreateRecipe.Visibility = Visibility.Visible;
            this.ReturningButton.Visibility = Visibility.Visible;
        }
        private void ChangeContentToContentAddItem(object sender, RoutedEventArgs e)
        {
            this.ContentFirstLoad.Visibility = Visibility.Hidden;
            this.ContentAddItem.Visibility = Visibility.Visible;
            this.ReturningButton.Visibility = Visibility.Visible;
        }
        private void ChangeContentToFirstLoad(object sender, RoutedEventArgs e)
        {
            this.ContentFirstLoad.Visibility = Visibility.Visible;
            this.ContentCreateRecipe.Visibility = Visibility.Hidden;
            this.ContentAddItem.Visibility = Visibility.Hidden;
            this.ReturningButton.Visibility = Visibility.Hidden;
        }
        enum recipeType { Crusher1to1, Crusher1toMany, Polishing, Pressing, Filling, Nothing, SequencedAssembly, Sawmill };
        private void CreateRecipe_Click(object sender, RoutedEventArgs e)
        {
            bool isChosen = true;
            SecondaryWindow secondWindow = new SecondaryWindow();
            Window newRecipeWin = secondWindow.secondWindow;
            Canvas windowContent = new Canvas();
            recipeType myChosenType = chosenType();
            if (myChosenType == recipeType.Nothing)
            {
                MessageBox.Show("Choose recipe type");
                isChosen = false;
            }
            else if (myChosenType == recipeType.Crusher1to1)
            {
                Crusher1to1 c = new Crusher1to1();
                newRecipeWin = c.getWindow();
            }
            else if (myChosenType == recipeType.Crusher1toMany)
            {
                Crusher1ToMany c = new Crusher1ToMany();
                newRecipeWin = c.getWindow();
            }
            else if (myChosenType == recipeType.Polishing)
            {
                Polishing c = new Polishing();
                newRecipeWin = c.getWindow();
            }
            else if (myChosenType == recipeType.Filling)
            {
                Filling c = new Filling();
                newRecipeWin = c.getWindow();
            }
            else if (myChosenType == recipeType.Pressing)
            {
                Pressing c = new Pressing();
                newRecipeWin = c.getWindow();
            }
            else if (myChosenType == recipeType.Sawmill) // WIP
            {
                Sawmill c = new Sawmill();
                newRecipeWin = c.getWindow();
            }
            else if (myChosenType == recipeType.SequencedAssembly) // WIP
            {
                SequencedAssembly c = new SequencedAssembly();
                newRecipeWin = c.getWindow();
            }
            else
            {
                MessageBox.Show("Your recipe type is: " + myChosenType.ToString());
                isChosen = false;
            }
            if (isChosen)
                newRecipeWin.Show();
        }
        private recipeType chosenType()
        {
            if ((bool)Crusher1to1.IsChecked)
                return recipeType.Crusher1to1;
            else if ((bool)Crusher1toMany.IsChecked)
                return recipeType.Crusher1toMany;
            else if ((bool)Polishing.IsChecked)
                return recipeType.Polishing;
            else if ((bool)Pressing.IsChecked)
                return recipeType.Pressing;
            else if ((bool)Filling.IsChecked)
                return recipeType.Filling;
            else if ((bool)SequencedAssembly.IsChecked)
                return recipeType.SequencedAssembly;
            else if ((bool)Sawmill.IsChecked)
                return recipeType.Sawmill;
            else return recipeType.Nothing;

        }
        private void MainWindow_OnDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (var file in files)
                {
                    if (file.EndsWith(".png"))
                    {
                        // Отображение только первого файла
                        SetImage(file);
                        break;
                    }
                }
            }
        }

        private void Image_OnDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (var file in files)
                {
                    if (file.EndsWith(".png"))
                    {
                        SetImage(file);
                        break;
                    }
                }
            }
        }

        private void SetImage(string filePath)
        {
            var bitmap = new BitmapImage(new System.Uri(filePath));
            int ind=filePath.LastIndexOf('\\')+1;
            filePath = filePath.Substring(ind);
            Image.Source = bitmap;
            TB_Name.Text = filePath.Replace(".png", string.Empty);
            TB_Texture.Text = filePath;
        }
        private void AddTagButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("adding tags");
        }
        private void CreateItemButtonClicked(object sender, RoutedEventArgs e)
        {
            if (isCorrectInput())
            {
                MessageBox.Show("Creating item");
            }
            else
                MessageBox.Show("Incorrect input");
        }
        private bool isCorrectInput()
        {
            if (String.IsNullOrEmpty(TB_Name.Text) || String.IsNullOrEmpty(TB_Texture.Text))
                return false;
            return Int32.TryParse(TB_StackSize.Text, out int a);
        }
    }
}
