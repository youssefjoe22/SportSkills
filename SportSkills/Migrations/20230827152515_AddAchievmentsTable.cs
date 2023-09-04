using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportSkills.Migrations
{
    /// <inheritdoc />
    public partial class AddAchievmentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "achievments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    playerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_achievments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_achievments_players_playerId",
                        column: x => x.playerId,
                        principalTable: "players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_achievments_playerId",
                table: "achievments",
                column: "playerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "achievments");
        }
    }
}
