using KoliPortal.Lib.MODEL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoliPortal.Lib.DATA
{
    public class KoliportalDBContext : DbContext
    {
        public DbSet<DiakAdatok> DiakAdatok { get; set; }
        public DbSet<Felhasznalok> Felhasznalok { get; set; }
        public DbSet<FizetesTipusok> FizetesTipusok { get; set; }
        public DbSet<KarbantartasiKeresek> KarbantartasiKeresek { get; set; }
        public DbSet<KarbantartasStatuszok> KarbantartasStatuszok { get; set; }
        public DbSet<Penzugyek> Penzugyek { get; set; }
        public DbSet<Szerepkorok> Szerepkorok { get; set; }
        public DbSet<SzobaBeosztasok> SzobaBeosztasok { get; set; }
        public DbSet<Szobak> Szobak { get; set; }

        public KoliportalDBContext()
        {

        }

        public KoliportalDBContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
