using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestesDePerformance1.Models;

namespace TestesDePerformance1.Data;

public class LojaDeGuitarraDbContext : IdentityDbContext
{
    public DbSet<Guitarra> Guitarra { get; set; }
    public DbSet<Marcas> Marcas { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

        var stringConnection = config.GetConnectionString("StringConnection");

        optionsBuilder.UseSqlServer(stringConnection);
    }
}
