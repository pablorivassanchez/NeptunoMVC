using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neptuno.Data.EFEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neptuno.Data.Configurations
{
    public class PedidoConfig : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("IdPedido").ValueGeneratedNever();

            entity.Property(e => e.Cargo).HasColumnType("money");

            entity.Property(e => e.CiudadDestinatario).HasMaxLength(15);

            entity.Property(e => e.CodPostalDestinatario).HasMaxLength(10);

            entity.Property(e => e.Destinatario).HasMaxLength(40);

            entity.Property(e => e.DireccionDestinatario).HasMaxLength(60);

            entity.Property(e => e.FechaEntrega).HasColumnType("datetime");

            entity.Property(e => e.FechaEnvio).HasColumnType("datetime");

            entity.Property(e => e.FechaPedido).HasColumnType("datetime");

            entity.Property(e => e.IdCliente)
                .IsRequired()
                .HasMaxLength(5);

            entity.Property(e => e.PaisDestinatario).HasMaxLength(15);

            entity.Property(e => e.RegionDestinatario).HasMaxLength(15);

            entity.Property(e => e.Activo).HasDefaultValue(1);

            entity.HasOne(d => d.FormaEnvioNavigation)
                .WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.FormaEnvio)
                .HasConstraintName("FK_Pedido_CompaniaEnvio");

            entity.HasOne(d => d.IdClienteNavigation)
                .WithMany(p => p.Pedido)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pedido_Cliente");

            entity.HasOne(d => d.IdEmpleadoNavigation)
                .WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("FK_Pedido_Empleado");
        }
    }
}
