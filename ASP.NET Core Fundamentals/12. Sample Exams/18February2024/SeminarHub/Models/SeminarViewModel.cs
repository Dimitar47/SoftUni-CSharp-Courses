using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static SeminarHub.Constants.ModelConstants;
using System.Configuration;
namespace SeminarHub.Models
{
    public class SeminarViewModel
    {
        [Required]
        [StringLength(SeminarTopicMaxLength,MinimumLength = SeminarTopicMinLength)]
        public string Topic { get; set; } = null!;

        [Required]
        [StringLength(SeminarLecturerMaxLength,MinimumLength = SeminarLecturerMinLength)]
        public string Lecturer { get; set; } = null!;

        [Required]
        [StringLength(SeminarDetailsMaxLength, MinimumLength = SeminarDetailsMinLength)]
        public string Details { get; set; } = null!;

        [Required]
        [RegexStringValidator(@"^\d{2}/\d{2}/\d{4} \d{2}:\d{2}$")]
        public string DateAndTime { get; set; } = null!;

        [Required]
        [Range(SeminarDurationMinLength,SeminarDurationMaxLength)]
        public int Duration { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public List<Category> Categories { get; set; } = new List<Category>();

    }
    

}
