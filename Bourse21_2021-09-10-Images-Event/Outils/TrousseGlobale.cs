using Bourse21.Vues;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bourse21.Outils
{
    class TrousseGlobale
    {
        // paths pour atteindre les images (avant FTP)
        public const string BASE = @"C:\Users\0332492\atelier\Bourse21_2021-09-10-Images-Event\";
        public const string IMAGE = BASE + @"Images\";

        public static int idPropSelectionne;
        public static int versionImage;

        public const string FTP_BASE = @"ftp://becscanard.techinfo-cstj.ca/public_ftp/";
        public const string FTP_IMAGE = FTP_BASE + "images/bourse/";

        public const string FTP_UTILISATEUR = "becscanard";
        public const string FTP_MOT_PASSE = "CiaN1471g_";

        public static void Telecharger(Uri serverFTPUri, string destNomFichier)
        {
            var request = (FtpWebRequest)WebRequest.Create(serverFTPUri);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(FTP_UTILISATEUR, FTP_MOT_PASSE);
            request.UseBinary = true;
            try
            {
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (FileStream fs = new FileStream(destNomFichier, FileMode.Create))
                        {
                            byte[] buffer = new byte[102400];
                            int read = 0;
                            do
                            {
                                read = responseStream.Read(buffer, 0, buffer.Length);
                                fs.Write(buffer, 0, read);
                                fs.Flush();
                            } while (!(read == 0));

                            fs.Flush();
                            fs.Close();
                        }
                    }
                }
            }
            catch (System.InvalidOperationException e)
            {
                //   MessageBox.Show("AvertissementErreur FTP\n" + e.Message);
                //   MessageBox.Show(serverUri.ToString());
                File.Copy(TrousseGlobale.IMAGE + @"proprios/proprio0.png", destNomFichier);
            }

        }

        public static void Televerser(string srcNomFichier, Uri serverFTPUri)
        {
            try
            {
                // serverUri doit utiliser le schÃ©ma  ftp://.
                // Il contient le nom du serveur de fichiers qui recevra le tÃ©lÃ©versement et le path oÃ¹ le tÃ©lÃ©verser.
                // Example: ftp://serveur.ca/path_ftp/image1.png.
                if (serverFTPUri.Scheme != Uri.UriSchemeFtp)
                {
                    MessageBox.Show("Mauvais URI");
                    return;
                }
                // Obtenir l'objet utilisÃ© pour communiquer avec le serveur.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverFTPUri);

                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Proxy = null;
                request.UseBinary = true;
                request.Credentials = new NetworkCredential(FTP_UTILISATEUR, FTP_MOT_PASSE);

                //SÃ©lection du fichier Ã  tÃ©lÃ©verser 
                FileInfo ff = new FileInfo(srcNomFichier);
                byte[] fileContents = new byte[ff.Length];

                //L'objet sera dÃ©truit dÃ¨s le tÃ©lÃ©versement complÃ©tÃ©
                using (FileStream fr = ff.OpenRead())
                {
                    fr.Read(fileContents, 0, Convert.ToInt32(ff.Length));
                }

                using (Stream writer = request.GetRequestStream())
                {
                    writer.Write(fileContents, 0, fileContents.Length);
                }

                //Obtenir le FtpWebResponse de l'opÃ©ration de tÃ©lÃ©versement
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            }
            catch (WebException webex)
            {
                MessageBox.Show("Erreur mon chum:" + webex.ToString());
            }
            MessageBox.Show("TerminÃ©");

        }


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
