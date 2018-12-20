using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Caritas2.Models
{
    public class PonasanjeConfiguration: EntityTypeConfiguration<PonasanjeModel>
    {
        public PonasanjeConfiguration()
        {
            this.HasKey<int>(s => s.Id);
            this.Property(s => s.AktivnostPonasanja).IsRequired();

            this.Property(p => p.NazivPonasanja).HasMaxLength(255);

            HasIndex(p => p.NazivPonasanja)
                .IsUnique();
        }
    }
}