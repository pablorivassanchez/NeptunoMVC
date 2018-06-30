using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neptuno.Domain.Entities;

namespace Neptuno.Data.Configurations
{
    public class CategoriaConfig : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("IdCategoria").ValueGeneratedNever();

            entity.Property(e => e.NombreCategoria)
                .IsRequired()
                .HasMaxLength(15);

            entity.Property(e => e.Activo).HasDefaultValue(1);
        }
    }
}
