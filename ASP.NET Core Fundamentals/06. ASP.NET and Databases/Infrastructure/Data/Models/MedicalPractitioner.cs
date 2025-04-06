using Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.Models
{
    [EntityTypeConfiguration(typeof(MedicalPractitionerConfiguration))]
    public class MedicalPractitioner
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Comment("Medical practitioner name")]
        [Column("medical_practitioner_name")]
        public required string Name { get; set; }

        [Required]
        [StringLength(10)]
        [Comment("Medical practitioner UIN")]
        public required string Uin { get; set; }

        [Required]
        [StringLength(10)]
        [Comment("Medical practitioner telephone")]
        [Column("medical_practitioner_telephone")]
        public required string Phone { get; set; }
    }
}