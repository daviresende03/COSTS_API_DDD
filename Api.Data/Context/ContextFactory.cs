using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace Api.Data.Context;

public class ContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        //Usado para Criar as Migrações
        var connectionString = "server=localhost;userid=root;password=1234;database=costs;port=3307";
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext> ();
        optionsBuilder.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
        return new AppDbContext(optionsBuilder.Options);
    }
}
