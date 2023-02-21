using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace MDE
{
    internal class Crusher1to1
    {
        TextBox input, output, outputCount, energy, newRecipe;
        Button createRecipeButton,copyToClipboardButton;
        SolidColorBrush backBrush, orangeBrush;
        string inputStr, outputStr;
        double energyDbl;
        int countDbl;
        public Crusher1to1()
        {
            backBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2D384A"));
            orangeBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C2B"));
            input = new TextBox { Height = 40, Width = 260, FontSize = 24, FontWeight = FontWeights.Bold };
            output = new TextBox { Height = 40, Width = 260, FontSize = 24, FontWeight = FontWeights.Bold };
            newRecipe = new TextBox { Height = 120, Width = 730, FontSize = 18, FontWeight = FontWeights.Bold };
            outputCount = new TextBox { Height = 40, Width = 130, FontSize = 24, FontWeight = FontWeights.Bold, Text="1" };
            energy = new TextBox { Height = 40, Width = 130, FontSize = 24, FontWeight = FontWeights.Bold, Text="100" };
            copyToClipboardButton = new Button() { Height = 40, Width = 120, FontWeight = FontWeights.Bold, Content = "Copy", HorizontalAlignment = HorizontalAlignment.Center, FontSize = 18, Background = orangeBrush };
            createRecipeButton = new Button() { Height = 120, Width = 120, FontWeight = FontWeights.Bold, Content = "Crete Recipe", HorizontalAlignment = HorizontalAlignment.Center, FontSize = 18, Background = orangeBrush };
            createRecipeButton.Click += Create_Click;
            copyToClipboardButton.Click += copyToClipboard_Click;

        }
        public  Canvas getWindowContent(Window win)
        {
            Window w = win;
            Canvas c = new Canvas { Height = w.Height, Width = w.Width, Background = backBrush };
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
            //----------------------------------
            Label outputCountLabel = new Label() { Height = 50, Width = 130, FontSize = 28, FontWeight = FontWeights.Bold, Content = "count:", HorizontalAlignment = HorizontalAlignment.Center};
            c.Children.Add(outputCount);
            c.Children.Add(outputCountLabel);
            Canvas.SetLeft(outputCount, 640);
            Canvas.SetTop(outputCount, 220);
            Canvas.SetLeft(outputCountLabel, 640);
            Canvas.SetTop(outputCountLabel, 170);
            //----------------------------------
            Label energyLabel = new Label() { Height = 50, Width = 130, FontSize = 28, FontWeight = FontWeights.Bold, Content = "energy:", HorizontalAlignment = HorizontalAlignment.Center };
            c.Children.Add(energyLabel);
            c.Children.Add(energy);
            Canvas.SetLeft(energy, 800);
            Canvas.SetTop(energy, 220);
            Canvas.SetLeft(energyLabel, 800);
            Canvas.SetTop(energyLabel, 170);
            //---------------------------------
            c.Children.Add(createRecipeButton);
            Canvas.SetLeft(createRecipeButton, 40);
            Canvas.SetTop(createRecipeButton, 300);
            c.Children.Add(newRecipe);
            Canvas.SetLeft(newRecipe, 200);
            Canvas.SetTop(newRecipe, 300);

            c.Children.Add(copyToClipboardButton);
            Canvas.SetLeft(copyToClipboardButton, 810);
            Canvas.SetTop(copyToClipboardButton, 430);
            return c;

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
        void copyToClipboard_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(newRecipe.Text))
                MessageBox.Show("Recipe is empty");
            else
                Clipboard.SetText(newRecipe.Text);
        }
        bool isCorrectInput()
        {
            if (AnyEmptyFields())
                return false;
            if(Double.TryParse(energy.Text, out energyDbl)&& Int32.TryParse(outputCount.Text, out countDbl))
                return true;
            return false;
        }
        private void makeNewRecipe()
        {
            bool isTag = false;
            string allTheRecipes ="";
            inputStr = input.Text.Substring(1, input.Text.Length - 2);
            outputStr = output.Text.Substring(1, output.Text.Length - 2);
            if (inputStr[0] == '#')
            {
                isTag = true;
                inputStr = inputStr.Substring(1, inputStr.Length - 1);
            }
            allTheRecipes +=Create.Crusher1to1(inputStr, isTag, outputStr, countDbl, energyDbl);
            allTheRecipes += ThermalExpansion.Crusher1to1(inputStr, isTag, outputStr, countDbl, energyDbl);
            allTheRecipes += Mekanism.Crusher1to1(inputStr, isTag, outputStr, countDbl);
            allTheRecipes += ImmersiveEngineering.Crusher1to1(inputStr, isTag, outputStr, countDbl, energyDbl);
            newRecipe.Text = allTheRecipes;
        }
    }
}
