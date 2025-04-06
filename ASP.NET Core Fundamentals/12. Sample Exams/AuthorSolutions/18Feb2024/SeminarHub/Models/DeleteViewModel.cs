using System.ComponentModel.DataAnnotations;

namespace SeminarHub.Models
{
    public class DeleteViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Seminar Topic")]
        public string Topic { get; set; } = null!;

        [Display(Name = "Date and Time")]
        public DateTime DateAndTime { get; set; }

        [Display(Name = "Confirmation Message")]
        public string ConfirmationMessage { get; set; } = null!;
    }

}
