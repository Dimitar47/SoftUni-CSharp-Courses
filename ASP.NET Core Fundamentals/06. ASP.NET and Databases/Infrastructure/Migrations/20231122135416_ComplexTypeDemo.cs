using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ComplexTypeDemo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "The unique identifier for the person.")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "The name of the person."),
                    current_address_city = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "The city of the address."),
                    current_address_country = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "The country of the address."),
                    current_address_line1 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "The first line of the address."),
                    current_address_line2 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "The second line of the address."),
                    current_address_post_code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "The post code of the address."),
                    permanent_address_city = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "The city of the address."),
                    permanent_address_country = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "The country of the address."),
                    permanent_address_line1 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "The first line of the address."),
                    permanent_address_line2 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true, comment: "The second line of the address."),
                    permanent_address_post_code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "The post code of the address.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_people", x => x.id);
                },
                comment: "A person.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "people");
        }
    }
}
