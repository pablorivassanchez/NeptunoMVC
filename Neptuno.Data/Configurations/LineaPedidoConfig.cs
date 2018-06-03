using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neptuno.Data.Configurations
{
    public class LineaPedidoConfig : IEntityTypeConfiguration<LineaPedido>
    {
        public void Configure(EntityTypeBuilder<LineaPedido> entity)
        {
            entity.HasKey(e => new { e.IdPedido, e.IdProducto });

            entity.Property(e => e.PrecioUnidad).HasColumnType("money");

            entity.HasOne(d => d.IdPedidoNavigation)
                .WithMany(p => p.LineaPedido)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LineaPedido_Pedido");

            entity.HasOne(d => d.IdProductoNavigation)
                .WithMany(p => p.LineaPedido)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LineaPedido_Producto");
        }
    }
}
