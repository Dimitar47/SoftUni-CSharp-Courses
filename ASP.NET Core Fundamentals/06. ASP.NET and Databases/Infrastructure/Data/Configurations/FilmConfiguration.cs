using Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            List<Film> films = new List<Film>();

            for (int i = 1; i <= 100; i++)
            {
                films.Add(new Film
                {
                    Id = i,
                    Title = $"Film {i}",
                    Duration = 120,
                    Year = 1920 + i,
                    IsActive = true
                });
            }

            builder.HasData(films);
        }
    }
}
