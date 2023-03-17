using MDE.Mods;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MDE
{
    internal class Polishing
    {
        TextBox input, output;
        Button createRecipeButton;
        SolidColorBrush orangeBrush;
        string inputStr, outputStr;
        SecondaryWindow newWindow;
        public Polishing()
        {
            orangeBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C2B"));
            input = new TextBox { Height = 40, Width = 260, FontSize = 24, FontWeight = FontWeights.Bold };
            output = new TextBox { Height = 40, Width = 260, FontSize = 24, FontWeight = FontWeights.Bold };
            createRecipeButton = new Button() { Height = 120, Width = 120, FontWeight = FontWeights.Bold, Content = "Create Recipe", HorizontalAlignment = HorizontalAlignment.Center, FontSize = 18, Background = orangeBrush };
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
            Canvas.SetTop(input, 220);
            Canvas.SetLeft(inputLabel, 40);
            Canvas.SetTop(inputLabel, 170);
            Label outputLabel = new Label() { Height = 50, Width = 260, FontSize = 28, FontWeight = FontWeights.Bold, Content = "output:", HorizontalAlignment = HorizontalAlignment.Center };
            c.Children.Add(output);
            c.Children.Add(outputLabel);
            Canvas.SetLeft(output, 340);
            Canvas.SetTop(output, 220);
            Canvas.SetLeft(outputLabel, 340);
            Canvas.SetTop(outputLabel, 170);
            c.Children.Add(createRecipeButton);
            Canvas.SetLeft(createRecipeButton, 40);
            Canvas.SetTop(createRecipeButton, 300);
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
        bool isCorrectInput()
        {
            if (!String.IsNullOrEmpty(input.Text) && !String.IsNullOrEmpty(output.Text))
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
            allTheRecipes += Create.Polishing(inputStr, isTag, outputStr);
            allTheRecipes += Mekanism.Polishing(inputStr, isTag, outputStr);
            newWindow.writeIntoRecipeTextBox(allTheRecipes);
        }
    }
}
