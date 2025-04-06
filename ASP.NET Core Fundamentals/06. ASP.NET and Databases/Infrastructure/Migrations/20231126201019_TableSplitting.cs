using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TableSplitting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_employee",
                table: "employee");

            migrationBuilder.RenameTable(
                name: "employee",
                newName: "employees");

            migrationBuilder.AddPrimaryKey(
                name: "pk_employees",
                table: "employees",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "Prescription ID")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nrn = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false, comment: "National referent number"),
                    medication = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Prescribed medication"),
                    patient_age = table.Column<int>(type: "integer", nullable: false, comment: "Patient age"),
                    patient_gender = table.Column<int>(type: "integer", nullable: false, comment: "Patient gender"),
                    patient_ekatte = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "Patient EKATTE"),
                    mpi = table.Column<Guid>(type: "uuid", nullable: false, comment: "Patient identifier"),
                    medical_practitioner_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Medical practitioner name"),
                    uin = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "Medical practitioner UIN"),
                    medical_practitioner_telephone = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, comment: "Medical practitioner telephone")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_prescriptions", x => x.id);
                },
                comment: "Prescriptions table");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_employees",
                table: "employees");

            migrationBuilder.RenameTable(
                name: "employees",
                newName: "employee");

            migrationBuilder.AddPrimaryKey(
                name: "pk_employee",
                table: "employee",
                column: "id");
        }
    }
}
