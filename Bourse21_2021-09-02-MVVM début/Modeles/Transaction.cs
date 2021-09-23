using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bourse21.Modeles
{
    [Table("transactions")]
    public class Transaction
    {
        public int Id { get; set; }
        public int NbActions { get; set; }
        public int CoutUnitaire { get; set; }
        public DateTime DateTrx { get; set; }

        private int _total;
        [NotMapped] // La propriétée qui suit n'est pas écrite dans la BD
        public int Total
        {
            get { return CoutUnitaire * NbActions; }
            set { _total = value; }
        }
        public Proprietaire Acheteur { get; set; }
        public Societe CIEVendue { get; set; }
        public Transaction()
        {

        }
    }
}
