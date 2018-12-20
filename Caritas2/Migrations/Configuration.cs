namespace Caritas2.Migrations
{
    using Caritas2.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Caritas2.CaritasDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Caritas2.CaritasDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Korisnici.AddOrUpdate(new KorisnikModel()
            {
                Id = 1,
                PrezimeKorisnika = "sir",
                ImeKorisnika = "burek",
                DatumRodjenja = new DateTime(1997, 3, 4),
                OIB = "11111111111",
                EmailKorisnika = "burek@ser.com",
                PonasanjeID = 1,
                SpolID = 1,
                PostanskiBroj = 10000,
                Username = "username"
            },

            new KorisnikModel()
            {
                Id = 2,
                PrezimeKorisnika = "s33333r",
                ImeKorisnika = "bueeeeek",
                DatumRodjenja = new DateTime(1995, 7, 4),
                OIB = "11112221111",
                EmailKorisnika = "burek123@ser.com",
                PonasanjeID = 1,
                SpolID = 1,
                PostanskiBroj = 11234,
                Username = "username12"
            },

            new KorisnikModel()
            {
                Id = 3,
                PrezimeKorisnika = "srerere",
                ImeKorisnika = "bueerrreek",
                DatumRodjenja = new DateTime(1911, 7, 4),
                OIB = "11122222222",
                EmailKorisnika = "burek123@seres.com",
                PonasanjeID = 1,
                SpolID = 2,
                PostanskiBroj = 33234,
                Username = "username312"
            }
           
            );
            context.Spolovi.AddOrUpdate(new SpolModel()
            {
                Id = 1,
                NazivSpola = "Zensko",
                AktivnostSpola = true
            },
            new SpolModel()
            {
                Id = 2,
                NazivSpola = "Musko",
                AktivnostSpola = true
            });

            context.Ponasanja.AddOrUpdate(new PonasanjeModel()
            {
                Id = 1,
                NazivPonasanja = "Gucci",
                AktivnostPonasanja = true
            },
            new PonasanjeModel()
            {
                Id = 2,
                NazivPonasanja = "Lose",
                AktivnostPonasanja = true
            },
            new PonasanjeModel()
                        {
                Id = 4,
                NazivPonasanja = "Agresivno",
                AktivnostPonasanja = true
                        },
            new PonasanjeModel()
            {
                Id = 3,
                NazivPonasanja = "Lose2",
                AktivnostPonasanja = true
            });
        }
    }
}
