using Bourse21.Modeles;
using Bourse21.Outils;
using Bourse21.VueModeles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Bourse21.Vues
{
    /// <summary>
    /// Logique d'interaction pour UC_Proprietaires.xaml
    /// </summary>
    public partial class UC_Proprietaires : UserControl
    {
        public UC_Proprietaires()
        {
            InitializeComponent();
            DataContext = new VM_Proprietaires();
        }

    }
}
