using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace MDE.Page_Classes
{
    class TagsInteractingClass
    {
        string[] interactionsTypes = {"Add item to tag collection","Remove item from tag collection","Remove all items from tag collection", "Remove all tags for item"};
        CheckBox CHB_IsMultiple = new CheckBox() { Content="More than 1 item?", Height=100, Width=120, LayoutTransform=new ScaleTransform(2,2)};
        public Window Win { get; set; }
        Canvas mainCanvas;
        Label chooseType = new Label() {
            Content = "Choose what do u want to do:",
            HorizontalContentAlignment=HorizontalAlignment.Left, VerticalContentAlignment= VerticalAlignment.Center, 
            Foreground=new SolidColorBrush(Colors.White),FontWeight=FontWeights.Bold, 
            FontSize=26, Height=40, Width=420
        };
        ComboBox CB_InterctType;
        SolidColorBrush orangeBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C2B"));
        SolidColorBrush backBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2D384A"));
        public TagsInteractingClass()
        {
            Win = new Window { Height = 850, Width = 900 };
            mainCanvas = new Canvas() {Background = backBrush };

            CB_InterctType = AssembleComboBox(Win.Height, Win.Width);

            mainCanvas.Children.Add(chooseType);
            Canvas.SetLeft(chooseType, 30);
            Canvas.SetTop(chooseType, 10);

            mainCanvas.Children.Add(CB_InterctType);
            Canvas.SetRight(CB_InterctType, 30);
            Canvas.SetTop(CB_InterctType, 10);

            //mainCanvas.Children.Add(CHB_IsMultiple);
            //Canvas.SetRight(CHB_IsMultiple, 30);
            //Canvas.SetBottom(CHB_IsMultiple, 10);

            Win.Content = mainCanvas;
        }

        public void winSizeChanged(Window w)
        {
            Win = w;
            chooseType.Width = Win.Width /2.1-20;
            chooseType.Height = Win.Height / 16;
            chooseType.FontSize = Math.Min(Win.Height ,Win.Width) / 32;
            Canvas.SetLeft(chooseType, Win.Width/90);

            CB_InterctType.Width = Win.Width / 2.1-20;
            CB_InterctType.Height = Win.Height / 16;
            CB_InterctType.FontSize = Math.Min(Win.Height, Win.Width) / 32;

            mainCanvas.Height = Win.Height;
            mainCanvas.Width = Win.Width;
        }
        private ComboBox AssembleComboBox(double h, double w)
        {
            int maxLength = interactionsTypes[0].Length;
            for (int i = 1; i < interactionsTypes.Length; i++)
                if (maxLength < interactionsTypes[i].Length)
                    maxLength = interactionsTypes[i].Length;
            ComboBox comboBox = new ComboBox()
            {
                HorizontalContentAlignment = HorizontalAlignment.Left,
                VerticalContentAlignment = VerticalAlignment.Center,
                Foreground = new SolidColorBrush(Colors.Black),
                FontWeight = FontWeights.Bold,
                Height = h/20,
                Width = w/2.1,
            };
            comboBox.FontSize= (int)(comboBox.Width * 0.9 / maxLength * 2);
            foreach (string str in interactionsTypes)
            {
                Label l = new Label() {Content=str, Width=comboBox.Width*0.9 , FontSize=(int)(comboBox.Width*0.9/maxLength*2), Foreground=new SolidColorBrush(Colors.Black)};
                comboBox.Items.Add(l);    
            }
            comboBox.SelectionChanged += ComboBox_SelectionChanged;
            return comboBox;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cB = sender as ComboBox;
            Label l = cB.SelectedItem as Label;
            MessageBox.Show(l.Content.ToString());
        }
        private Canvas getCanvasExmple()
        {
            Canvas c = new Canvas();
            return c;
        }
    }
}
