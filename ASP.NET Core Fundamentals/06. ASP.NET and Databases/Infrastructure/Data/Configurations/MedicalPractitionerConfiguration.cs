using Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class MedicalPractitionerConfiguration : IEntityTypeConfiguration<MedicalPractitioner>
    {
        public void Configure(EntityTypeBuilder<MedicalPractitioner> builder)
        {
            builder.ToTable("Prescriptions");
        }
    }
}
