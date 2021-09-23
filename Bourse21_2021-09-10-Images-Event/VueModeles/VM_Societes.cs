using Bourse21.Modeles;
using Bourse21.Outils;
using Microsoft.EntityFrameworkCore;
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
        public ICommand cmdSupprimer_Societe { get; set; }

        public VM_Societes()
        {
            cmdPreparerNouvelle_Societe = new Commande(cmdPreparerNouvelle);
            cmdInserer_Societe = new Commande(cmdInserer);
            cmdModifier_Societe = new Commande(cmdModifier);
            cmdSupprimer_Societe = new Commande(cmdSupprimer);
            initSocietes();
        }

        private void initSocietes()
        {
            SommaireSocietes = new ObservableCollection<Societe>();

            //var sReq = from soc in OutilEF.BrsCtx.Societes select soc;
            var sReq = from soc in OutilEF.BrsCtx.Societes.Include("Actionnaires.Acheteur") select soc;
            foreach (Societe s in sReq)
                SommaireSocietes.Add(s);

            if (SommaireSocietes.Count > 0)
                TexteDEnteteListe = SommaireSocietes.Count + " sociétés";
            else
                TexteDEnteteListe = "Aucune société";
            

        }

        private void cmdSupprimer(object param)
        {
            if (SocieteSelectionnee == null)
                return;

            OutilEF.BrsCtx.Societes.Remove(SocieteSelectionnee);
            OutilEF.BrsCtx.SaveChanges();

            SocieteSelectionnee = null;
            TexteDEnteteDetail = "Suppression réussie";

            RaisonSociale = "";
            DateCreation = new DateTime();
            ValeurUnitaire = 0;
            NbActions = 0;
            
            initSocietes();
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
                Actionnaires = _societeSelectionnee.Actionnaires;
                OnPropertyChanged("ProprietaireSelectionne");
            }
        }

        private Collection<Transaction> _actionnaires;
        public Collection<Transaction> Actionnaires
        {
            get { return _actionnaires; }
            set
            {
                _actionnaires = value;
                OnPropertyChanged("Actionnaires");
            }
        }

        #endregion
        private void cmdModifier(object param)
        {
            Societe sMod = OutilEF.BrsCtx.Societes.Find(SocieteSelectionnee.ID);
            sMod.RaisonSociale = RaisonSociale;
            sMod.DateCreation = DateCreation;
            sMod.ValeurUnitaire = ValeurUnitaire;
            sMod.NbActions = NbActions;


            OutilEF.BrsCtx.SaveChanges();
            initSocietes();
            SocieteSelectionnee = sMod;
        }

        private void cmdInserer(object param)
        {
            if (SocieteSelectionnee == null)
            {
                Societe s = new Societe();
                s.RaisonSociale = RaisonSociale;
                s.DateCreation = DateCreation;
                s.ValeurUnitaire = ValeurUnitaire;
                s.NbActions = NbActions;
                

                SommaireSocietes.Add(s);
                SocieteSelectionnee = s;
                TexteDEnteteListe = "Liste de " + SommaireSocietes.Count + " société(s)";

                OutilEF.BrsCtx.Societes.Add(s);
                OutilEF.BrsCtx.SaveChanges();
            }
       }


        private void cmdPreparerNouvelle(object param)
        {
            RaisonSociale = "";
            NbActions = 0;
            ValeurUnitaire = 0;
            DateCreation = new DateTime();
            SocieteSelectionnee = null;
            TexteDEnteteDetail = "Création d'une société";
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
