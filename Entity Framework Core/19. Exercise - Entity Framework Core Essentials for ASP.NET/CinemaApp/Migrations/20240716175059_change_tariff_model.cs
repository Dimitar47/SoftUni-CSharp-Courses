using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Migrations
{
    public partial class change_tariff_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tariffs_Movies_MovieId",
                table: "Tariffs");

            migrationBuilder.DropIndex(
                name: "IX_Tariffs_MovieId",
                table: "Tariffs");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Tariffs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Tariffs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tariffs_MovieId",
                table: "Tariffs",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tariffs_Movies_MovieId",
                table: "Tariffs",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
