using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PrimitiveCollectionsSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "primitive_collections",
                columns: new[] { "id", "date_times", "dates", "ints", "strings" },
                values: new object[,]
                {
                    { 1, new[] { new DateTime(2021, 1, 1, 1, 1, 1, 0, DateTimeKind.Utc), new DateTime(2021, 2, 1, 2, 2, 2, 0, DateTimeKind.Utc), new DateTime(2021, 3, 1, 3, 3, 3, 0, DateTimeKind.Utc) }, new[] { new DateOnly(2021, 1, 1), new DateOnly(2021, 2, 1), new DateOnly(2021, 3, 1) }, new[] { 1, 2, 3 }, new[] { "one", "two", "three" } },
                    { 2, new[] { new DateTime(2021, 4, 1, 4, 4, 4, 0, DateTimeKind.Utc), new DateTime(2021, 5, 1, 5, 5, 5, 0, DateTimeKind.Utc), new DateTime(2021, 6, 1, 6, 6, 6, 0, DateTimeKind.Utc) }, new[] { new DateOnly(2021, 4, 1), new DateOnly(2021, 5, 1), new DateOnly(2021, 6, 1) }, new[] { 4, 5, 6 }, new[] { "four", "five", "six" } },
                    { 3, new[] { new DateTime(2021, 7, 1, 7, 7, 7, 0, DateTimeKind.Utc), new DateTime(2021, 8, 1, 8, 8, 8, 0, DateTimeKind.Utc), new DateTime(2021, 9, 1, 9, 9, 9, 0, DateTimeKind.Utc) }, new[] { new DateOnly(2021, 7, 1), new DateOnly(2021, 8, 1), new DateOnly(2021, 9, 1) }, new[] { 7, 8, 9 }, new[] { "seven", "eight", "nine" } }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "primitive_collections",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "primitive_collections",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "primitive_collections",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
