using Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Models
{
    [Comment("Prescriptions table")]
    [EntityTypeConfiguration(typeof(PrescriptionConfiguration))]
    public class Prescription
    {
        [Key]
        [Comment("Prescription ID")]
        public int Id { get; set; }

        [Required]
        [StringLength(12)]
        [Comment("National referent number")]
        public required string Nrn { get; set; }

        [Required]
        [StringLength(100)]
        [Comment("Prescribed medication")]
        public required string Medication { get; set; }

        [Required]
        [Comment("Patient")]
        public required Patient Patient { get; set; }

        [Required]
        [Comment("Patient age")]
        public int PatientAge { get; set; }

        [Required]
        [Comment("Medical practitioner")]
        public required MedicalPractitioner MedicalPractitioner { get; set; }
    }
}
