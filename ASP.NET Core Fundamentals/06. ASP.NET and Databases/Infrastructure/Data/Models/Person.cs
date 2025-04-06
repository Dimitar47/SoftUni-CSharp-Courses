using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Models
{
    [Comment("A person.")]
    public class Person
    {
        [Key]
        [Comment("The unique identifier for the person.")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Comment("The name of the person.")]
        public required string Name { get; set; }

        [Required]
        [Comment("Current address of the person.")]
        public required Address CurrentAddress { get; set; }

        [Required]
        [Comment("Permanent address of the person.")]
        public required Address PermanentAddress { get; set; }
    }
}
