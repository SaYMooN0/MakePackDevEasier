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

namespace MDE.Types
{
    internal class Filling
    {
        TextBox input, output, fluid, fluidAmount;
        Button createRecipeButton;
        SolidColorBrush orangeBrush;
        string inputStr, outputStr, fluidStr;
        int fluidAmountInt;
        SecondaryWindow newWindow;
        CheckBox chB_Create, chB_Thermal, chB_IF, chB_DoReducing;
        public Filling()
        {
            orangeBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C2B"));
            input = new TextBox { Height = 40, Width = 240, FontSize = 24, FontWeight = FontWeights.Bold };
            output = new TextBox { Height = 40, Width = 240, FontSize = 24, FontWeight = FontWeights.Bold };
            fluid = new TextBox { Height = 40, Width = 340, FontSize = 24, FontWeight = FontWeights.Bold };
            fluidAmount = new TextBox { Height = 40, Width = 140, FontSize = 24, FontWeight = FontWeights.Bold };
            createRecipeButton = new Button() { Height = 120, Width = 120, FontWeight = FontWeights.Bold, Content = "Crete Recipe", HorizontalAlignment = HorizontalAlignment.Center, FontSize = 18, Background = orangeBrush };
            chB_Create = new CheckBox() { Content = "Create", Height = 60, Width = 250, FontSize = 22, FontWeight = FontWeights.Bold, IsChecked = true };
            chB_IF = new CheckBox() { Content = "Industrial Foregoing", Height = 60, Width = 290, FontSize = 22, FontWeight = FontWeights.Bold, IsChecked = true };
            chB_Thermal = new CheckBox() { Content = "Themal Expansion", Height = 60, Width = 290, FontSize = 22, FontWeight = FontWeights.Bold, IsChecked = true };
            chB_DoReducing = new CheckBox() { Content = "Reduce Fluid Consumption?", Height = 60, Width = 310, FontSize = 22, FontWeight = FontWeights.Bold, IsChecked = true };
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
            Canvas.SetTop(input, 120);
            Canvas.SetLeft(inputLabel, 40);
            Canvas.SetTop(inputLabel, 70);
            Label outputLabel = new Label() { Height = 50, Width = 260, FontSize = 28, FontWeight = FontWeights.Bold, Content = "output:", HorizontalAlignment = HorizontalAlignment.Center };
            c.Children.Add(output);
            c.Children.Add(outputLabel);
            Canvas.SetLeft(output, 320);
            Canvas.SetTop(output, 120);
            Canvas.SetLeft(outputLabel, 320);
            Canvas.SetTop(outputLabel, 70);
            Label fluidLabel = new Label() { Height = 50, Width = 360, FontSize = 28, FontWeight = FontWeights.Bold, Content = "fluid:", HorizontalAlignment = HorizontalAlignment.Center };
            c.Children.Add(fluidLabel);
            Canvas.SetLeft(fluidLabel, 600);
            Canvas.SetTop(fluidLabel, 70);
            Label fluidAmountLabel = new Label() { Height = 50, Width = 160, FontSize = 28, FontWeight = FontWeights.Bold, Content = "amount:", HorizontalAlignment = HorizontalAlignment.Center };
            c.Children.Add(fluidAmountLabel);
            Canvas.SetLeft(fluidAmountLabel, 600);
            Canvas.SetTop(fluidAmountLabel, 170);
            c.Children.Add(fluid);
            Canvas.SetLeft(fluid, 600);
            Canvas.SetTop(fluid, 120);
            c.Children.Add(fluidAmount);
            Canvas.SetLeft(fluidAmount, 600);
            Canvas.SetTop(fluidAmount, 220);
            c.Children.Add(createRecipeButton);
            Canvas.SetLeft(createRecipeButton, 40);
            Canvas.SetTop(createRecipeButton, 300);
            newWindow.secondWindow.KeyDown += HandleKeyPress;
            c.Children.Add(chB_DoReducing);
            Canvas.SetLeft(chB_DoReducing, 40);
            Canvas.SetTop(chB_DoReducing, 165);
            c.Children.Add(chB_Create);
            Canvas.SetLeft(chB_Create, 40);
            Canvas.SetTop(chB_Create, 200);
            c.Children.Add(chB_IF);
            Canvas.SetLeft(chB_IF, 40);
            Canvas.SetTop(chB_IF, 235);
            c.Children.Add(chB_Thermal);
            Canvas.SetLeft(chB_Thermal, 40);
            Canvas.SetTop(chB_Thermal, 270);
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
            if (!String.IsNullOrEmpty(input.Text) && !String.IsNullOrEmpty(output.Text) && !String.IsNullOrEmpty(fluid.Text)&& Int32.TryParse(fluidAmount.Text, out fluidAmountInt))
                return true;
            return false;
        }
        private void makeNewRecipe()
        {
            bool isTag = false;
            string allTheRecipes = "";
            inputStr = input.Text.Substring(1, input.Text.Length - 2);
            outputStr = output.Text.Substring(1, output.Text.Length - 2);
            fluidAmountInt = Int32.Parse(fluidAmount.Text);
            fluidStr = fluid.Text.Replace("\'", string.Empty);
            fluidStr = fluid.Text.Replace("\"", string.Empty);
            if (inputStr[0] == '#')
            {
                isTag = true;
                inputStr = inputStr.Substring(1, inputStr.Length - 1);
            }
            if ((bool)chB_Create.IsChecked)
            {
                allTheRecipes += Create.Filling(inputStr, isTag, fluidStr, fluidAmountInt, outputStr);
            }
            if ((bool)chB_DoReducing.IsChecked)
            {
                fluidAmountInt = (int)(0.9* fluidAmountInt);
            }
            if ((bool)chB_Thermal.IsChecked)
            {
                allTheRecipes += ThermalExpansion.Filling(inputStr, isTag, fluidStr, fluidAmountInt, outputStr);
            }
            newWindow.writeIntoRecipeTextBox(allTheRecipes);
        }
    }
}

