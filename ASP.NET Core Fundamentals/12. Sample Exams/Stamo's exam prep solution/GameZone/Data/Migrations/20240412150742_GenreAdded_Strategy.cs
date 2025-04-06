using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameZone.Data.Migrations
{
    public partial class GenreAdded_Strategy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Strategy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
