using Infrastructure.Data.Configurations;
using Infrastructure.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.Models
{
    [EntityTypeConfiguration(typeof(PatientConfiguration))]
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Comment("Patient age")]
        public int Age { get; set; }

        [Required]
        [Comment("Patient gender")]
        [Column("patient_gender")]
        public Gender Gender { get; set; }

        [Required]
        [StringLength(10)]
        [Comment("Patient EKATTE")]
        [Column("patient_ekatte")]
        public required string Ekatte { get; set; }

        [Required]
        [Comment("Patient identifier")]
        public Guid Mpi { get; set; }
    }
}