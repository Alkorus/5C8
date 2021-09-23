using Bourse21.Modeles;
using Bourse21.Outils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Bourse21.VueModeles
{
    class VM_Proprietaires : INotifyPropertyChanged
    {
        public ICommand cmdPreparerNouveau_Proprio { get; set; }
        public ICommand cmdInserer_Proprio { get; set; }
        public ICommand cmdModifier_Proprio { get; set; }
        public ICommand cmdSupprimer_Proprio { get; set; }



        public VM_Proprietaires()
        {
            cmdPreparerNouveau_Proprio = new Commande(cmdPreparerNouveau);
            cmdInserer_Proprio = new Commande(cmdInserer);
            cmdModifier_Proprio = new Commande(cmdModifier);
            cmdSupprimer_Proprio = new Commande(cmdSupprimer);

            EvenementBourse.ModificationImageProprio += AjusteVersionImage;

            initProprio();

        }

        #region propriétés
        private string _texteDEnteteListe;
        public string TexteDEnteteListe
        {
            get { return _texteDEnteteListe; }
            set
            {
                _texteDEnteteListe = value;
                OnPropertyChanged("TexteDEnteteListe");
            }
        }
        private string _texteDEnteteDetail;
        public string TexteDEnteteDetail
        {
            get { return _texteDEnteteDetail; }
            set
            {
                _texteDEnteteDetail = value;
                OnPropertyChanged("TexteDEnteteDetail");
            }
        }

        private string _nom;
        public string Nom
        {
            get { return _nom; }
            set
            {
                _nom = value;
                OnPropertyChanged("Nom");
            }
        }

        private DateTime _naissance;
        public DateTime Naissance
        {
            get { return _naissance; }
            set
            {
                _naissance = value;
                OnPropertyChanged("Naissance");
            }
        }

        private int _liquidite;
        public int Liquidite
        {
            get { return _liquidite; }
            set
            {
                _liquidite = value;
                OnPropertyChanged("Liquidite");
            }
        }

        private ObservableCollection<Proprietaire> _sommaireProprietaires;
        public ObservableCollection<Proprietaire> SommaireProprietaires
        {
            get { return _sommaireProprietaires; }
            set
            {
                _sommaireProprietaires = value;
                if (_sommaireProprietaires.Count > 0)
                    TexteDEnteteListe = _sommaireProprietaires.Count + " propriétaires";
                else
                    TexteDEnteteListe = "Aucun propriétaire";
                OnPropertyChanged("SommaireProprietaires");
            }

        }
        private Proprietaire _proprietaireSelectionne;
        public Proprietaire ProprietaireSelectionne
        {
            get { return _proprietaireSelectionne; }
            set
            {
                _proprietaireSelectionne = value;
                if (value == null)
                    return;
                TexteDEnteteDetail = "Details de " + _proprietaireSelectionne.Nom + " (id:" + _proprietaireSelectionne.ID + ")";
                Nom = _proprietaireSelectionne.Nom;
                Naissance = _proprietaireSelectionne.Naissance;
                Liquidite = _proprietaireSelectionne.Liquidite;

                Acquisitions = ProprietaireSelectionne.PorteFeuille;
                TrousseGlobale.idPropSelectionne = _proprietaireSelectionne.ID;
                TrousseGlobale.versionImage = _proprietaireSelectionne.VersionImage;

                EvenementBourse.OnChangementProprio(new ChangementProprioEventArgs(_proprietaireSelectionne.ID, _proprietaireSelectionne.VersionImage));

                OnPropertyChanged("ProprietaireSelectionne");
            }
        }

        private Collection<Transaction> _acquisitions;
        public Collection<Transaction> Acquisitions
        {
            get {  return _acquisitions; }
            set
            {
                _acquisitions = value;
                OnPropertyChanged("Acquisitions");
            }
        }

        #endregion
        private void initProprio()
        {
            SommaireProprietaires = new ObservableCollection<Proprietaire>();

            //var pReq = from proprio in OutilEF.BrsCtx.Capitalistes select proprio;
            var pReq = from proprio in OutilEF.BrsCtx.Capitalistes.Include("PorteFeuille.CIEVendue") select proprio;
            foreach (Proprietaire p in pReq)
                SommaireProprietaires.Add(p);

            if (_sommaireProprietaires.Count > 0)
            {
                ProprietaireSelectionne = SommaireProprietaires[0];
                //string destFile = TrousseGlobale.IMAGE + @"Proprios\proprio" + ProprietaireSelectionne.ID + ".png";
                /*if (!File.Exists(destFile))
                {
                    destFile = TrousseGlobale.IMAGE + @"Proprios\proprio0.png";
                }*/
                TexteDEnteteListe = _sommaireProprietaires.Count + " propriétaires";
                TexteDEnteteDetail = "Détails de " + ProprietaireSelectionne.Nom;
            }
            else
                TexteDEnteteListe = "Aucun propriétaire";
        }



       

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string nomProp)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nomProp));
            }
        }

        
        private void cmdSupprimer(object param)
        {
            if (ProprietaireSelectionne == null)
                return;

            OutilEF.BrsCtx.Capitalistes.Remove(ProprietaireSelectionne);
            OutilEF.BrsCtx.SaveChanges();

            ProprietaireSelectionne = null;
            TexteDEnteteDetail = "Suppression réussie";

            Nom = "";
            Liquidite = 0;
            Naissance = new DateTime();

            initProprio();
        }
        private void cmdModifier(object param)
        {
            Proprietaire pMod = OutilEF.BrsCtx.Capitalistes.Find(ProprietaireSelectionne.ID);
            pMod.Nom = Nom;
            pMod.Naissance = Naissance;
            pMod.Liquidite = Liquidite;
            ProprietaireSelectionne = pMod;
            OutilEF.BrsCtx.SaveChanges();
            initProprio();
        }
        private void cmdInserer(object param)
        {
            if (ProprietaireSelectionne == null)
            {
                Proprietaire p = new Proprietaire();
                p.Nom = Nom;
                p.Naissance = Naissance;
                p.Liquidite = Liquidite;
                p.Creation = DateTime.Now;
                p.VersionImage = 1;

                OutilEF.BrsCtx.Capitalistes.Add(p);
                OutilEF.BrsCtx.SaveChanges();

                SommaireProprietaires.Add(p);
                ProprietaireSelectionne = p;
                TexteDEnteteListe = "Liste de " + SommaireProprietaires.Count + " prorpios";

                string srcFile = TrousseGlobale.IMAGE + @"proprios\proprio" + ProprietaireSelectionne.ID + "_V1.png";
                if (File.Exists(srcFile))
                {
                    TrousseGlobale.Televerser(srcFile, new Uri(TrousseGlobale.FTP_IMAGE + "/Proprios/proprio" + ProprietaireSelectionne.ID + "_V1.png"));
                } 
                else
                {
                    MessageBox.Show("Info image par défaut absente");
                }

            }
        }
        private void cmdPreparerNouveau(object param)
        {
            Nom = "";
            Naissance = new DateTime();
            Liquidite = 0;
            ProprietaireSelectionne = null;
            TexteDEnteteDetail = "Création d'un nouveau propriétaire";
            Acquisitions = new Collection<Transaction>();
            //TrousseGlobale.idPropSelectionne = 0;
            EvenementBourse.OnChangementProprio(new ChangementProprioEventArgs(0, 0));
            // Hypothèse Zalec: envoyer un msg pour que la vue unselectall() de la liste box

        }

        public void AjusteVersionImage(object sender, ModificationImageProprioEventArgs e)
        {
            Proprietaire prop = OutilEF.BrsCtx.Capitalistes.Find(ProprietaireSelectionne.ID);
            prop.VersionImage = TrousseGlobale.versionImage;
            OutilEF.BrsCtx.SaveChanges();       //Ajuster la version de l'image en BD
        }

    }
}
