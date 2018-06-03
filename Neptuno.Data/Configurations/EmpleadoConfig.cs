using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neptuno.Data.Configurations
{
    public class EmpleadoConfig : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> entity)
        {
            entity.HasKey(e => e.IdEmpleado);

            entity.Property(e => e.IdEmpleado).ValueGeneratedNever();

            entity.Property(e => e.Apellidos)
                .IsRequired()
                .HasMaxLength(20);

            entity.Property(e => e.Cargo).HasMaxLength(30);

            entity.Property(e => e.Ciudad).HasMaxLength(15);

            entity.Property(e => e.CodPostal).HasMaxLength(10);

            entity.Property(e => e.Direccion).HasMaxLength(60);

            entity.Property(e => e.Extension).HasMaxLength(4);

            entity.Property(e => e.FechaContratacion).HasColumnType("datetime");

            entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

            entity.Property(e => e.Foto).HasMaxLength(255);

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(10);

            entity.Property(e => e.Pais).HasMaxLength(15);

            entity.Property(e => e.Region).HasMaxLength(15);

            entity.Property(e => e.TelDomicilio).HasMaxLength(24);

            entity.Property(e => e.Tratamiento).HasMaxLength(25);
        }
    }
}
