using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Migrations
{
    public partial class renamed_properties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Movies_FilmId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Tariffs_Movies_FilmId",
                table: "Tariffs");

            migrationBuilder.RenameColumn(
                name: "FilmId",
                table: "Tariffs",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Tariffs_FilmId",
                table: "Tariffs",
                newName: "IX_Tariffs_MovieId");

            migrationBuilder.RenameColumn(
                name: "FilmId",
                table: "Schedules",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_FilmId",
                table: "Schedules",
                newName: "IX_Schedules_MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Movies_MovieId",
                table: "Schedules",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tariffs_Movies_MovieId",
                table: "Tariffs",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Movies_MovieId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Tariffs_Movies_MovieId",
                table: "Tariffs");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Tariffs",
                newName: "FilmId");

            migrationBuilder.RenameIndex(
                name: "IX_Tariffs_MovieId",
                table: "Tariffs",
                newName: "IX_Tariffs_FilmId");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Schedules",
                newName: "FilmId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_MovieId",
                table: "Schedules",
                newName: "IX_Schedules_FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Movies_FilmId",
                table: "Schedules",
                column: "FilmId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tariffs_Movies_FilmId",
                table: "Tariffs",
                column: "FilmId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
