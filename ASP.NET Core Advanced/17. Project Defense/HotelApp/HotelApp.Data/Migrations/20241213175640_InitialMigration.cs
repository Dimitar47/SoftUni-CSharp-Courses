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
                    { new Guid("4ca39a7b-8351-4348-8ece-f836ebcf0fcc"), "321 Birch Ln, Seaview, Country", new DateTime(1995, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "michaelwilliams@example.com", "Michael", "Williams", "+2233445566" },
                    { new Guid("fae9ecb7-b323-476b-9e97-0a6caca0cf9c"), "789 Pine St, Hilltown, Country", new DateTime(1982, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "alicejohnson@example.com", "Alice", "Johnson", "+1122334455" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CheckinTime", "CheckoutTime", "Email", "ImageURL", "Name", "Phone", "Stars" },
                values: new object[,]
                {
                    { new Guid("89f99082-15da-4328-98c6-9f6d90c08506"), "456 Beachside Blvd, Seaside Town, Country", new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), "info@oceanviewresort.com", "/images/hotel3.jpg", "Oceanview Resort", "+9876543210", 4 },
                    { new Guid("b2752b87-da7b-4b9c-b4de-ac83558526a6"), "123 Main St, Cityville, Country", new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0), "contact@grandhotel.com", "/images/hotel1.jpg", "Grand Hotel", "+1234567890", 5 },
                    { new Guid("f2076ab0-6c3f-4107-a486-69493c927ad7"), "456 Ocean Ave, Seaside, Country", new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), "info@beachresort.com", null, "Beachside Resort", "+0987654321", 4 }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "Capacity", "Description", "Name", "PricePerNight" },
                values: new object[,]
                {
                    { new Guid("32ae3e42-270e-4c36-95ac-9efe748bd614"), 1, "A single room for solo travelers.", "Single", 100.00m },
                    { new Guid("37f1d7e0-ceb4-4704-8c53-ece9ec44b122"), 4, "A suite with multiple rooms and luxurious amenities.", "Suite", 200.00m },
                    { new Guid("98e23296-f423-42e3-9606-d8286e79bc54"), 2, "A double room for two guests.", "Double", 150.00m },
                    { new Guid("aec34658-7edc-4935-aa06-34869660e905"), 4, null, "Suite", 200.00m }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "ImageURL", "RoomNumber", "RoomTypeId", "Status" },
                values: new object[,]
                {
                    { new Guid("4c0ae8b9-1bd0-4571-8341-a2efc4c8c586"), "/images/room2.png", 102, new Guid("32ae3e42-270e-4c36-95ac-9efe748bd614"), "Available" },
                    { new Guid("8272e2c2-3f52-47b9-bb8d-0d328a338ef9"), null, 201, new Guid("98e23296-f423-42e3-9606-d8286e79bc54"), "Available" },
                    { new Guid("9fd1e1ee-6fae-4d51-a637-fcf24e1ede82"), null, 301, new Guid("98e23296-f423-42e3-9606-d8286e79bc54"), "Available" },
                    { new Guid("a323b2bd-a53e-4e90-b686-1d3f09953ba7"), "/images/room1.png", 101, new Guid("32ae3e42-270e-4c36-95ac-9efe748bd614"), "Available" },
                    { new Guid("a65a0b07-2385-4f19-9737-716677ead8d2"), null, 202, new Guid("98e23296-f423-42e3-9606-d8286e79bc54"), "Available" }
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "HireDate", "HotelId", "LastName", "Phone", "Position", "Salary" },
                values: new object[,]
                {
                    { new Guid("4c9e04b1-6996-4190-8e8f-fd198515f19f"), new DateTime(1990, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@beachresort.com", "Jane", new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f2076ab0-6c3f-4107-a486-69493c927ad7"), "Smith", "+0987654321", "Receptionist", 2500.00m },
                    { new Guid("7069055e-ea25-4cda-84a4-b4ac6e992ac0"), new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@grandhotel.com", "John", new DateTime(2015, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b2752b87-da7b-4b9c-b4de-ac83558526a6"), "Doe", "+1234567890", "Manager", 5000.00m }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CheckinDate", "CheckoutDate", "GuestId", "HotelId", "RoomId", "StaffId", "TotalPrice" },
                values: new object[,]
                {
                    { new Guid("6c559e1e-cf69-465d-98b4-46e2b1c26da0"), new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fae9ecb7-b323-476b-9e97-0a6caca0cf9c"), new Guid("b2752b87-da7b-4b9c-b4de-ac83558526a6"), new Guid("a323b2bd-a53e-4e90-b686-1d3f09953ba7"), new Guid("7069055e-ea25-4cda-84a4-b4ac6e992ac0"), 500.00m },
                    { new Guid("f677d23e-2817-4172-bfa4-f65168d6223a"), new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4ca39a7b-8351-4348-8ece-f836ebcf0fcc"), new Guid("f2076ab0-6c3f-4107-a486-69493c927ad7"), new Guid("8272e2c2-3f52-47b9-bb8d-0d328a338ef9"), new Guid("4c9e04b1-6996-4190-8e8f-fd198515f19f"), 300.00m }
                });

            migrationBuilder.InsertData(
                table: "HotelsRooms",
                columns: new[] { "HotelId", "RoomId" },
                values: new object[,]
                {
                    { new Guid("b2752b87-da7b-4b9c-b4de-ac83558526a6"), new Guid("4c0ae8b9-1bd0-4571-8341-a2efc4c8c586") },
                    { new Guid("b2752b87-da7b-4b9c-b4de-ac83558526a6"), new Guid("a323b2bd-a53e-4e90-b686-1d3f09953ba7") },
                    { new Guid("f2076ab0-6c3f-4107-a486-69493c927ad7"), new Guid("8272e2c2-3f52-47b9-bb8d-0d328a338ef9") },
                    { new Guid("f2076ab0-6c3f-4107-a486-69493c927ad7"), new Guid("a65a0b07-2385-4f19-9737-716677ead8d2") }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "BookingId", "PaymentDate", "PaymentMethod" },
                values: new object[,]
                {
                    { new Guid("57008aa4-dd0f-4a11-9c73-4473799b0bee"), 300.00m, new Guid("f677d23e-2817-4172-bfa4-f65168d6223a"), new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash" },
                    { new Guid("74c8165a-ad92-4523-b081-3746d1ce23dc"), 500.00m, new Guid("6c559e1e-cf69-465d-98b4-46e2b1c26da0"), new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Credit Card" }
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
