using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static HotelApp.Common.EntityValidationConstants.Guest;


namespace HotelApp.Data.Models
{
    public class Guest
    {
        public Guest()
        {
            this.Id = Guid.NewGuid();
            this.Bookings = new HashSet<Booking>();
        }

        [Key]
        [Comment("Primary key and unique identifier for the guest.")]
        public Guid Id { get; set; } 

        [Required]
        [MaxLength(GuestFirstNameMaxLength)]
        [Comment("The first name of the guest.")]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(GuestLastNameMaxLength)]
        [Comment("The last name of the guest.")]
        public string LastName { get; set; } = null!;

        [Required]
        [Comment("The date of birth of the guest.")]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(GuestAddressMaxLength)]
        [Comment("The address of the guest.")]
        public string? Address { get; set; }

        [MaxLength(GuestPhoneMaxLength)]
        [Comment("The phone number of the guest.")]
        public string? Phone { get; set; }

        [Required]
        [MaxLength(GuestEmailMaxLength)]
        [Comment("The email address of the guest.")]
        public string Email { get; set; } = null!;


        //Navigation Properties

        [Comment("Collection of bookings associated with the guest.")]
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
