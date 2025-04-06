using SeminarHub.Common;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace SeminarHub.Models
{
    public class AddSeminarViewModel
    {
        [Required]
        [StringLength(ValidationConstants.SeminarTopicMaxLength, MinimumLength = ValidationConstants.SeminarTopicMinLength)]
        public string Topic { get; set; } = null!;

        [Required]
        [StringLength(ValidationConstants.SeminarDetailsMaxLength, MinimumLength = ValidationConstants.SeminarDetailsMinLength)]
        public string Details { get; set; } = null!;

        [Required]
        [StringLength(ValidationConstants.SeminarLecturerMaxLength, MinimumLength = ValidationConstants.SeminarLecturerMinLength)]
        public string Lecturer { get; set; } = null!;

        public string? OrganizerId { get; set; }

        [Required]
 
        [RegexStringValidator(@"^\d{2}/\d{2}/\d{4} \d{2}:\d{2}$")]
        public string DateAndTime { get; set; } = null!;

        [Required(ErrorMessage ="Duration is Required")]
        [Range(ValidationConstants.SeminarDurationMin, ValidationConstants.SeminarDurationMax)]
        public int? Duration { get; set; }

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        public virtual IEnumerable<CategoryViewModel>? Categories { get; set; }
    }
}
