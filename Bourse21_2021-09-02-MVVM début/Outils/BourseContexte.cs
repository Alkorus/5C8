using Bourse21.Modeles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bourse21.Outils
{
    //pour implémanter EF-Core on doit hériter de DbContext
    class BourseContexte : DbContext
    {
        public DbSet<Proprietaire> Capitalistes { get; set; }
        public DbSet<Societe> Societes { get; set; }
        public DbSet<Transaction> RegistreTrx { get; set; }

        // string de connexion MySQL
        private const string connexionString = "server=localhost;port=3306;database=bourse21;user=root;password=";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            ServerVersion sv = MariaDbServerVersion.AutoDetect(connexionString);
            options.UseMySql(connexionString, sv);
        }
    }
}
