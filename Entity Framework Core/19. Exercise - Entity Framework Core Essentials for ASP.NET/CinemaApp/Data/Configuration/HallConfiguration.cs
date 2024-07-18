using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configuration
{
    public class HallConfiguration : IEntityTypeConfiguration<Hall>
    {
        public void Configure(EntityTypeBuilder<Hall> builder)
        {
            builder
                .HasData(
                    new Hall()
                    {
                        Id = 1,
                        Name = "IMAX Hall 1",
                        CinemaId = 1
                    },
                    new Hall()
                    {
                        Id = 2,
                        Name = "IMAX Hall 1",
                        CinemaId = 1
                    },
                    new Hall()
                    {
                        Id = 3,
                        Name = "3D  Hall",
                        CinemaId = 1
                    },
                    new Hall()
                    {
                        Id = 4,
                        Name = "VIP Hall",
                        CinemaId = 2
                    },
                    new Hall()
                    {
                        Id = 5,
                        Name = "IMAX",
                        CinemaId = 2
                    },
                    new Hall()
                    {
                        Id = 6,
                        Name = "3D Ultra Vip IMAX",
                        CinemaId = 3
                    });
        }
    }
}
