using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Migrations
{
    public partial class seed_tickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "BasePrice", "ScheduleId", "SeatId", "TariffId", "UserId" },
                values: new object[] { 1, 20m, 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "BasePrice", "ScheduleId", "SeatId", "TariffId", "UserId" },
                values: new object[] { 2, 20m, 3, 2, 3, 1 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "BasePrice", "ScheduleId", "SeatId", "TariffId", "UserId" },
                values: new object[] { 3, 20m, 2, 3, 2, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
