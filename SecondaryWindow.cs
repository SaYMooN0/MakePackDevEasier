using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
namespace MDE
{
    internal class SecondaryWindow
    {
        public Window secondWindow;
        SolidColorBrush backBrush, orangeBrush;
        Button copyToClipboardButton;
        TextBox newRecipe;
        public SecondaryWindow()
        {
            orangeBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C2B"));
            backBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2D384A"));
            secondWindow = new Window();
            secondWindow.Height = 520;
            secondWindow.Width = 1000;
            copyToClipboardButton = new Button() { Height = 40, Width = 120, FontWeight = FontWeights.Bold, Content = "Copy", HorizontalAlignment = HorizontalAlignment.Center, FontSize = 18, Background = orangeBrush };
            newRecipe = new TextBox { Height = 120, Width = 730, FontSize = 18, FontWeight = FontWeights.Bold };
            copyToClipboardButton.Click += copyToClipboard_Click;
            Canvas c = new Canvas { Height = secondWindow.Height, Width = secondWindow.Width, Background = backBrush };
            c.Children.Add(newRecipe);
            Canvas.SetLeft(newRecipe, 200);
            Canvas.SetTop(newRecipe, 300);
            c.Children.Add(copyToClipboardButton);
            Canvas.SetLeft(copyToClipboardButton, 810);
            Canvas.SetTop(copyToClipboardButton, 430);
            secondWindow.Content = c;
            
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
        public void writeIntoRecipeTextBox(string s) { newRecipe.Text = s; }
    }
}