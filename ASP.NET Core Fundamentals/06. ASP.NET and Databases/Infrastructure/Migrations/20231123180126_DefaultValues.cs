using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DefaultValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "default_values",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "The unique identifier for the table.")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    credits_with_sentinel = table.Column<int>(type: "integer", nullable: false, defaultValue: 10, comment: "The default value for the integer with custom sentinel"),
                    credits_without_sentinel = table.Column<int>(type: "integer", nullable: false, defaultValue: 10, comment: "The default value for the integer."),
                    is_active_default_true = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "The default value for the bool true."),
                    is_active_default_false = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false, comment: "The default value for the bool false.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_default_values", x => x.id);
                },
                comment: "Default value.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "default_values");
        }
    }
}
