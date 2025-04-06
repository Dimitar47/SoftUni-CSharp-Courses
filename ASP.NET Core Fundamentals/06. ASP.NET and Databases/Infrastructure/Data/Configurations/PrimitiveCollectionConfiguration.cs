using Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.ObjectModel;

namespace Infrastructure.Data.Configurations
{
    public class PrimitiveCollectionConfiguration : IEntityTypeConfiguration<PrimitiveCollection>
    {
        public void Configure(EntityTypeBuilder<PrimitiveCollection> builder)
        {
            PrimitiveCollection[] primitiveCollections = 
            [ 
                new PrimitiveCollection
                {
                    Id = 1,
                    Ints = new int[] { 1, 2, 3 },
                    Strings = new string[] { "one", "two", "three" },
                    DateTimes = new DateTime[]
                    {
                        new DateTime(2021, 1, 1, 1, 1, 1, DateTimeKind.Utc),
                        new DateTime(2021, 2, 1, 2, 2, 2, DateTimeKind.Utc),
                        new DateTime(2021, 3, 1, 3, 3, 3, DateTimeKind.Utc)
                    },
                    Dates = new List<DateOnly>
                    {
                        new DateOnly(2021, 1, 1),
                        new DateOnly(2021, 2, 1),
                        new DateOnly(2021, 3, 1)
                    }
                },
                new PrimitiveCollection
                {
                    Id = 2,
                    Ints = new int[] { 4, 5, 6 },
                    Strings = new string[] { "four", "five", "six" },
                    DateTimes = new DateTime[]
                    {
                        new DateTime(2021, 4, 1, 4, 4, 4, DateTimeKind.Utc),
                        new DateTime(2021, 5, 1, 5, 5, 5, DateTimeKind.Utc),
                        new DateTime(2021, 6, 1, 6, 6, 6, DateTimeKind.Utc)
                    },
                    Dates = new List<DateOnly>
                    {
                        new DateOnly(2021, 4, 1),
                        new DateOnly(2021, 5, 1),
                        new DateOnly(2021, 6, 1)
                    }
                },
                new PrimitiveCollection
                {
                    Id = 3,
                    Ints = new int[] { 7, 8, 9 },
                    Strings = new string[] { "seven", "eight", "nine" },
                    DateTimes = new DateTime[]
                    {
                        new DateTime(2021, 7, 1, 7, 7, 7, DateTimeKind.Utc),
                        new DateTime(2021, 8, 1, 8, 8, 8, DateTimeKind.Utc),
                        new DateTime(2021, 9, 1, 9, 9, 9, DateTimeKind.Utc)
                    },
                    Dates = new List<DateOnly>
                    {
                        new DateOnly(2021, 7, 1),
                        new DateOnly(2021, 8, 1),
                        new DateOnly(2021, 9, 1)
                    }
                }
            ];

            builder.HasData(primitiveCollections);
        }
    }
}
