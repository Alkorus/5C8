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

namespace Animation
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

        private void timer_clk(object sender, RoutedEventArgs e)
        {
            Timer ti = new Timer();
            ti.Show();
        }

        private void promCS_clk(object sender, RoutedEventArgs e)
        {
            PromenadeCs pcs = new PromenadeCs();
            pcs.Show();
        }

        private void promXAML_clk(object sender, RoutedEventArgs e)
        {
            PromenadeXAML px = new PromenadeXAML();
            px.Show();
        }

        private void stretch_clk(object sender, RoutedEventArgs e)
        {
            StretchImage si = new StretchImage();
            si.Show();
        }
    }
}
