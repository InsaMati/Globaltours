using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Datos.Migrations
{
    public class LugarConfiguration : IEntityTypeConfiguration<Lugar>
    {
        public void Configure(EntityTypeBuilder<Lugar> builder)
        {
            builder.Property(l => l.Id).IsRequired();
            builder.Property(l => l.Nombre).IsRequired().HasMaxLength(80);
            builder.Property(l => l.Descripcion).IsRequired();
            builder.Property(l => l.GastoAproximado).IsRequired();

            /* Relaciones */

            builder.HasOne(c => c.Categoria).WithMany()
            .HasForeignKey(l => l.CategoriaId);

            builder.HasOne(p => p.Pais).WithMany()
            .HasForeignKey(l => l.PaisId);
        }
    }
}