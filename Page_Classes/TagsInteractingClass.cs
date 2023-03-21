using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MDE.Page_Classes
{
    class TagsInteractingClass
    {

        public Window Window { get; set; }
        Canvas mainCanvas;
        SolidColorBrush orangeBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C2B"));
        SolidColorBrush backBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2D384A"));
        public TagsInteractingClass()
        {
            Window = new Window { Height = 850, Width = 900 };
            mainCanvas = new Canvas() { Width = Window.Width, Height = Window.Height, Background = backBrush };
            Window.Content = mainCanvas;
        }
        private Canvas getCanvasExmple()
        {
            Canvas c = new Canvas();
            return c;
        }
    }
}
