﻿using Bourse21.Modeles;
using Bourse21.Outils;
using Bourse21.VueModeles;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
            EvenementBourse.ChangementProprio += AjusteImageProprio;
            DataContext = new VM_Proprietaires();
        }

        public void AjusteImageProprio(object sender, ChangementProprioEventArgs e)
        {
            string NomFichierImage;

            if (e.ProprioId == 0)
            {
                NomFichierImage = TrousseGlobale.IMAGE + @"proprios\proprio0.png";
            }
            else
            {
                NomFichierImage = TrousseGlobale.IMAGE +
                                     @"proprios\proprio" +
                                     e.ProprioId +
                                     "_V" +
                                     e.versionImage +
                                     ".png";

                if (!File.Exists(NomFichierImage))
                {
                    TrousseGlobale.Telecharger(new Uri(TrousseGlobale.FTP_IMAGE + "Proprios/proprio" + e.ProprioId + "_V" + e.versionImage + ".png"), NomFichierImage);
                }
            }
                        

            BitmapImage bmiProprio = new BitmapImage();
            bmiProprio.BeginInit();
            bmiProprio.UriSource = new Uri(NomFichierImage);
            bmiProprio.EndInit();

            img_Proprio.Source = bmiProprio;
        }


        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            string NomFichierImage;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                NomFichierImage = openFileDialog.FileName;
                //MessageBox.Show("Image du propriétaire:" + NomFichierImage);
                BitmapImage bmiProprio = new BitmapImage();
                bmiProprio.BeginInit();
                bmiProprio.UriSource = new Uri(NomFichierImage);
                bmiProprio.EndInit();

                img_Proprio.Source = bmiProprio;
                TrousseGlobale.versionImage++;
                string destination = TrousseGlobale.IMAGE + @"Proprios\proprio" + TrousseGlobale.idPropSelectionne + "_V" + TrousseGlobale.versionImage + ".png";
                File.Copy(NomFichierImage, destination, true);

                EvenementBourse.OnModificationImageProprio(new ModificationImageProprioEventArgs(TrousseGlobale.idPropSelectionne, TrousseGlobale.versionImage));
                //Global.TeleverseFichier(destination, new Uri("ftp://amartel.techinfo-cstj.ca/public_ftp/images/bourse/Proprios/proprio" + Global.idPropSelectionne + "_V" + Global.versionImage + ".png"));
            }

        }

        private void btn_PreparerNeo_Click(object sender, RoutedEventArgs e)
        {
            ListeProprio.SelectedItem = null;
        }
    }
}
