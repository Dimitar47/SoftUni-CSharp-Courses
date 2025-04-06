using Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.Models
{
    [Comment("An employee.")]
    [EntityTypeConfiguration(typeof(EmployeeConfiguration))]
    public class Employee
    {
        [Key]
        [Comment("The unique identifier for the employee.")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Comment("The name of the employee.")]
        public required string Name { get; set; }

        [Required]
        [Comment("Current email address of the employee.")]
        public required string Email { get; set; }

        [Required]
        [Comment("Current address of the employee.")]
        public required Workplace Workplace { get; set; }
    }
}
