using Microsoft.EntityFrameworkCore.Migrations;
using TestesDePerformance1.Models;
namespace TestesDePerformance1.Data.Migrations;

    /// <inheritdoc />
    public partial class AdicionarGuitarras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new LojaDeGuitarraDbContext();
            context.Guitarra.AddRange(GetCargaInicialGuitarras());
            context.SaveChanges();
        }

        private IList<Guitarra> GetCargaInicialGuitarras()
        {
        return new List<Guitarra>()
            {
            new Guitarra
            {
                Nome = "Kiko SP3",
                Descricao = "A KikoSP3 é uma incrível guitarra Signature do Guitarrista KIKO LOUREIRO.",
                ImagemUri = "/images/Guitarras/kikosp3.png",
                Preco = 999.00,
                Cordas = 6,
                MarcaId = 1,
                DataCadastro = DateTime.Now
            },
            };
        }
    }
