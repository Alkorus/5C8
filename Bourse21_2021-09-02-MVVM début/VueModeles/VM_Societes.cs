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
    class VM_Societes : INotifyPropertyChanged
    {
        public ICommand cmdPreparerNouvelle_Societe { get; set; }
        public ICommand cmdInserer_Societe { get; set; }
        public ICommand cmdModifier_Societe { get; set; }
        public ICommand cmdSuppromer_Societe { get; set; }

        public VM_Societes()
        {
            cmdPreparerNouvelle_Societe = new Commande(cmdPreparerNouvelle);
        }

        #region proprietes
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

        private string _raisonSociale;
        public string RaisonSociale
        {
            get { return _raisonSociale; }
            set
            {
                _raisonSociale = value;
                OnPropertyChanged("RaisonSociale");
            }
        }

        private DateTime _dateCreation;
        public DateTime DateCreation
        {
            get { return _dateCreation; }
            set
            {
                _dateCreation = value;
                OnPropertyChanged("DateCreation");
            }
        }

        private int _nbActions;
        public int NbActions
        {
            get { return _nbActions; }
            set
            {
                _nbActions = value;
                OnPropertyChanged("NbActions");
            }
        }
        private int _valeurUnitaire;
        public int ValeurUnitaire
        {
            get { return _valeurUnitaire; }
            set
            {
                _valeurUnitaire = value;
                OnPropertyChanged("ValeurUnitaire");
            }
        }

        private ObservableCollection<Societe> _sommaireSocietes;
        public ObservableCollection<Societe> SommaireSocietes
        {
            get { return _sommaireSocietes; }
            set
            {
                _sommaireSocietes = value;
                if (_sommaireSocietes.Count > 0)
                    TexteDEnteteListe = _sommaireSocietes.Count + " sociétés";
                else
                    TexteDEnteteListe = "Aucune société";
                OnPropertyChanged("SommaireSocietes");
            }
        }

        private Societe _societeSelectionnee;
        public Societe SocieteSelectionnee
        {
            get { return _societeSelectionnee; }
            set
            {
                _societeSelectionnee = value;
                if (value == null)
                    return;
                TexteDEnteteDetail = "Details de " + _societeSelectionnee.RaisonSociale + " (id:" + _societeSelectionnee.ID + ")";
                RaisonSociale = _societeSelectionnee.RaisonSociale;
                DateCreation = _societeSelectionnee.DateCreation;
                NbActions = _societeSelectionnee.NbActions;
                ValeurUnitaire = _societeSelectionnee.ValeurUnitaire;
                //Actionnaires = _societeSelectionnee.Actionnaires;
                OnPropertyChanged("ProprietaireSelectionne");
            }
        }
        #endregion
        private void cmdPreparerNouvelle(object param)
        {
            RaisonSociale = "";
            NbActions = 0;
            ValeurUnitaire = 0;
            DateCreation = new DateTime();
            SocieteSelectionnee = null;
            TexteDEnteteDetail = "Création d'une société";
        }

        private void cmdInserer(object param)
        {
            /*if (SocieteSelectionne == null)
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
            }*/
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string nomProp)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nomProp));
            }
        }


    }
}
