using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademicRecordsApp.Data.Models
{
    public partial class Exam
    {
        public Exam()
        {
            Grades = new HashSet<Grade>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        // Foreign key property
         [ForeignKey("Course")]
        public int? CourseId { get; set; }

        // Navigation property
        public virtual Course Course { get; set; } = null!;

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
