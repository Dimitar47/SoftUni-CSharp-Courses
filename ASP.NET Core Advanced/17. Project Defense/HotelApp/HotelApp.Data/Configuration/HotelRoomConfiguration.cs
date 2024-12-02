using HotelApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Data.Configuration
{
    public class HotelRoomConfiguration : IEntityTypeConfiguration<HotelRoom>
    {
        public void Configure(EntityTypeBuilder<HotelRoom> builder)
        {
            builder.HasKey(hr => new { hr.HotelId, hr.RoomId });

            builder.Property(hr => hr.IsDeleted).HasDefaultValue(false);


            builder
                .HasOne(hr => hr.Hotel)
                .WithMany(h => h.HotelRooms)
                .HasForeignKey(hr => hr.HotelId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
               .HasOne(hr => hr.Room)
               .WithMany(r => r.RoomHotels)
               .HasForeignKey(hr => hr.RoomId)
               .OnDelete(DeleteBehavior.Restrict);



        }
    }
}
