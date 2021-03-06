﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neptuno.Domain.Entities;

namespace Neptuno.Data.Configurations
{
    public class LineaPedidoConfig : IEntityTypeConfiguration<LineaPedido>
    {
        public void Configure(EntityTypeBuilder<LineaPedido> entity)
        {
            entity.Ignore(b => b.Id);

            entity.HasKey(e => new { e.IdPedido, e.IdProducto });

            entity.Property(e => e.PrecioUnidad).HasColumnType("money");

            entity.HasOne(d => d.PedidoEnt)
                .WithMany(p => p.LineasPedido)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LineaPedido_Pedido");

            entity.HasOne(d => d.ProductoEnt)
                .WithMany(p => p.LineasPedido)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LineaPedido_Producto");

            entity.Property(e => e.Activo).HasDefaultValue(1);
        }
    }
}
