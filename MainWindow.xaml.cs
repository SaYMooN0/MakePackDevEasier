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
        enum recipeType {Crusher1to1, Crusher1toMany, Polishing, Pressing, Filling, Nothing };
        private void CreateRecipe_Click(object sender, RoutedEventArgs e)
        {
            bool isChosen = true;
            Window newRecipeWin= SecondaryWindow.recipeWindow();
            Canvas windowContent=new Canvas();
            recipeType myChosenType = chosenType();
            if (myChosenType == recipeType.Nothing)
            {
                MessageBox.Show("Choose recipe type");
                isChosen = false;
            }
            else if (myChosenType == recipeType.Crusher1to1)
            {
                Crusher1to1 c = new Crusher1to1();
                windowContent = c.getWindowContent(newRecipeWin);
            }
            else
            {
                MessageBox.Show("Your recipe type is: "+myChosenType.ToString());
                isChosen = false;
            }
            if (isChosen)
            {
                newRecipeWin.Content = windowContent;
                newRecipeWin.Show();
            }
        }
        private recipeType chosenType()
        {
            if ((bool)Crusher1to1.IsChecked)
                return recipeType.Crusher1to1;
            else if ((bool)Crusher1toMany.IsChecked)
                return recipeType.Crusher1toMany;
            else if ((bool)Polishing.IsChecked)
                return recipeType.Polishing;
            else if ((bool)Pressing.IsChecked)
                return recipeType.Pressing;
            else if ((bool)Filling.IsChecked)
                return recipeType.Filling;
            else return recipeType.Nothing; 
            
        }
    }
}
