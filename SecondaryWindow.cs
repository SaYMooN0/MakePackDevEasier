using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
namespace MDE
{
    internal class SecondaryWindow
    {
        public static Window recipeWindow()
        {
            Window w= new Window();
            w.Height = 500;
            w.Width = 1000;
            
            return w;
        }
    }
}
