using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ejercicio19_Subasta.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationIdentifier = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationIdentifier);
                });

            migrationBuilder.CreateTable(
                name: "Pokemon",
                columns: table => new
                {
                    PokemonIdentifier = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemon", x => x.PokemonIdentifier);
                });

            migrationBuilder.CreateTable(
                name: "PokemonLocation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<int>(type: "int", nullable: false),
                    MaxChance = table.Column<int>(type: "int", nullable: false),
                    PokemonId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PokemonLocation_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationIdentifier",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonLocation_Pokemon_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemon",
                        principalColumn: "PokemonIdentifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    AuctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuctionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntryPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ActualPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumberBid = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<TimeSpan>(type: "time", nullable: false),
                    PokemonLocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.AuctionId);
                    table.ForeignKey(
                        name: "FK_Auctions_PokemonLocation_PokemonLocationId",
                        column: x => x.PokemonLocationId,
                        principalTable: "PokemonLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Historic",
                columns: table => new
                {
                    HistoricId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sold = table.Column<bool>(type: "bit", nullable: false),
                    AuctionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historic", x => x.HistoricId);
                    table.ForeignKey(
                        name: "FK_Historic_Auctions_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "Auctions",
                        principalColumn: "AuctionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_PokemonLocationId",
                table: "Auctions",
                column: "PokemonLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Historic_AuctionId",
                table: "Historic",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonLocation_LocationId",
                table: "PokemonLocation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonLocation_PokemonId",
                table: "PokemonLocation",
                column: "PokemonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historic");

            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.DropTable(
                name: "PokemonLocation");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Pokemon");
        }
    }
}
