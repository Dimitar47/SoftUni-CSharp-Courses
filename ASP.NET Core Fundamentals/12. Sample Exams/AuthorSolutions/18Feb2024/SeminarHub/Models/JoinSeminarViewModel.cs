using SeminarHub.Common;
using System.ComponentModel.DataAnnotations;

namespace SeminarHub.Models
{
    public class JoinSeminarViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ValidationConstants.SeminarTopicMaxLength, MinimumLength = ValidationConstants.SeminarTopicMinLength)]
        public string Topic { get; set; } = null!;

        [Required]
        [StringLength(ValidationConstants.SeminarLecturerMaxLength, MinimumLength = ValidationConstants.SeminarLecturerMinLength)]
        public string Lecturer { get; set; } = null!;

        [Required]
        [StringLength(ValidationConstants.SeminarDetailsMaxLength, MinimumLength = ValidationConstants.SeminarDetailsMinLength)]
        public string Details { get; set; } = null!;

        [Required]
        public string OrganizerId { get; set; } = null!;

        [Required]
        public DateTime DateAndTime { get; set; }

        [Range(ValidationConstants.SeminarDurationMin, ValidationConstants.SeminarDurationMax)]
        public int Duration { get; set; }

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }
    }
}
