using Microsoft.EntityFrameworkCore;
using Api.Domain.Entities;
namespace Api.Data.Mapping;

public class ServiceMap : IEntityTypeConfiguration<Service>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Service> builder)
    {
        builder.ToTable("servicos");

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("int(6)");

        builder.Property(c => c.Name)
            .HasColumnName("nome")
            .HasColumnType("varchar(60)")
            .IsRequired();

        builder.Property(c => c.Descritpion)
            .HasColumnName("descricao")
            .HasColumnType("varchar(120)")
            .IsRequired();

        builder.Property(c => c.Cost)
            .HasColumnName("custo")
            .HasColumnType("decimal(10,2)")
            .IsRequired();

        builder.Property(c => c.ProjectId)
            .HasColumnName("projeto")
            .HasColumnType("int")
            .IsRequired();
    }
}
