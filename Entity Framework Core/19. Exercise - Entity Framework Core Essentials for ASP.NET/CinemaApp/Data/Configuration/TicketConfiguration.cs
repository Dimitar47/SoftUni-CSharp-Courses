using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configuration
{
    internal class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasData(new Ticket
            {
                Id = 1,
                UserId = 1,
                BasePrice = 20,
                SeatId = 1,
                ScheduleId = 1,
                TariffId = 1
            },
            new Ticket()
            {
                Id = 2,
                UserId = 1,
                BasePrice = 20,
                SeatId = 2,
                ScheduleId = 3,
                TariffId = 3
            },
            new Ticket()
            {
                Id = 3,
                UserId = 1,
                BasePrice = 20,
                SeatId = 3,
                ScheduleId = 2,
                TariffId = 2
            });
        }
    }
}
