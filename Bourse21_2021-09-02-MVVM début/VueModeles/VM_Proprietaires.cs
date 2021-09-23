using Bourse21.Modeles;
using Bourse21.Outils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bourse21.VueModeles
{
    class VM_Proprietaires : INotifyPropertyChanged
    {
        public ICommand cmdPreparerNouveau_Proprio { get; set; }


        public VM_Proprietaires()
        {
            cmdPreparerNouveau_Proprio = new Commande(cmdPreparerNouveau);
            initProprio();

        }
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
                OnPropertyChanged("ProprietaireSelectionne");
            }
        }

        private void initProprio()
        {
            SommaireProprietaires = new ObservableCollection<Proprietaire>();

            var pReq = from proprio in OutilEF.BrsCtx.Capitalistes select proprio;
            foreach (Proprietaire p in pReq)
                SommaireProprietaires.Add(p);

            if (_sommaireProprietaires.Count > 0)
                TexteDEnteteListe = _sommaireProprietaires.Count + " propriétaires";
            else
                TexteDEnteteListe = "Aucun propriétaire";
        }



        private void initProprioOld()
        {
            SommaireProprietaires = new ObservableCollection<Proprietaire>();
            Random rdm = new Random();

            Proprietaire p = new Proprietaire();
            p.ID = 1;
            p.Naissance = new DateTime(1931, 7, 30);
            p.Liquidite = rdm.Next(20000, 20000000);
            p.Creation = DateTime.Now;
            p.Nom = "Jean Coutu";

            SommaireProprietaires.Add(p);

            p = new Proprietaire();
            p.ID = 2;
            p.Naissance = new DateTime(1964, 6, 30);
            p.Liquidite = rdm.Next(20000, 20000000);
            p.Creation = DateTime.Now;
            p.Nom = "Pierre Karl Péladeau";

            SommaireProprietaires.Add(p);

            p = new Proprietaire();
            p.ID = 3;
            p.Naissance = new DateTime(2002, 5, 30);
            p.Liquidite = rdm.Next(20000, 20000000);
            p.Creation = DateTime.Now;
            p.Nom = "Lino Saputo";

            SommaireProprietaires.Add(p);

            if (_sommaireProprietaires.Count > 0)
                TexteDEnteteListe = _sommaireProprietaires.Count + " propriétaires";
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

       /* private void ClkPreprarerNeo(object sender, RoutedEventArgs e)
        {
            Nom = "";
            Naissance = new DateTime();
            Liquidite = 0;
            ProprietaireSelectionne = null;
            TexteDEnteteDetail = "Création d'un néo proprio";
        }*/

        /*private void ClkInsertion(object sender, RoutedEventArgs e)
        {
            if (ProprietaireSelectionne == null)
            {
                Proprietaire p = new Proprietaire();
                p.Nom = Nom;
                p.Naissance = Naissance;
                p.Liquidite = Liquidite;
                p.Creation = DateTime.Now;

                SommaireProprietaires.Add(p);
                ProprietaireSelectionne = p;
                TexteDEnteteListe = "Liste de " + SommaireProprietaires.Count + " prorpios";

                OutilEF.BrsCtx.Capitalistes.Add(p);
                OutilEF.BrsCtx.SaveChanges();
            }
        }*/

       /* private void ClkModifier(object sender, RoutedEventArgs e)
        {
            Proprietaire pMod = OutilEF.BrsCtx.Capitalistes.Find(ProprietaireSelectionne.ID);
            //pMod.ID = ProprietaireSelectionne.ID;
            pMod.Nom = Nom;
            pMod.Naissance = Naissance;
            pMod.Liquidite = Liquidite;
            ProprietaireSelectionne = pMod;
            OutilEF.BrsCtx.SaveChanges();

            initProprio();

        }*/

        /*private void ClkSupprimer(object sender, RoutedEventArgs e)
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

        }*/
        private void cmdPreparerNouveau(object param)
        {
            Nom = "";
            Naissance = new DateTime();
            Liquidite = 0;
            ProprietaireSelectionne = null;
            TexteDEnteteDetail = "Création d'un nouveau propriétaire";
        }

       
    }
}
