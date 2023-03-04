﻿using System;
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
        ComboBox Exapmle;
        TextBox TB_Loops, Input1, Input2, Input3, Input4, Input5, Input6, Input8;
        Label Sawmill, Pressing, Filling, Polishing, AddingItem;
        public SequencedAssembly()
        {
            orangeBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C2B"));
            Sawmill= new Label { Height = 35, Width = 140, FontSize = 16, FontWeight = FontWeights.Bold, Content="Sawmill" };
            Pressing = new Label { Height = 35, Width = 140, FontSize = 16, FontWeight = FontWeights.Bold, Content= "Pressing" };
            Filling = new Label { Height = 35, Width = 140, FontSize = 16, FontWeight = FontWeights.Bold, Content= "Filling" };
            Polishing = new Label { Height = 35, Width = 140, FontSize = 16, FontWeight = FontWeights.Bold, Content= "Polishing" };
            AddingItem = new Label { Height = 35, Width = 140, FontSize = 16, FontWeight = FontWeights.Bold, Content= "AddingItem" };
            TB_Loops = new TextBox {Height=20, Width=20, FontSize=16, FontWeight=FontWeights.Bold };
            Exapmle = new ComboBox() {Height=35, Width=160, FontWeight = FontWeights.Bold, HorizontalAlignment = HorizontalAlignment.Center, FontSize = 18,Text="Choose type:" };
            //Exapmle.Items.Add(Pressing);
            //Exapmle.Items.Add(Sawmill);
            //Exapmle.Items.Add(Filling);
            //Exapmle.Items.Add(Polishing);
            //Exapmle.Items.Add(AddingItem);
            createRecipeButton = new Button() { Height = 120, Width = 120, FontWeight = FontWeights.Bold, Content = "Crete Recipe", HorizontalAlignment = HorizontalAlignment.Center, FontSize = 18, Background = orangeBrush };
            createRecipeButton.Click += Create_Click;
        }
        public Window getWindow()
        {
            newWindow = new SecondaryWindow();
            Canvas c = (Canvas)newWindow.secondWindow.Content;
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
                    Canvas.SetTop(ComboBoxes[i], (50 * (i) + 40));
                }
                else
                {
                    Canvas.SetLeft(ComboBoxes[i], 540);
                    Canvas.SetTop(ComboBoxes[i], (50 * (i-4) + 40));
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
            ComboBox cB = sender as ComboBox;
            MessageBox.Show(cB.SelectedItem.ToString());
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