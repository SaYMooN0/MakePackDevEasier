using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Collections.Generic;
using MDE.Mods;
using System.Windows.Input;

namespace MDE
{
    internal class Crusher1ToMany
    {
        TextBox input, output1, output2, output3, output4, outputCount1, outputCount2, outputCount3, outputCount4, energy;
        string inputStr;
        double energyDbl;
        List<Tuple<string, double>> outputs=new List<Tuple<string, double>>();
        CheckBox chB_Create, chB_Thermal, chB_IE;
        SecondaryWindow newWindow;
        Button createRecipeButton;
        public Crusher1ToMany()
        {
            input = new TextBox { Height = 40, Width = 260, FontSize = 24, FontWeight = FontWeights.Bold };
            output1 = new TextBox { Height = 40, Width = 260, FontSize = 24, FontWeight = FontWeights.Bold };
            output2 = new TextBox { Height = 40, Width = 260, FontSize = 24, FontWeight = FontWeights.Bold };
            output3 = new TextBox { Height = 40, Width = 260, FontSize = 24, FontWeight = FontWeights.Bold };
            output4 = new TextBox { Height = 40, Width = 260, FontSize = 24, FontWeight = FontWeights.Bold };
            outputCount1 = new TextBox { Height = 40, Width = 200, FontSize = 24, FontWeight = FontWeights.Bold, Text = "1" };
            outputCount2 = new TextBox { Height = 40, Width = 200, FontSize = 24, FontWeight = FontWeights.Bold, Text = "1" };
            outputCount3 = new TextBox { Height = 40, Width = 200, FontSize = 24, FontWeight = FontWeights.Bold, Text = "1" };
            outputCount4 = new TextBox { Height = 40, Width = 200, FontSize = 24, FontWeight = FontWeights.Bold, Text = "1" };
            energy = new TextBox { Height = 40, Width = 130, FontSize = 24, FontWeight = FontWeights.Bold, Text = "100" };
            createRecipeButton = new Button() { Height = 120, Width = 120, FontWeight = FontWeights.Bold, Content = "Create Recipe", HorizontalAlignment = HorizontalAlignment.Center, FontSize = 18, Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C2B")) };
            chB_Create = new CheckBox() { Content = "Create", Height = 30, Width = 250, FontSize=22, FontWeight=FontWeights.Bold, IsChecked=true };
            chB_IE = new CheckBox() { Content = "IE", Height = 30, Width = 250, FontSize=22, FontWeight=FontWeights.Bold, IsChecked = true };
            chB_Thermal= new CheckBox() { Content = "Themal", Height = 30, Width = 250, FontSize=22, FontWeight=FontWeights.Bold, IsChecked = true };
        }
        public Window getWindow()
        {
            newWindow = new SecondaryWindow();
            Canvas c = (Canvas)newWindow.secondWindow.Content;
            Label inputLabel = new Label() { Height = 50, Width = 260, FontSize = 28, FontWeight = FontWeights.Bold, Content = "input:", HorizontalAlignment = HorizontalAlignment.Center };
            c.Children.Add(input);
            c.Children.Add(inputLabel);
            Canvas.SetLeft(input, 40);
            Canvas.SetTop(input, 50);
            Canvas.SetLeft(inputLabel, 40);
            Canvas.SetTop(inputLabel, 0);
            Label outputLabel = new Label() { Height = 50, Width = 260, FontSize = 28, FontWeight = FontWeights.Bold, Content = "outputs:", HorizontalAlignment = HorizontalAlignment.Center };
            c.Children.Add(output1);
            Canvas.SetLeft(output1, 340);
            Canvas.SetTop(output1, 50);
            c.Children.Add(output2);
            Canvas.SetLeft(output2, 340);
            Canvas.SetTop(output2, 110);
            c.Children.Add(output3);
            Canvas.SetLeft(output3, 340);
            Canvas.SetTop(output3, 170);
            c.Children.Add(output4);
            Canvas.SetLeft(output4, 340);
            Canvas.SetTop(output4, 230);
            c.Children.Add(outputLabel);
            Canvas.SetLeft(outputLabel, 340);
            Canvas.SetTop(outputLabel, 0);
            c.Children.Add(outputCount1);
            Canvas.SetLeft(outputCount1, 640);
            Canvas.SetTop(outputCount1, 50);
            c.Children.Add(outputCount2);
            Canvas.SetLeft(outputCount2, 640);
            Canvas.SetTop(outputCount2, 110);
            c.Children.Add(outputCount3);
            Canvas.SetLeft(outputCount3, 640);
            Canvas.SetTop(outputCount3, 170);
            c.Children.Add(outputCount4);
            Canvas.SetLeft(outputCount4, 640);
            Canvas.SetTop(outputCount4, 230);
            Label outputCountLabel = new Label() { Height = 50, Width = 200, FontSize = 28, FontWeight = FontWeights.Bold, Content = "count/chances:", HorizontalAlignment = HorizontalAlignment.Center };
            c.Children.Add(outputCountLabel);
            Canvas.SetLeft(outputCountLabel, 640);
            Canvas.SetTop(outputCountLabel, 0);
            //----------------------------------
            Label energyLabel = new Label() { Height = 50, Width = 130, FontSize = 28, FontWeight = FontWeights.Bold, Content = "energy:", HorizontalAlignment = HorizontalAlignment.Center };
            c.Children.Add(energyLabel);
            c.Children.Add(energy);
            Canvas.SetLeft(energy, 40);
            Canvas.SetTop(energy, 125);
            Canvas.SetLeft(energyLabel, 40);
            Canvas.SetTop(energyLabel, 80);
            //---------------------------------
            c.Children.Add(chB_Create);
            Canvas.SetLeft(chB_Create, 40);
            Canvas.SetTop(chB_Create, 170);
            c.Children.Add(chB_IE);
            Canvas.SetLeft(chB_IE, 40);
            Canvas.SetTop(chB_IE, 200);
            c.Children.Add(chB_Thermal);
            Canvas.SetLeft(chB_Thermal, 40);
            Canvas.SetTop(chB_Thermal, 230);
            c.Children.Add(createRecipeButton);
            Canvas.SetLeft(createRecipeButton, 40);
            Canvas.SetTop(createRecipeButton, 300);
            createRecipeButton.Click += Create_Click;
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
            outputs.Clear();
            if (String.IsNullOrEmpty(input.Text))
                return false;
            if (Double.TryParse(energy.Text, out energyDbl))
            {
                if (!String.IsNullOrEmpty(output1.Text) && Double.TryParse(outputCount1.Text, out double a))
                {
                    outputs.Add(new Tuple<string, double>(removeQuotes(output1.Text), Double.Parse(outputCount1.Text)));
                    if (!String.IsNullOrEmpty(output2.Text) && Double.TryParse(outputCount2.Text, out a))
                    {
                        outputs.Add(new Tuple<string, double>(removeQuotes(output2.Text), Double.Parse(outputCount2.Text)));
                        if (!String.IsNullOrEmpty(output3.Text) && Double.TryParse(outputCount3.Text, out a))
                        {
                            outputs.Add(new Tuple<string, double>(removeQuotes(output3.Text), Double.Parse(outputCount3.Text)));
                            if (!String.IsNullOrEmpty(output4.Text) && Double.TryParse(outputCount4.Text, out a))
                            {
                                outputs.Add(new Tuple<string, double>(removeQuotes(output4.Text), Double.Parse(outputCount4.Text)));
                            }
                        }
                        return true;
                    }
                    return true;
                }
                return false;
            }
            return true;
        }
        string removeQuotes(string s)
        {
            if (String.IsNullOrEmpty(s))
                return "";
            else
                return s.Substring(1, s.Length - 2);
        }
        private void makeNewRecipe()
        {

            bool isTag = false;
            string allTheRecipes = "";
            //allTheRecipes = listToString(outputs)+"\n\n";
            inputStr = removeQuotes(input.Text);
            if (inputStr[0] == '#')
            {
                isTag = true;
                inputStr = inputStr.Substring(1, inputStr.Length - 1);
            }
            if ((bool)chB_Create.IsChecked)
                allTheRecipes += Create.Crusher1ToMany(inputStr, isTag, outputs, energyDbl);
            if ((bool)chB_Thermal.IsChecked)
                allTheRecipes += ThermalExpansion.Crusher1ToMany(inputStr, isTag, outputs, energyDbl);
            if ((bool)chB_IE.IsChecked)
                allTheRecipes += ImmersiveEngineering.Crusher1ToMany(inputStr, isTag, outputs, energyDbl);
            newWindow.writeIntoRecipeTextBox(allTheRecipes);
        }
        private string listToString(List<Tuple<string, double>> list)
        {
            string s = "";
            for (int i = 0; i < list.Count; i++)
                s += "Item: " + list[i].Item1.ToString() + "  Chances: " + list[i].Item2.ToString()+"\n";
            return s;
        }
    }
}
