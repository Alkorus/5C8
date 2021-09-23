using Bourse21.Vues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bourse21.Outils
{
    class TrousseGlobale
    {
        public const string BASE = @"C:\Users\0332492\atelier\2021-09-09-ORM presque termine\";
        public const string IMAGE = BASE + @"Images\";

        public static int idPropSelectionne;

        public static void OuvrirEcran(Window parent, string nomDlg, bool gardeParent=true, bool modale=true)
        {
            // Instanciation d'un window
            Window win = (Window)parent.GetType().Assembly.CreateInstance("Bourse21.Vues." + nomDlg);
            //Window win2 = new Proprietaires();
            if (!gardeParent)
                // fermeture du parent
                parent.Close();
            if (modale)
                win.ShowDialog();
            else
                win.Show();
        }

    }
    class OutilEF
    {
        public static BourseContexte BrsCtx;
        public OutilEF()
        {
            try {
                BrsCtx = new BourseContexte();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur ORM : " + e.Message);
            }
        }  
    }
}
