using Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.ToTable("Prescriptions")
                .Property(pr => pr.PatientAge)
                .HasColumnName("patient_age");
            builder.HasOne(pr => pr.Patient)
                .WithOne()
                .HasForeignKey<Patient>(p => p.Id);
            builder.Navigation(pr => pr.Patient)
                .IsRequired();
            builder.HasOne(pr => pr.MedicalPractitioner)
                .WithOne()
                .HasForeignKey<MedicalPractitioner>(m => m.Id);
            builder.Navigation(pr => pr.MedicalPractitioner)
                .IsRequired();
        }
    }
}
