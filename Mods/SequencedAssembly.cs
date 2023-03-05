using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;

namespace MDE.Mods
{
    internal class SequencedAssembly
    {
        Button createRecipeButton;
        SolidColorBrush orangeBrush;
        SecondaryWindow newWindow;
        ComboBox[]  ComboBoxes= new ComboBox[8];
        TextBox TB_Loops;
        Label Sawmill, Pressing, Filling, Polishing, AddingItem, Label_Loops;
        public SequencedAssembly()
        {
            orangeBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C2B"));
            SolidColorBrush whiteBrush = new SolidColorBrush(Colors.White);
            Sawmill = new Label { Height = 35, Width = 140, FontSize = 16, FontWeight = FontWeights.Bold, Content="Sawmill" };
            Pressing = new Label { Height = 35, Width = 140, FontSize = 16, FontWeight = FontWeights.Bold, Content= "Pressing" };
            Filling = new Label { Height = 35, Width = 140, FontSize = 16, FontWeight = FontWeights.Bold, Content= "Filling" };
            Polishing = new Label { Height = 35, Width = 140, FontSize = 16, FontWeight = FontWeights.Bold, Content= "Polishing" };
            AddingItem = new Label { Height = 35, Width = 140, FontSize = 16, FontWeight = FontWeights.Bold, Content= "AddingItem" };
            TB_Loops = new TextBox {Height=24, Width= 28, FontSize=18, FontWeight=FontWeights.Bold };
            Label_Loops = new Label { Height = 40, Width = 180, FontSize = 18, FontWeight = FontWeights.Bold, Content="Number of loops:", Foreground=whiteBrush};
            createRecipeButton = new Button() { Height = 120, Width = 120, FontWeight = FontWeights.Bold, Content = "Crete Recipe", HorizontalAlignment = HorizontalAlignment.Center, FontSize = 18, Background = orangeBrush };
            createRecipeButton.Click += Create_Click;
        }
        public Window getWindow()
        {
            newWindow = new SecondaryWindow();
            Canvas c = (Canvas)newWindow.secondWindow.Content;
            c.Children.Add(Label_Loops);
            Canvas.SetLeft(Label_Loops, 40);
            Canvas.SetTop(Label_Loops, 30);
            c.Children.Add(TB_Loops);
            Canvas.SetLeft(TB_Loops, 210);
            Canvas.SetTop(TB_Loops, 36);
            for (int i = 0; i < 8; i++)
            {
                ComboBox cB = new ComboBox { Height = 35, Width = 200, FontWeight = FontWeights.Bold, HorizontalAlignment = HorizontalAlignment.Center, FontSize = 18, Text = "Choose type:" };
                Sawmill = new Label { Height = 35, Width = 180, FontSize = 16, FontWeight = FontWeights.Bold, Content = "Sawmill" };
                Pressing = new Label { Height = 35, Width = 180, FontSize = 16, FontWeight = FontWeights.Bold, Content = "Pressing" };
                Filling = new Label { Height = 35, Width = 180, FontSize = 16, FontWeight = FontWeights.Bold, Content = "Filling" };
                Polishing = new Label { Height = 35, Width = 180, FontSize = 16, FontWeight = FontWeights.Bold, Content = "Polishing" };
                AddingItem = new Label { Height = 35, Width = 180, FontSize = 16, FontWeight = FontWeights.Bold, Content = "AddingItem" };
                cB.Items.Refresh();
                cB.Items.Add(Pressing);
                cB.Items.Add(Sawmill);
                cB.Items.Add(Filling);
                cB.Items.Add(Polishing);
                cB.Items.Add(AddingItem);
                cB.SelectionChanged += SelectionChanged;
                ComboBoxes[i] = cB;
                c.Children.Add(ComboBoxes[i]);
                if (i < 4)
                {
                    Canvas.SetLeft(ComboBoxes[i], 40);
                    Canvas.SetTop(ComboBoxes[i], (60 * (i) + 80));
                }
                else
                {
                    Canvas.SetLeft(ComboBoxes[i], 540);
                    Canvas.SetTop(ComboBoxes[i], (60 * (i-4) + 80));
                }
               
            }
            //c.Children.Add(Exapmle);
            //Canvas.SetLeft(Exapmle, 100);
            //Canvas.SetTop(Exapmle, 100);
            c.Children.Add(createRecipeButton);
            Canvas.SetLeft(createRecipeButton, 40);
            Canvas.SetTop(createRecipeButton, 300);
            newWindow.secondWindow.KeyDown += HandleKeyPress;
            newWindow.secondWindow.Content = c;
            return newWindow.secondWindow;

        }
        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender != null)
            {
                ComboBox cB = sender as ComboBox;
                Label l = cB.SelectedItem as Label;
                string str = l.Content.ToString();
                if (str== "Filling")
                {

                }
                else if (str == "AddingItem")
                {
                    MessageBox.Show("adding item");
                }
                    
            }
        }
        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.Enter))
                Create_Click(null, new RoutedEventArgs());
        }
        void Create_Click(object sender, RoutedEventArgs e)
        {
            //if (isCorrectInput())
            //    makeNewRecipe();
            //else
            //    MessageBox.Show("invalid input");
        }
        //bool isCorrectInput()
        //{
        //    if (!String.IsNullOrEmpty(input.Text) && !String.IsNullOrEmpty(output.Text) && !String.IsNullOrEmpty(fluid.Text) && Int32.TryParse(fluidAmount.Text, out fluidAmountInt))
        //        return true;
        //    return false;
        //}
        //private void makeNewRecipe()
        //{
        //    bool isTag = false;
        //    string allTheRecipes = "";
        //    inputStr = input.Text.Substring(1, input.Text.Length - 2);
        //    outputStr = output.Text.Substring(1, output.Text.Length - 2);
        //    fluidAmountInt = Int32.Parse(fluidAmount.Text);
        //    fluidStr = fluid.Text.Replace("\'", string.Empty);
        //    fluidStr = fluid.Text.Replace("\"", string.Empty);
        //    if (inputStr[0] == '#')
        //    {
        //        isTag = true;
        //        inputStr = inputStr.Substring(1, inputStr.Length - 1);
        //    }
        //    if ((bool)chB_Create.IsChecked)
        //    {
        //        allTheRecipes += Create.Filling(inputStr, isTag, fluidStr, fluidAmountInt, outputStr);
        //    }
        //    if ((bool)chB_DoReducing.IsChecked)
        //    {
        //        fluidAmountInt = (int)(0.9 * fluidAmountInt);
        //    }
        //    if ((bool)chB_Thermal.IsChecked)
        //    {
        //        allTheRecipes += ThermalExpansion.Filling(inputStr, isTag, fluidStr, fluidAmountInt, outputStr);
        //    }
        //    if ((bool)chB_IF.IsChecked)
        //    {
        //        allTheRecipes += IndustrialForegoing.Filling(inputStr, isTag, fluidStr, fluidAmountInt, outputStr);
        //    }
        //    newWindow.writeIntoRecipeTextBox(allTheRecipes);
        //}
    }
}