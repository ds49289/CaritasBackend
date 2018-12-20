using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Caritas2.Models
{
    public class SpolConfiguration: EntityTypeConfiguration<SpolModel>
    {
        public SpolConfiguration()
        {
            this.HasKey<int>(s => s.Id);
            this.Property(s => s.AktivnostSpola).IsRequired();

            HasMany(s => s.Korisnici)
                .WithOptional(k => k.Spol)
                .HasForeignKey(k => k.SpolID);

            Property(s => s.NazivSpola).HasMaxLength(255);

            HasIndex(s => s.NazivSpola)
                .IsUnique();
        }
    }
}