using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neptuno.Data.EFEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neptuno.Data.Configurations
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("IdCliente").HasMaxLength(5).ValueGeneratedNever();

            entity.Property(e => e.CargoContacto).HasMaxLength(30);

            entity.Property(e => e.Ciudad).HasMaxLength(15);

            entity.Property(e => e.CodPostal).HasMaxLength(10);

            entity.Property(e => e.Direccion).HasMaxLength(60);

            entity.Property(e => e.Fax).HasMaxLength(24);

            entity.Property(e => e.NombreCompania)
                .IsRequired()
                .HasMaxLength(40);

            entity.Property(e => e.NombreContacto).HasMaxLength(30);

            entity.Property(e => e.Pais).HasMaxLength(15);

            entity.Property(e => e.Region).HasMaxLength(15);

            entity.Property(e => e.Telefono).HasMaxLength(24);

            entity.Property(e => e.Activo).HasDefaultValue(1);
        }
    }
}
