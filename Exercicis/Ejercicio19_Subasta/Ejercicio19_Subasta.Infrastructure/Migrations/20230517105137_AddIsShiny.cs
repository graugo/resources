using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ejercicio19_Subasta.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsShiny : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsShiny",
                table: "Auctions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShiny",
                table: "Auctions");
        }
    }
}
