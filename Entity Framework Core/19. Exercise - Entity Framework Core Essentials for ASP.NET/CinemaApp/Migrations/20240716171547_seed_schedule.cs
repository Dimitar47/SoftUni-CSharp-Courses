using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Migrations
{
    public partial class seed_schedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "Duration", "HallId", "MovieId", "Start" },
                values: new object[] { 1, new TimeSpan(0, 1, 38, 0, 0), 1, 1, new DateTime(2024, 7, 23, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "Duration", "HallId", "MovieId", "Start" },
                values: new object[] { 2, new TimeSpan(0, 1, 38, 0, 0), 4, 2, new DateTime(2024, 7, 23, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "Duration", "HallId", "MovieId", "Start" },
                values: new object[] { 3, new TimeSpan(0, 1, 38, 0, 0), 2, 3, new DateTime(2024, 7, 23, 20, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
