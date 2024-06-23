using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kassen.Migrations
{
    /// <inheritdoc />
    public partial class DrinkingBuddy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jackpot");

            migrationBuilder.CreateTable(
                name: "DrinkingBuddy",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FuckerName = table.Column<string>(type: "TEXT", nullable: false),
                    FuckedName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkingBuddy", x => x.id);
                    table.ForeignKey(
                        name: "FK_DrinkingBuddy_Players_FuckedName",
                        column: x => x.FuckedName,
                        principalTable: "Players",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrinkingBuddy_Players_FuckerName",
                        column: x => x.FuckerName,
                        principalTable: "Players",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrinkingBuddy_FuckedName",
                table: "DrinkingBuddy",
                column: "FuckedName");

            migrationBuilder.CreateIndex(
                name: "IX_DrinkingBuddy_FuckerName",
                table: "DrinkingBuddy",
                column: "FuckerName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrinkingBuddy");

            migrationBuilder.CreateTable(
                name: "Jackpot",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlayerNames = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jackpot", x => x.id);
                });
        }
    }
}
