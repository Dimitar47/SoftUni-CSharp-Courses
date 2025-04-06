using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SeminarHub.Constants.ModelConstants;
namespace SeminarHub.Data
{
    public class Seminar
    {

        [Key]
        [Comment("Unique identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("The topic for the seminar")]
        [MaxLength(SeminarTopicMaxLength)]
        public string Topic { get; set; } = null!;

        [Required]
        [Comment("The lecturer for the seminar")]
        [MaxLength(SeminarLecturerMaxLength)]
        public string Lecturer { get; set; } = null!;

        [Required]
        [Comment("The details for the seminar")]
        [MaxLength(SeminarDetailsMaxLength)]
        public string Details { get; set; } = null!;


        [Required]
        [Comment("The identifier of the topic organizer")]
        public string OrganizerId { get; set; } = null!;

        [ForeignKey(nameof(OrganizerId))]
        public IdentityUser Organizer { get; set; } = null!;

        [Required]
        [Comment("Date and time for the seminar")]
        public DateTime DateAndTime { get; set; }

        [Required]
        [Comment("The duration for the seminar")]
        public int Duration { get; set; }

        [Required]
        [Comment("The identifier for the category")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        public ICollection<SeminarParticipant> SeminarsParticipants { get; set; } = new List<SeminarParticipant>();
    }

    /*
     Seminar
•	Has Id – a unique integer, Primary Key
•	Has Topic – string with min length 3 and max length 100 (required)
•	Has Lecturer – string with min length 5 and max length 60 (required)
•	Has Details – string with min length 10 and max length 500 (required)
•	Has OrganizerId – string (required)
•	Has Organizer – IdentityUser (required)
•	Has DateAndTime – DateTime with format "dd/MM/yyyy HH:mm" (required) (the DateTime format is recommended, 
    if you are having troubles with this one, you are free to use another one)
•	Has Duration – integer value between 30 and 180
•	Has CategoryId – integer, foreign key (required)
•	Has Category – Category (required)
•	Has SeminarsParticipants – a collection of type SeminarParticipant
    */

}
