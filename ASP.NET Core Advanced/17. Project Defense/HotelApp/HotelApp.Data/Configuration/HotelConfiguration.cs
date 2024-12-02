using HotelApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static HotelApp.Common.EntityValidationConstants.Hotel;

namespace HotelApp.Data.Configuration
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
       
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {

            builder.Property(h => h.IsDeleted).HasDefaultValue(false);


            builder
                .HasMany(h => h.Staff)
                .WithOne(s => s.Hotel) 
                .HasForeignKey(s => s.HotelId)
                .OnDelete(DeleteBehavior.Restrict);  

           
          
            



        }

      
    }
}
