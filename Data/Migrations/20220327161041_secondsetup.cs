using Microsoft.EntityFrameworkCore.Migrations;

namespace CookingHeaven.Data.Migrations
{
    public partial class secondsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RetetaDescriere",
                table: "Retete");

            migrationBuilder.AddColumn<string>(
                name: "RetetaIngrediente",
                table: "Retete",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RetetaPreparare",
                table: "Retete",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RetetaIngrediente",
                table: "Retete");

            migrationBuilder.DropColumn(
                name: "RetetaPreparare",
                table: "Retete");

            migrationBuilder.AddColumn<string>(
                name: "RetetaDescriere",
                table: "Retete",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
