using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelApp.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key and unique identifier for the guest."),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The first name of the guest."),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The last name of the guest."),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date of birth of the guest."),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "The address of the guest."),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true, comment: "The phone number of the guest."),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "The email address of the guest.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key and unique identifier for the hotel."),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "The name of the hotel."),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "The address of the hotel."),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "The image URL for the hotel's picture."),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "The contact phone number of the hotel."),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "The contact email address of the hotel."),
                    Stars = table.Column<int>(type: "int", nullable: false, comment: "The star rating of the hotel, ranging from 1 to 5."),
                    CheckinTime = table.Column<TimeSpan>(type: "time", nullable: false, comment: "The standard check-in time for the hotel."),
                    CheckoutTime = table.Column<TimeSpan>(type: "time", nullable: false, comment: "The standard checkout time for the hotel.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key and unique identifier for the room type."),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The name of the room type - Single, Double, Suite."),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "A description of the room type, detailing features or amenities."),
                    PricePerNight = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The nightly price for this type of room."),
                    Capacity = table.Column<int>(type: "int", nullable: false, comment: "The maximum capacity of this room type.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key and unique identifier for the staff member."),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The first name of the staff member."),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The last name of the staff member."),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The job position of the staff member."),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The salary of the staff member."),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The birth date of the staff member."),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true, comment: "The phone number of the staff member."),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "The email address of the staff member."),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The hire date of the staff member."),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier for the hotel where the staff member works.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key and unique identifier for the room."),
                    RoomNumber = table.Column<int>(type: "int", maxLength: 700, nullable: false, comment: "Unique number identifying the room within a hotel."),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "The status of the room - Available, Occupied, Cleaning"),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "The image URL for the room's picture."),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RoomTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier for the room's type")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key and unique identifier for the booking."),
                    CheckinDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The check-in date for the booking."),
                    CheckoutDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The check-out date for the booking."),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The total price for the booking."),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier for the hotel the room belongs to."),
                    GuestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier for the guest making the booking."),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the room associated with the booking."),
                    StaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "The identifier for the staff member managing the booking.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HotelsRooms",
                columns: table => new
                {
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier for the associated hotel."),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier for the associated room."),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelsRooms", x => new { x.HotelId, x.RoomId });
                    table.ForeignKey(
                        name: "FK_HotelsRooms_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HotelsRooms_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key and unique identifier for the payment."),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The amount of the payment."),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date the payment was made."),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The method of payment - Credit Card, Cash, Bank Wire Transfer."),
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier for the associated booking.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { new Guid("7d834c10-8d45-432a-8497-5fe67d6bc87e"), "321 Birch Ln, Seaview, Country", new DateTime(1995, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "michaelwilliams@example.com", "Michael", "Williams", "+2233445566" },
                    { new Guid("cc8884c8-5fef-422f-a040-bb241d56bae1"), "789 Pine St, Hilltown, Country", new DateTime(1982, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "alicejohnson@example.com", "Alice", "Johnson", "+1122334455" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CheckinTime", "CheckoutTime", "Email", "ImageURL", "Name", "Phone", "Stars" },
                values: new object[,]
                {
                    { new Guid("59e30f3b-29c6-4c66-92d2-55cfb73a8507"), "456 Beachside Blvd, Seaside Town, Country", new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), "info@oceanviewresort.com", "/images/hotel3.jpg", "Oceanview Resort", "+9876543210", 4 },
                    { new Guid("f08fee76-9236-4352-bad0-79114d2f4fa8"), "123 Main St, Cityville, Country", new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0), "contact@grandhotel.com", "/images/hotel1.jpg", "Grand Hotel", "+1234567890", 5 },
                    { new Guid("f5a9f365-2487-4da9-930f-5ed74548b19c"), "456 Ocean Ave, Seaside, Country", new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), "info@beachresort.com", null, "Beachside Resort", "+0987654321", 4 }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "Capacity", "Description", "Name", "PricePerNight" },
                values: new object[,]
                {
                    { new Guid("7595a22c-4f20-446e-9ff1-2dd858e0605e"), 2, "A double room for two guests.", "Double", 150.00m },
                    { new Guid("7dc23acb-fd86-4d55-a6e7-7c9038fc79a2"), 4, null, "Suite", 200.00m },
                    { new Guid("9374aedb-6b96-442e-9dc4-8151cf392ec4"), 1, "A single room for solo travelers.", "Single", 100.00m },
                    { new Guid("d2fd4ec4-8c74-41bc-bb23-a0fab80001e9"), 4, "A suite with multiple rooms and luxurious amenities.", "Suite", 200.00m }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "ImageURL", "RoomNumber", "RoomTypeId", "Status" },
                values: new object[,]
                {
                    { new Guid("2089920b-f804-4902-9378-7b5edbd8de2d"), null, 201, new Guid("7595a22c-4f20-446e-9ff1-2dd858e0605e"), "Cleaning" },
                    { new Guid("49f761a2-b413-4b54-96d0-b430e77f81a5"), "/images/room2.png", 102, new Guid("9374aedb-6b96-442e-9dc4-8151cf392ec4"), "Occupied" },
                    { new Guid("7de86043-69be-405f-848d-3ea837e045e5"), null, 301, new Guid("7595a22c-4f20-446e-9ff1-2dd858e0605e"), "Available" },
                    { new Guid("902e52bf-cc0d-44c8-9868-cd315d5b07c9"), null, 202, new Guid("7595a22c-4f20-446e-9ff1-2dd858e0605e"), "Available" },
                    { new Guid("c9a182e8-3a44-4801-9b00-b12e61483dbc"), "/images/room1.png", 101, new Guid("9374aedb-6b96-442e-9dc4-8151cf392ec4"), "Available" }
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "HireDate", "HotelId", "LastName", "Phone", "Position", "Salary" },
                values: new object[,]
                {
                    { new Guid("6d70ff14-bba9-4d51-ac4b-cb8bf9fa211c"), new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@grandhotel.com", "John", new DateTime(2015, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f08fee76-9236-4352-bad0-79114d2f4fa8"), "Doe", "+1234567890", "Manager", 5000.00m },
                    { new Guid("f8778587-24d8-413e-9aeb-03b12560d6f7"), new DateTime(1990, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@beachresort.com", "Jane", new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f5a9f365-2487-4da9-930f-5ed74548b19c"), "Smith", "+0987654321", "Receptionist", 2500.00m }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CheckinDate", "CheckoutDate", "GuestId", "HotelId", "RoomId", "StaffId", "TotalPrice" },
                values: new object[,]
                {
                    { new Guid("87d2cfb2-978a-443b-8ab3-3db1fe4eea95"), new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cc8884c8-5fef-422f-a040-bb241d56bae1"), new Guid("f08fee76-9236-4352-bad0-79114d2f4fa8"), new Guid("c9a182e8-3a44-4801-9b00-b12e61483dbc"), new Guid("6d70ff14-bba9-4d51-ac4b-cb8bf9fa211c"), 500.00m },
                    { new Guid("f44a91ac-41ca-48f3-a2f8-9363b3ddbb19"), new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7d834c10-8d45-432a-8497-5fe67d6bc87e"), new Guid("f5a9f365-2487-4da9-930f-5ed74548b19c"), new Guid("2089920b-f804-4902-9378-7b5edbd8de2d"), new Guid("f8778587-24d8-413e-9aeb-03b12560d6f7"), 300.00m }
                });

            migrationBuilder.InsertData(
                table: "HotelsRooms",
                columns: new[] { "HotelId", "RoomId" },
                values: new object[,]
                {
                    { new Guid("f08fee76-9236-4352-bad0-79114d2f4fa8"), new Guid("49f761a2-b413-4b54-96d0-b430e77f81a5") },
                    { new Guid("f08fee76-9236-4352-bad0-79114d2f4fa8"), new Guid("c9a182e8-3a44-4801-9b00-b12e61483dbc") },
                    { new Guid("f5a9f365-2487-4da9-930f-5ed74548b19c"), new Guid("2089920b-f804-4902-9378-7b5edbd8de2d") },
                    { new Guid("f5a9f365-2487-4da9-930f-5ed74548b19c"), new Guid("902e52bf-cc0d-44c8-9868-cd315d5b07c9") }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "BookingId", "PaymentDate", "PaymentMethod" },
                values: new object[,]
                {
                    { new Guid("740bb7e7-083f-4a08-8f6f-d645cfdb99b1"), 300.00m, new Guid("f44a91ac-41ca-48f3-a2f8-9363b3ddbb19"), new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash" },
                    { new Guid("8d87c9e4-4559-4e96-89a0-5052191d0014"), 500.00m, new Guid("87d2cfb2-978a-443b-8ab3-3db1fe4eea95"), new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Credit Card" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_GuestId",
                table: "Bookings",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_HotelId",
                table: "Bookings",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_StaffId",
                table: "Bookings",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelsRooms_RoomId",
                table: "HotelsRooms",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BookingId",
                table: "Payments",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_HotelId",
                table: "Staff",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelsRooms");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
