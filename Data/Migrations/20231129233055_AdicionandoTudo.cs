using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestesDePerformance1.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoTudo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    MarcaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoMarca = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.MarcaId);
                });

            migrationBuilder.CreateTable(
                name: "Guitarra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cordas = table.Column<int>(type: "int", nullable: false),
                    ImagemUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    EntregaExpressa = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MarcaId = table.Column<int>(type: "int", nullable: true),
                    DescricaoMarca = table.Column<int>(type: "int", nullable: true),
                    MarcasMarcaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guitarra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guitarra_Marcas_MarcasMarcaId",
                        column: x => x.MarcasMarcaId,
                        principalTable: "Marcas",
                        principalColumn: "MarcaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guitarra_MarcasMarcaId",
                table: "Guitarra",
                column: "MarcasMarcaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guitarra");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
