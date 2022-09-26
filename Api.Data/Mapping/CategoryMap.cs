using Microsoft.EntityFrameworkCore;
using Api.Domain.Entities;
namespace Api.Data.Mapping;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("categorias");

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("int");

        builder.Property(c => c.Name)
            .HasColumnName("nome")
            .HasColumnType("varchar(40)")
            .IsRequired();
    }
}
