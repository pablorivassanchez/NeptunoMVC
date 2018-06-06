using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neptuno.Data.EFEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neptuno.Data.Configurations
{
    public class CompaniaEnvioConfig : IEntityTypeConfiguration<CompaniaEnvio>
    {
        public void Configure(EntityTypeBuilder<CompaniaEnvio> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("IdCompaniaEnvio").ValueGeneratedNever();

            entity.Property(e => e.NombreCompania)
                .IsRequired()
                .HasMaxLength(40);

            entity.Property(e => e.Telefono).HasMaxLength(24);

            entity.Property(e => e.Activo).HasDefaultValue(1);
        }
    }
}
