using Microsoft.EntityFrameworkCore.Migrations;
using TestesDePerformance1.Data;
using TestesDePerformance1.Models;

#nullable disable

namespace TestesDePerformance1.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoMarcas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new LojaDeGuitarraDbContext();
            context.Marcas.AddRange(GetCargaInicial());
            context.SaveChanges();
        }

        private IList<Marcas> GetCargaInicial()
        {
            return new List<Marcas>()
            {
               new Marcas() { DescricaoMarca = "Ibanez" },
               new Marcas() { DescricaoMarca = "Jacksons" },
               new Marcas() { DescricaoMarca = "Gibson" }
            };
        }
    }
}
