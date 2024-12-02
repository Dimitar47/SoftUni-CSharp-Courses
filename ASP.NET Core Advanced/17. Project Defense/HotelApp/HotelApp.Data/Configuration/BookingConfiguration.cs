using HotelApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static HotelApp.Common.EntityValidationConstants.Booking;
namespace HotelApp.Data.Configuration
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            

            builder
              .HasOne(b => b.Hotel)
              .WithMany(h => h.Bookings) // Hotel has many Bookings
              .HasForeignKey(b => b.HotelId)
              .OnDelete(DeleteBehavior.Restrict) // Prevent deleting a hotel with existing bookings
              .IsRequired(); 

            builder
                .HasOne(b => b.Guest)
                .WithMany(g=> g.Bookings) // A guest can have many bookings (not navigating back)
                .HasForeignKey(b => b.GuestId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting a guest with existing bookings


            builder
                .HasOne(b => b.Room)
                .WithMany(r=>r.Bookings) // A room can be booked by many bookings (not navigating back)
                .HasForeignKey(b => b.RoomId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();  


            builder
                .HasMany(b => b.Payments)
                .WithOne(p=> p.Booking) // Payments are associated with bookings but do not need to navigate back to bookings
                .HasForeignKey(p => p.BookingId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting a booking with existing payments

            builder
                .HasOne(b => b.Staff)
                .WithMany(s => s.ManagedBookings)
                .HasForeignKey(b => b.StaffId)
                .OnDelete(DeleteBehavior.Restrict);

           
        }

        

    }
}
