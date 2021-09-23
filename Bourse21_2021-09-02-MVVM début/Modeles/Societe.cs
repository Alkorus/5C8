using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bourse21.Modeles
{
    public class Societe
    {
        public int ID { get; set; }
        public string RaisonSociale { get; set; }
        public int NbActions { get; set; }
        public int ValeurUnitaire { get; set; }
        public DateTime DateCreation { get; set; }
        public int VersionImage { get; set; }
        //public ObservableCollection<Transaction> Actionnaires { get; set; }

        public Societe() { }

    }
}
