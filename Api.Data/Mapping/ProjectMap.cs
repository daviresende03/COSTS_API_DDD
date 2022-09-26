using Microsoft.EntityFrameworkCore;
using Api.Domain.Entities;
namespace Api.Data.Mapping;

public class ProjectMap : IEntityTypeConfiguration<Project>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("projetos");

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("int");

        builder.Property(c => c.Name)
            .HasColumnName("nome")
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.Property(c => c.Budget)
            .HasColumnName("orcamento")
            .HasColumnType("decimal(10,2)")
            .IsRequired();

        builder.Property(c => c.Cost)
            .HasColumnName("custo")
            .HasColumnType("decimal(10,2)")
            .IsRequired();

        builder.Property(c => c.CategoryId)
            .HasColumnName("categoria")
            .HasColumnType("int")
            .IsRequired();
    }
}
