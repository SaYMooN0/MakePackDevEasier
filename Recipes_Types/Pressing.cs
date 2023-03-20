using MDE.Mods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using MDE.Auxiliary_Files;

namespace MDE.Types
{
    internal class Pressing
    {
        TextBox input, output;
        Button createRecipeButton;
        SolidColorBrush orangeBrush;
        string inputStr, outputStr;
        CheckBox chB_Create, chB_Thermal, chB_IE;
        SecondaryWindow newWindow;
        public Pressing()
        {
            orangeBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C2B"));
            input = new TextBox { Height = 40, Width = 260, FontSize = 24, FontWeight = FontWeights.Bold };
            output = new TextBox { Height = 40, Width = 260, FontSize = 24, FontWeight = FontWeights.Bold };
            createRecipeButton = new Button() { Height = 120, Width = 120, FontWeight = FontWeights.Bold, Content = "Create Recipe", HorizontalAlignment = HorizontalAlignment.Center, FontSize = 18, Background = orangeBrush };
            chB_Create = new CheckBox() { Content = "Create", Height = 30, Width = 250, FontSize = 24, FontWeight = FontWeights.Bold, IsChecked = true };
            chB_IE = new CheckBox() { Content = "IE", Height = 30, Width = 250, FontSize = 24, FontWeight = FontWeights.Bold, IsChecked = true };
            chB_Thermal = new CheckBox() { Content = "Thermal", Height = 30, Width = 250, FontSize = 24, FontWeight = FontWeights.Bold, IsChecked = true };
            createRecipeButton.Click += Create_Click;
        }
        public Window getWindow()
        {
            newWindow = new SecondaryWindow();
            Canvas c = (Canvas)newWindow.secondWindow.Content;
            Label inputLabel = new Label() { Height = 50, Width = 260, FontSize = 28, FontWeight = FontWeights.Bold, Content = "input:", HorizontalAlignment = HorizontalAlignment.Center };
            c.Children.Add(input);
            c.Children.Add(inputLabel);
            Canvas.SetLeft(input, 40);
            Canvas.SetTop(input, 80);
            Canvas.SetLeft(inputLabel, 40);
            Canvas.SetTop(inputLabel, 30);
            Label outputLabel = new Label() { Height = 50, Width = 260, FontSize = 28, FontWeight = FontWeights.Bold, Content = "output:", HorizontalAlignment = HorizontalAlignment.Center };
            c.Children.Add(output);
            c.Children.Add(outputLabel);
            Canvas.SetLeft(output, 340);
            Canvas.SetTop(output, 80);
            Canvas.SetLeft(outputLabel, 340);
            Canvas.SetTop(outputLabel, 30);
            c.Children.Add(createRecipeButton);
            Canvas.SetLeft(createRecipeButton, 40);
            Canvas.SetTop(createRecipeButton, 300);
            c.Children.Add(chB_Create);
            Canvas.SetLeft(chB_Create, 40);
            Canvas.SetTop(chB_Create, 140);
            c.Children.Add(chB_IE);
            Canvas.SetLeft(chB_IE, 40);
            Canvas.SetTop(chB_IE, 200);
            c.Children.Add(chB_Thermal);
            Canvas.SetLeft(chB_Thermal, 40);
            Canvas.SetTop(chB_Thermal, 170);
            newWindow.secondWindow.KeyDown += HandleKeyPress;
            newWindow.secondWindow.Content = c;
            return newWindow.secondWindow;

        }
        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftAlt) && Keyboard.IsKeyDown(Key.Enter))
                Create_Click(null, new RoutedEventArgs());
        }
        void Create_Click(object sender, RoutedEventArgs e)
        {
            if (isCorrectInput())
                makeNewRecipe();
            else
                MessageBox.Show("invalid input");
        }
        bool AnyEmptyFields()
        {
            if (!String.IsNullOrEmpty(input.Text) && !String.IsNullOrEmpty(output.Text))
                return false;
            return true;
        }
        bool isCorrectInput()
        {
            if (!AnyEmptyFields())
                return true;
            return false;
        }
        private void makeNewRecipe()
        {
            bool isTag = false;
            string allTheRecipes = "";
            inputStr = input.Text.Substring(1, input.Text.Length - 2);
            outputStr = output.Text.Substring(1, output.Text.Length - 2);
            if (inputStr[0] == '#')
            {
                isTag = true;
                inputStr = inputStr.Substring(1, inputStr.Length - 1);
            }
            if ((bool)chB_Create.IsChecked)
                allTheRecipes += Create.Pressing(inputStr, isTag, outputStr);
            if ((bool)chB_Thermal.IsChecked)
                allTheRecipes += ThermalExpansion.Pressing(inputStr, isTag, outputStr);
            if ((bool)chB_IE.IsChecked)
                allTheRecipes += ImmersiveEngineering.Pressing(inputStr, isTag, outputStr);
            newWindow.writeIntoRecipeTextBox(allTheRecipes);
        }
    }
}
