using Caritas2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Caritas2
{
    public class CaritasDbContext: DbContext  
    {

        public CaritasDbContext(): base("name=CaritasConnection")
        {
            Database.SetInitializer<CaritasDbContext>(new DropCreateDatabaseIfModelChanges<CaritasDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new KorisnikConfiguration());
            modelBuilder.Configurations.Add(new PonasanjeConfiguration());
            modelBuilder.Configurations.Add(new SpolConfiguration());

        }

        public DbSet<KorisnikModel> Korisnici { get; set; }
        public DbSet<SpolModel> Spolovi { get; set; }
        public DbSet<PonasanjeModel> Ponasanja { get; set; }
    }
}