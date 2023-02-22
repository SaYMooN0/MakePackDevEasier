using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
namespace MDE
{
    internal class Crusher1ToMany
    {
        TextBox input, output1, output2, output3, output4, outputCount1, outputCount2, outputCount3, outputCount4, energy, newRecipe;
        Button createRecipeButton, copyToClipboardButton;
        SolidColorBrush backBrush, orangeBrush;
        string inputStr, outputStr;
        double energyDbl;
        int countDbl;
        public Crusher1ToMany()
        {
            backBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2D384A"));
            orangeBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C2B"));
            input = new TextBox { Height = 40, Width = 260, FontSize = 24, FontWeight = FontWeights.Bold };
            output1 = new TextBox { Height = 40, Width = 260, FontSize = 24, FontWeight = FontWeights.Bold };
            output2 = new TextBox { Height = 40, Width = 260, FontSize = 24, FontWeight = FontWeights.Bold };
            output3 = new TextBox { Height = 40, Width = 260, FontSize = 24, FontWeight = FontWeights.Bold };
            output4 = new TextBox { Height = 40, Width = 260, FontSize = 24, FontWeight = FontWeights.Bold };
            newRecipe = new TextBox { Height = 120, Width = 730, FontSize = 18, FontWeight = FontWeights.Bold };
            outputCount1 = new TextBox { Height = 40, Width = 130, FontSize = 24, FontWeight = FontWeights.Bold, Text = "1" };
            outputCount2 = new TextBox { Height = 40, Width = 130, FontSize = 24, FontWeight = FontWeights.Bold, Text = "1" };
            outputCount3 = new TextBox { Height = 40, Width = 130, FontSize = 24, FontWeight = FontWeights.Bold, Text = "1" };
            outputCount4 = new TextBox { Height = 40, Width = 130, FontSize = 24, FontWeight = FontWeights.Bold, Text = "1" };
            energy = new TextBox { Height = 40, Width = 130, FontSize = 24, FontWeight = FontWeights.Bold, Text = "100" };
            copyToClipboardButton = new Button() { Height = 40, Width = 120, FontWeight = FontWeights.Bold, Content = "Copy", HorizontalAlignment = HorizontalAlignment.Center, FontSize = 18, Background = orangeBrush };
            createRecipeButton = new Button() { Height = 120, Width = 120, FontWeight = FontWeights.Bold, Content = "Crete Recipe", HorizontalAlignment = HorizontalAlignment.Center, FontSize = 18, Background = orangeBrush };
            createRecipeButton.Click += Create_Click;
            copyToClipboardButton.Click += copyToClipboard_Click;

        }
        public Canvas getWindowContent(Window win)
        {
            Window w = win;
            Canvas c = new Canvas { Height = w.Height, Width = w.Width, Background = backBrush };
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
            //----------------------------------c.Children.Add(outputCount);
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
            Label outputCountLabel = new Label() { Height = 50, Width = 130, FontSize = 28, FontWeight = FontWeights.Bold, Content = "count:", HorizontalAlignment = HorizontalAlignment.Center };
            c.Children.Add(outputCountLabel);
            Canvas.SetLeft(outputCountLabel, 640);
            Canvas.SetTop(outputCountLabel, 0);
            //----------------------------------
            Label energyLabel = new Label() { Height = 50, Width = 130, FontSize = 28, FontWeight = FontWeights.Bold, Content = "energy:", HorizontalAlignment = HorizontalAlignment.Center };
            c.Children.Add(energyLabel);
            c.Children.Add(energy);
            Canvas.SetLeft(energy, 800);
            Canvas.SetTop(energy, 50);
            Canvas.SetLeft(energyLabel, 800);
            Canvas.SetTop(energyLabel, 0);
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
        bool AnyEmptyFields()//todo
        {
            if (!String.IsNullOrEmpty(input.Text) && !String.IsNullOrEmpty(output1.Text))
                return false;
            return true;
        }
        private void copyToClipboard_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(newRecipe.Text))
                MessageBox.Show("Recipe is empty");
            else
            {
                Clipboard.SetText(newRecipe.Text);
                Task t = Task.Run(() => copyToClipboardButton.Dispatcher.Invoke(new Action(async delegate
                {
                    copyToClipboardButton.Content = "Copied";
                    await Task.Delay(700);
                    copyToClipboardButton.Content = "Copy";
                })));
            }
        }
        bool isCorrectInput()//todo
        {
            if (AnyEmptyFields())
                return false;
            if (Double.TryParse(energy.Text, out energyDbl) && Int32.TryParse(outputCount1.Text, out countDbl))
                return true;
            return false;
        }
        private void makeNewRecipe()
        {
            bool isTag = false;
            string allTheRecipes = "";
            inputStr = input.Text.Substring(1, input.Text.Length - 2);
            outputStr = output1.Text.Substring(1, output1.Text.Length - 2);
            if (inputStr[0] == '#')
            {
                isTag = true;
                inputStr = inputStr.Substring(1, inputStr.Length - 1);
            }
            //allTheRecipes += Create.Crusher1ToMany(inputStr, isTag, outputStr, countDbl, energyDbl);
            //allTheRecipes += ThermalExpansion.Crusher1ToMany(inputStr, isTag, outputStr, countDbl, energyDbl);
            //allTheRecipes += Mekanism.Crusher1ToMany(inputStr, isTag, outputStr, countDbl);
            //allTheRecipes += ImmersiveEngineering.Crusher1ToMany(inputStr, isTag, outputStr, countDbl, energyDbl);
            newRecipe.Text = allTheRecipes;
        }
    }
}
