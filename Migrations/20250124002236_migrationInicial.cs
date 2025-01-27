using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MemoryGame.Migrations
{
    /// <inheritdoc />
    public partial class migrationInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersScore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    CardsQuantity = table.Column<int>(type: "int", nullable: false),
                    GameTime = table.Column<TimeSpan>(type: "time(3)", nullable: false),
                    GameDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersScore", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersScore");
        }
    }
}
