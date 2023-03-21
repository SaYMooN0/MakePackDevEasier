using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace MDE.Page_Classes
{
    class TagsInteractingClass
    {

        public Window Win { get; set; }
        Canvas mainCanvas;
        Label chooseType = new Label() { Content = "Choose what do u want to do:",
            HorizontalContentAlignment=HorizontalAlignment.Center, VerticalContentAlignment= VerticalAlignment.Center, 
            Foreground=new SolidColorBrush(Colors.White),FontWeight=FontWeights.Bold};
        SolidColorBrush orangeBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C2B"));
        SolidColorBrush backBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2D384A"));
        public TagsInteractingClass()
        {
            Win = new Window { Height = 850, Width = 900 };
            mainCanvas = new Canvas() {Background = backBrush };
            mainCanvas.Children.Add(chooseType);
            Win.Content = mainCanvas;
        }

        public void winSizeChanged(Window w)
        {
            Win = w;
            chooseType.Width = Win.Width / 2;
            chooseType.Height = Win.Height / 10;
            chooseType.FontSize = (Win.Height + Win.Width) / 65;
            mainCanvas.Height = Win.Height;
            mainCanvas.Width = Win.Width;

        }
    
        private Canvas getCanvasExmple()
        {
            Canvas c = new Canvas();
            return c;
        }
    }
}
