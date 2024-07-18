using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configuration
{
    internal class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasData(
                new Movie()
                {
                    Id = 1,
                    Title = "Snatch",
                },
                new Movie()
                {
                    Id = 2,
                    Title = "Lock, Stock And Two Smoking Barrels",
                },
                new Movie()
                {
                    Id = 3,
                    Title = "Rock n Rolla",
                });
        }
    }
}
