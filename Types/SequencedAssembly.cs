using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using System.Reflection;

namespace MDE.Types
{
    internal class SequencedAssembly
    {
        Button createRecipeButton;
        SolidColorBrush orangeBrush, whiteBrush;
        SecondaryWindow newWindow;
        ComboBox[] ComboBoxes = new ComboBox[8];
        Tuple<TextBox, TextBox>[] supTextBoxes = new Tuple<TextBox, TextBox>[8];
        Tuple<Label, Label>[] supLabels = new Tuple<Label, Label>[8];
        TextBox TB_Loops;
        Label Sawmill, Pressing, Filling, Polishing, AddingItem, Label_Loops;
        int loopsCount;
        public SequencedAssembly()
        {
            orangeBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C2B"));
            whiteBrush = new SolidColorBrush(Colors.White);
            Sawmill = new Label { Height = 35, Width = 140, FontSize = 16, FontWeight = FontWeights.Bold, Content = "Sawmill" };
            Pressing = new Label { Height = 35, Width = 140, FontSize = 16, FontWeight = FontWeights.Bold, Content = "Pressing" };
            Filling = new Label { Height = 35, Width = 140, FontSize = 16, FontWeight = FontWeights.Bold, Content = "Filling" };
            Polishing = new Label { Height = 35, Width = 140, FontSize = 16, FontWeight = FontWeights.Bold, Content = "Polishing" };
            AddingItem = new Label { Height = 35, Width = 140, FontSize = 16, FontWeight = FontWeights.Bold, Content = "AddingItem" };
            TB_Loops = new TextBox { Height = 24, Width = 28, FontSize = 18, FontWeight = FontWeights.Bold, Text="1" };
            Label_Loops = new Label { Height = 40, Width = 180, FontSize = 18, FontWeight = FontWeights.Bold, Content = "Number of loops:", Foreground = whiteBrush };
            createRecipeButton = new Button() { Height = 120, Width = 120, FontWeight = FontWeights.Bold, Content = "Create Recipe", HorizontalAlignment = HorizontalAlignment.Center, FontSize = 18, Background = orangeBrush };
            createRecipeButton.Click += Create_Click;
        }
        public Window getWindow()
        {
            newWindow = new SecondaryWindow();
            Canvas c = (Canvas)newWindow.secondWindow.Content;
            c.Children.Add(Label_Loops);
            Canvas.SetLeft(Label_Loops, 40);
            Canvas.SetTop(Label_Loops, 26);
            c.Children.Add(TB_Loops);
            Canvas.SetLeft(TB_Loops, 210);
            Canvas.SetTop(TB_Loops, 32);
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
                supTextBoxes[i] = new Tuple<TextBox, TextBox>(new TextBox { Visibility = Visibility.Hidden, FontSize = 18, FontWeight = FontWeights.Bold }, new TextBox { Visibility = Visibility.Hidden, FontSize = 18, FontWeight = FontWeights.Bold });
                supLabels[i] = new Tuple<Label, Label>(new Label { Visibility = Visibility.Hidden, FontSize = 12, FontWeight = FontWeights.Bold, Foreground = whiteBrush }, new Label { Visibility = Visibility.Hidden, FontSize = 12, FontWeight = FontWeights.Bold, Foreground = whiteBrush });
                c.Children.Add(supTextBoxes[i].Item1);
                c.Children.Add(supTextBoxes[i].Item2);
                c.Children.Add(ComboBoxes[i]);
                if (i < 4)
                {
                    Canvas.SetLeft(ComboBoxes[i], 40);
                    Canvas.SetTop(ComboBoxes[i], 58 * i + 80);
                    Canvas.SetLeft(supTextBoxes[i].Item1, 260);
                    Canvas.SetTop(supTextBoxes[i].Item1, 58 * i + 80);
                    Canvas.SetLeft(supTextBoxes[i].Item2, 455);
                    Canvas.SetTop(supTextBoxes[i].Item2, 58 * i + 80);
                }
                else
                {
                    Canvas.SetLeft(ComboBoxes[i], 510);
                    Canvas.SetTop(ComboBoxes[i], 58 * (i - 4) + 80);
                    Canvas.SetLeft(supTextBoxes[i].Item1, 730);
                    Canvas.SetTop(supTextBoxes[i].Item1, 58 * (i - 4) + 80);
                    Canvas.SetLeft(supTextBoxes[i].Item2, 925);
                    Canvas.SetTop(supTextBoxes[i].Item2, 58 * (i - 4) + 80);
                }

            }
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
                int index = Array.FindIndex(ComboBoxes, val => val.Equals(sender));
                ComboBox cB = sender as ComboBox;
                Label l = cB.SelectedItem as Label;
                string str = l.Content.ToString();
                if (str == "Filling")
                {
                    supTextBoxes[index].Item1.Visibility = Visibility.Visible;
                    supTextBoxes[index].Item1.Width = 180;
                    supTextBoxes[index].Item1.Height = 35;
                    supTextBoxes[index].Item2.Visibility = Visibility.Visible;
                    supTextBoxes[index].Item2.Width = 35;
                    supTextBoxes[index].Item2.Height = 35;
                }
                else if (str == "AddingItem")
                {
                    supTextBoxes[index].Item1.Visibility = Visibility.Visible;
                    supTextBoxes[index].Item1.Width = 230;
                    supTextBoxes[index].Item1.Height = 35;
                    supTextBoxes[index].Item2.Visibility = Visibility.Hidden;
                }
                else
                {
                    supTextBoxes[index].Item1.Visibility = Visibility.Hidden;
                    supTextBoxes[index].Item2.Visibility = Visibility.Hidden;
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
            string isCorrect = isCorrectInput();
            if (isCorrect == "0")
            {
                MessageBox.Show("all is ok");
            }
            //makeNewRecipe();
            else
                MessageBox.Show(isCorrect);
        }
        string isCorrectInput()
        {
            bool anyRecipes = false;
            if (!Int32.TryParse(TB_Loops.Text, out loopsCount)|| loopsCount<=0)
                return "loops input is not correct";
            for (int i = 0; i < 8; i++)
            {
                if (ComboBoxes[i].SelectedItem != null)
                {
                    anyRecipes = true;
                    Label l = ComboBoxes[i].SelectedItem as Label;
                    string str = l.Content.ToString();
                    if (str == "Filling")
                        if (String.IsNullOrEmpty(supTextBoxes[i].Item1.Text) || !(Int32.TryParse(supTextBoxes[i].Item2.Text, out int parsedNumber)))
                            return "Filling field is incorrect";
                        else if (str == "AddingItem")
                            if (String.IsNullOrEmpty(supTextBoxes[i].Item1.Text))
                                return "Adding Item field is incorrect";
                }
            }
            if (anyRecipes == true)
                return "0";
            else
                return "Choose at least 1 recipe";
        }
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