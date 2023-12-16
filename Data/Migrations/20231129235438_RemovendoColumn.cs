using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestesDePerformance1.Migrations
{
    /// <inheritdoc />
    public partial class RemovendoColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescricaoMarca",
                table: "Guitarra");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DescricaoMarca",
                table: "Guitarra",
                type: "int",
                nullable: true);
        }
    }
}
