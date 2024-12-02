using HotelApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static HotelApp.Common.EntityValidationConstants.Room;

namespace HotelApp.Data.Configuration
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {



        public void Configure(EntityTypeBuilder<Room> builder)
        {

            builder.Property(r => r.IsDeleted).HasDefaultValue(false);




            builder
                .HasOne(r => r.RoomType)
                .WithMany(rt => rt.Rooms)
                .HasForeignKey(r => r.RoomTypeId)
                .OnDelete(DeleteBehavior.Restrict);

          


           
        }
        
     
           
    }
}
