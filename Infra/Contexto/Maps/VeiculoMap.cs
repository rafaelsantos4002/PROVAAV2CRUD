using Dominio.Entidades;
using Dominio.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infra.Contexto.Maps
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("Veiculos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Marca).IsRequired().HasMaxLength(50).HasColumnType("Varchar(50)");
            builder.Property(x => x.Modelo).IsRequired().HasMaxLength(15).HasColumnType("Varchar(15)");
            builder.Property(x => x.Ano).IsRequired().HasMaxLength(15).HasColumnType("Varchar(15)");
            builder.Property(x => x.Quilometragem).IsRequired().HasMaxLength(15).HasColumnType("Varchar(15)");

        }
    }
}