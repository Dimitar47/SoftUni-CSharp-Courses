using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = 1,
                    Username = "pesho123",
                    FirstName = "Pesho",
                    LastName = "Petrov"
                },
                new User
                {
                    Id = 2,
                    Username = "pesho987",
                    FirstName = "Pesho",
                    LastName = "Ivan"
                },
                new User
                {
                    Id = 3,
                    Username = "vankata89",
                    FirstName = "Ivan",
                    LastName = "Ivanov"
                },
                new User
                {
                    Id = 4,
                    Username = "maria12312",
                    FirstName = "Maria  ",
                    LastName = "Petrova"
                });
        }
    }
}
