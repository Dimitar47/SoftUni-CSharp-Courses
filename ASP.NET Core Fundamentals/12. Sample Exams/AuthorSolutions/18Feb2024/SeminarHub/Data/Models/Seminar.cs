using Microsoft.AspNetCore.Identity;
using SeminarHub.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeminarHub.Data.Models
{
    public class Seminar
    {
        public Seminar()
        {
            SeminarsParticipants = new HashSet<SeminarParticipant>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.SeminarTopicMaxLength)]
        public string Topic { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConstants.SeminarLecturerMaxLength)]
        public string Lecturer { get; set; }

        [Required]
        [MaxLength(ValidationConstants.SeminarDetailsMaxLength)]
        public string Details { get; set; } = null!;

        [Required]
        public string OrganizerId { get; set; } = null!;

        [ForeignKey(nameof(OrganizerId))]
        public IdentityUser Organizer { get; set; } = null!;
        public DateTime DateAndTime { get; set; }
        public int Duration { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; } = null!;

        public virtual ICollection<SeminarParticipant> SeminarsParticipants { get; set; }
    }
}
