using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configuration
{
    internal class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasData(
                new Schedule
                {
                    Id = 1,
                    MovieId = 1,
                    HallId = 1,
                    Start = new DateTime(2024, 07, 23, 20, 00, 00),
                    Duration = TimeSpan.FromMinutes(98),
                },
           new Schedule()
           {
               Id = 2,
               MovieId = 2,
               HallId = 4,
               Start = new DateTime(2024, 07, 23, 20, 00, 00),
               Duration = TimeSpan.FromMinutes(98),
           },
           new Schedule()
           {
               Id = 3,
               MovieId = 3,
               HallId = 2,
               Start = new DateTime(2024, 07, 23, 20, 00, 00),
               Duration = TimeSpan.FromMinutes(98),
           });
        }
    }
}
