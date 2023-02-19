using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MDE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        enum recipeType {Crusher1to1, Crusher1toMany, Polishing, Pressing, Filling };
        private void CreateRecipe_Click(object sender, RoutedEventArgs e)
        {
            Window newRecipeWin= SecondaryWindow.recipeWindow();
            Canvas windowContent=new Canvas();
            if (chosenType() == recipeType.Crusher1to1)
            {
                Crusher1to1 c = new Crusher1to1();
                windowContent = c.getWindowContent(newRecipeWin);
            }
            newRecipeWin.Content=windowContent;
            newRecipeWin.Show();
        }
        private recipeType chosenType()
        {
            return recipeType.Crusher1to1;
        }
    }
}
