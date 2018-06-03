using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neptuno.Data.Configurations
{
    public class CategoriaConfig : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> entity)
        {
            entity.HasKey(e => e.IdCategoria);

            entity.Property(e => e.IdCategoria).ValueGeneratedNever();

            entity.Property(e => e.NombreCategoria)
                .IsRequired()
                .HasMaxLength(15);
        }
    }
}
