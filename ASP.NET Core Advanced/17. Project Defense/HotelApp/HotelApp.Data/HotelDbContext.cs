using HotelApp.Data.Configuration;
using HotelApp.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;



namespace HotelApp.Data
{
    public class HotelDbContext : IdentityDbContext
    {
        
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Guest> Guests { get; set; } = null!;
        public virtual DbSet<Hotel> Hotels { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<HotelRoom> HotelsRooms { get; set; } = null!;
        public virtual DbSet<RoomType> RoomTypes { get; set; } = null!;
        public virtual DbSet<Staff> Staff { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply configurations
            modelBuilder.ApplyConfiguration(new HotelConfiguration());
            modelBuilder.ApplyConfiguration(new RoomTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new HotelRoomConfiguration());
            modelBuilder.ApplyConfiguration(new GuestConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new StaffConfiguration());


            // Seed the database
            Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }


        public static void Seed(ModelBuilder modelBuilder)
        {
            // Seeding Room Types
            var singleRoomType = new RoomType 
            {  
                Name = "Single",
                Description = "A single room for solo travelers.",
                PricePerNight = 100.00m,
                Capacity = 1 
            };
            var doubleRoomType = new RoomType 
            {
                Name = "Double",
                Description = "A double room for two guests.",
                PricePerNight = 150.00m,
                Capacity = 2 
            };

            var suiteRoomType = new RoomType
            {
                Name = "Suite",
                Description = "A suite with multiple rooms and luxurious amenities.",
                PricePerNight = 200.00m,
                Capacity = 4
            };

            var nullDescriptionRoomType = new RoomType
            {
                Name = "Suite",
                Description = null,
                PricePerNight = 200.00m,
                Capacity = 4
            };

            modelBuilder.Entity<RoomType>().HasData(singleRoomType, doubleRoomType, suiteRoomType, nullDescriptionRoomType);


            // Seeding Hotels
            var hotel1 = new Hotel
            {
                Name = "Grand Hotel",
                Address = "123 Main St, Cityville, Country",
                Phone = "+1234567890",
                Email = "contact@grandhotel.com",
                Stars = 5,
                CheckinTime = new TimeSpan(14, 0, 0),  // 2:00 PM
                CheckoutTime = new TimeSpan(11, 0, 0),  // 11:00 AM
                ImageURL = "/images/hotel1.jpg"
            };

            var hotel2 = new Hotel
            {
                Name = "Beachside Resort",
                Address = "456 Ocean Ave, Seaside, Country",
                Phone = "+0987654321",
                Email = "info@beachresort.com",
                Stars = 4,
                CheckinTime = new TimeSpan(15, 0, 0),  // 3:00 PM
                CheckoutTime = new TimeSpan(10, 0, 0),  // 10:00 AM
            };

            var hotel3 = new Hotel
            {
                Name = "Oceanview Resort",
                Address = "456 Beachside Blvd, Seaside Town, Country",
                Phone = "+9876543210",
                Email = "info@oceanviewresort.com",
                Stars = 4,
                CheckinTime = new TimeSpan(15, 0, 0),  // 3:00 PM
                CheckoutTime = new TimeSpan(12, 0, 0),  // 12:00 PM
                ImageURL = "/images/hotel3.jpg"
            };


            modelBuilder.Entity<Hotel>().HasData(hotel1, hotel2, hotel3);


            // Seeding Rooms
            var room1 = new Room
            {
               
                RoomNumber = 101,
                Status = "Available",
                ImageURL = "/images/room1.png",
                RoomTypeId = singleRoomType.Id
            };

            var room2 = new Room
            {
                
                RoomNumber = 102,
                Status = "Available",
                ImageURL = "/images/room2.png",
                RoomTypeId = singleRoomType.Id
            };

            var room3 = new Room
            {
           
                RoomNumber = 201,
                Status = "Available",
                RoomTypeId = doubleRoomType.Id
            };

            var room4 = new Room
            {
              
                RoomNumber = 202,
                Status = "Available",
                RoomTypeId = doubleRoomType.Id
            };

            var unassociatedRoom = new Room
            {
                RoomNumber = 301,
                Status = "Available",
                RoomTypeId = doubleRoomType.Id
            };

            modelBuilder.Entity<Room>().HasData(room1, room2, room3, room4, unassociatedRoom);

            //Seeding HotelsRooms
            modelBuilder.Entity<HotelRoom>().HasData(
            new HotelRoom 
            {
                HotelId = hotel1.Id, 
                RoomId = room1.Id
            },
            new HotelRoom
            { 
                HotelId = hotel1.Id,
                RoomId = room2.Id
            },
            new HotelRoom 
            {
                HotelId = hotel2.Id,
                RoomId = room3.Id 
            },
            new HotelRoom 
            {
                HotelId = hotel2.Id,
                RoomId = room4.Id
            });


            // Seeding Staff
            var staff1 = new Staff
            {
               
                FirstName = "John",
                LastName = "Doe",
                Position = "Manager",
                Salary = 5000.00m,
                DateOfBirth = new DateTime(1985, 5, 15),
                Phone = "+1234567890",
                Email = "john.doe@grandhotel.com",
                HireDate = new DateTime(2015, 3, 1),
                HotelId = hotel1.Id 
            };

            var staff2 = new Staff
            {
              
                FirstName = "Jane",
                LastName = "Smith",
                Position = "Receptionist",
                Salary = 2500.00m,
                DateOfBirth = new DateTime(1990, 7, 22),
                Phone = "+0987654321",
                Email = "jane.smith@beachresort.com",
                HireDate = new DateTime(2018, 6, 15),
                HotelId = hotel2.Id 
            };


            modelBuilder.Entity<Staff>().HasData(staff1, staff2);

            // Seeding Guests
            var guest1 = new Guest
            {
                FirstName = "Alice",
                LastName = "Johnson",
                DateOfBirth = new DateTime(1982, 11, 20),
                Address = "789 Pine St, Hilltown, Country",
                Phone = "+1122334455",
                Email = "alicejohnson@example.com"
            };

            var guest2 = new Guest
            {
                FirstName = "Michael",
                LastName = "Williams",
                DateOfBirth = new DateTime(1995, 3, 10),
                Address = "321 Birch Ln, Seaview, Country",
                Phone = "+2233445566",
                Email = "michaelwilliams@example.com"
            };

            modelBuilder.Entity<Guest>().HasData(guest1, guest2);


            // Seeding Bookings
            var booking1 = new Booking
            {
                CheckinDate = new DateTime(2024, 12, 1),  
                CheckoutDate = new DateTime(2024, 12, 5),
                TotalPrice = 500.00m, 
                HotelId = hotel1.Id,  
                GuestId = guest1.Id,  
                RoomId = room1.Id,    
                StaffId = staff1.Id   
            };

            var booking2 = new Booking
            {
                CheckinDate = new DateTime(2024, 12, 10), 
                CheckoutDate = new DateTime(2024, 12, 12), 
                TotalPrice = 300.00m, 
                HotelId = hotel2.Id,  
                GuestId = guest2.Id,  
                RoomId = room3.Id,    
                StaffId = staff2.Id   
            };


            modelBuilder.Entity<Booking>().HasData(booking1, booking2);


            // Seeding Payments
            var payment1 = new Payment
            {
                Amount = 500.00m, 
                PaymentDate = new DateTime(2024, 12, 1),  
                PaymentMethod = "Credit Card",  
                BookingId = booking1.Id  
            };

            var payment2 = new Payment
            {
                Amount = 300.00m, 
                PaymentDate = new DateTime(2024, 12, 10), 
                PaymentMethod = "Cash",  
                BookingId = booking2.Id  
            };

            
            modelBuilder.Entity<Payment>().HasData(payment1, payment2);
        }

    }
}
