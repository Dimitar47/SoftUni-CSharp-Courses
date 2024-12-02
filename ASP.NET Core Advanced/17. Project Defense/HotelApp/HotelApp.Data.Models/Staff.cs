using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HotelApp.Common.EntityValidationConstants.Staff;

namespace HotelApp.Data.Models
{
    public class Staff
    {
        public Staff()
        {
            this.Id = Guid.NewGuid();
            this.ManagedBookings = new HashSet<Booking>();
        }

        [Key]
        [Comment("Primary key and unique identifier for the staff member.")]
        public Guid Id { get; set; } 

        [Required]
        [MaxLength(StaffFirstNameMaxLength)]
        [Comment("The first name of the staff member.")]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(StaffLastNameMaxLength)]
        [Comment("The last name of the staff member.")]
        public string LastName { get; set; } = null!;

        [Required]
        [MaxLength(StaffPositionMaxLength)]
        [Comment("The job position of the staff member.")]
        public string Position { get; set; } = null!;

        [Required]
        [Column(TypeName ="decimal(18,2)")]
        [Comment("The salary of the staff member.")]
        public decimal Salary { get; set; }

        [Required]
        [Comment("The birth date of the staff member.")]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(StaffPhoneMaxLength)]
        [Comment("The phone number of the staff member.")]
        public string? Phone { get; set; }


        [MaxLength(StaffEmailMaxLength)]
        [Comment("The email address of the staff member.")]
        public string? Email { get; set; }

        [Required]
        [Comment("The hire date of the staff member.")]
        public DateTime HireDate { get; set; }

        //Navigation Properties 

        [Required]
        [Comment("The identifier for the hotel where the staff member works.")]
        public Guid HotelId { get; set; }

        [ForeignKey(nameof(HotelId))]
        public virtual Hotel Hotel { get; set; } = null!;

        public virtual ICollection<Booking> ManagedBookings { get; set; }
    }
}
