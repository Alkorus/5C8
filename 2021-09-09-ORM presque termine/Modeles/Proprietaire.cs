using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bourse21.Modeles
{
    [Table("proprietaires")]
    public class Proprietaire
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public DateTime Naissance { get; set; }
        public DateTime Creation { get; set; }
        public int Liquidite { get; set; }
        public int VersionImage { get; set; }
        public ObservableCollection<Transaction> PorteFeuille { get; set; }


    }
}
