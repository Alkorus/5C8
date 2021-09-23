using Bourse21.Outils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Bourse21.Vues;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bourse21
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OutilEF outilEF = new OutilEF();
        }
               
        private void OnTabProprioSelected(object sender, RoutedEventArgs e)
        {
            PresenteurProprio.Content = new UC_Proprietaires();
        }

        private void OnTabSocieteSelected(object sender, RoutedEventArgs e)
        {
            PresenteurSocietes.Content = new UC_Societes();
        }

        private void OnTabTrxSelected(object sender, RoutedEventArgs e)
        {
            PresenteurTrx.Content = new UC_Transactions();
        }
    }
}
