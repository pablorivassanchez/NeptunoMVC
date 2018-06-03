﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neptuno.Data.Configurations
{
    public class ProductoConfig : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> entity)
        {
            entity.HasKey(e => e.IdProducto);

            entity.Property(e => e.IdProducto).ValueGeneratedNever();

            entity.Property(e => e.CantidadPorUnidad).HasMaxLength(20);

            entity.Property(e => e.NombreProducto)
                .IsRequired()
                .HasMaxLength(40);

            entity.Property(e => e.PrecioUnidad).HasColumnType("money");

            entity.HasOne(d => d.IdCategoriaNavigation)
                .WithMany(p => p.Producto)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK_Producto_Categoria");

            entity.HasOne(d => d.IdProveedorNavigation)
                .WithMany(p => p.Producto)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("FK_Producto_Proveedor");
        }
    }
}