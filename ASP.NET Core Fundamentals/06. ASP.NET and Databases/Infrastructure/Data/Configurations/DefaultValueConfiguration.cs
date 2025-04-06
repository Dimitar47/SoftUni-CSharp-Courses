using Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class DefaultValueConfiguration : IEntityTypeConfiguration<DefaultValue>
    {
        public void Configure(EntityTypeBuilder<DefaultValue> builder)
        {
            builder.Property(dv => dv.CreditsWithSentinel)
                .HasDefaultValue(10)
                .HasSentinel(-1);

            builder.Property(dv => dv.CreditsWithoutSentinel)
                .HasDefaultValue(10);

            builder.Property(dv => dv.IsActiveDefaultTrue)
                .HasDefaultValue(true);

            builder.Property(dv => dv.IsActiveDefaultFalse)
                .HasDefaultValue(false);
        }
    }
}
