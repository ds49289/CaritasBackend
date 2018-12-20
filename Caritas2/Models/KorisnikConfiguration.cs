using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Caritas2.Models
{
    public class KorisnikConfiguration: EntityTypeConfiguration<KorisnikModel>
    {
        public KorisnikConfiguration()
        {
            this.ToTable("Korisnici");
            this.HasKey<int>(s => s.Id);
            this.Property(c => c.ImeKorisnika).IsRequired();
            this.Property(c => c.PrezimeKorisnika).IsRequired();

            this.Property(c => c.OIB).HasMaxLength(11);
            this.Property(c => c.DatumRodjenja).IsOptional();
            this.Property(c => c.EmailKorisnika).IsOptional();
            this.Property(c => c.PostanskiBroj).IsOptional();

            this.HasOptional(s => s.Spol)
                .WithMany(s => s.Korisnici)
                .HasForeignKey(s => s.SpolID);
            this.HasOptional(s => s.Ponasanje)
                .WithMany(s => s.Korisnici)
                .HasForeignKey(s => s.PonasanjeID);
        }
    }
}