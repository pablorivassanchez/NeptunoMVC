using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neptuno.Data.Configurations
{
    public class ProveedorConfig : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> entity)
        {
            entity.HasKey(e => e.IdProveedor);

            entity.Property(e => e.IdProveedor).ValueGeneratedNever();

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
        }
    }
}
