using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neptuno.Domain.Entities;

namespace Neptuno.Data.Configurations
{
    public class ProductoConfig : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("IdProducto").ValueGeneratedNever();

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

            entity.Property(e => e.Activo).HasDefaultValue(1);
        }
    }
}
