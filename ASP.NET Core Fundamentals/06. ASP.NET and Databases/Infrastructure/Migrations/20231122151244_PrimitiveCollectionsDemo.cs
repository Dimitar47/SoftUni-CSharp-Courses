using System;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PrimitiveCollectionsDemo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "primitive_collections",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "The unique identifier for the table.")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ints = table.Column<int[]>(type: "integer[]", nullable: false, comment: "Collection of integers."),
                    strings = table.Column<string[]>(type: "text[]", nullable: false, comment: "Collection of strings."),
                    date_times = table.Column<Collection<DateTime>>(type: "timestamp with time zone[]", nullable: false, comment: "Collection of timestamps."),
                    dates = table.Column<DateOnly[]>(type: "date[]", nullable: false, comment: "Collection of dates.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_primitive_collections", x => x.id);
                },
                comment: "Collections of primitive types.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "primitive_collections");
        }
    }
}
