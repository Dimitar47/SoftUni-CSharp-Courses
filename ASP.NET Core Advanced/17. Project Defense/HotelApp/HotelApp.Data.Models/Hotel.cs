using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static HotelApp.Common.EntityValidationConstants.Hotel;


namespace HotelApp.Data.Models
{
    public class Hotel
    {
        public Hotel()
        {
            this.Id = Guid.NewGuid();
            this.HotelRooms = new HashSet<HotelRoom>();
            this.Staff = new HashSet<Staff>();
            this.Bookings = new HashSet<Booking>();
        }
        
        [Key]
        [Comment("Primary key and unique identifier for the hotel.")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(HotelNameMaxLength)]
        [Comment("The name of the hotel.")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(HotelAddressMaxLength)]
        [Comment("The address of the hotel.")]
        public string Address { get; set; } = null!;
    
        [Comment("The image URL for the hotel's picture.")]
        public string? ImageURL { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        [MaxLength(HotelPhoneMaxLength)]
        [Comment("The contact phone number of the hotel.")]
        public string Phone { get; set; } = null!;

        [Required]
        [MaxLength(HotelEmailMaxLength)]
        [Comment("The contact email address of the hotel.")]
        public string Email { get; set; } = null!;

        [Required]
        [Comment("The star rating of the hotel, ranging from 1 to 5.")]
        public int Stars { get; set; }

        [Required]
        [Comment("The standard check-in time for the hotel.")]
        public TimeSpan CheckinTime { get; set; } 

        [Required]
        [Comment("The standard checkout time for the hotel.")]
        public TimeSpan CheckoutTime { get; set; }

        //Navigation Properties

        [Comment("Collection of rooms in the hotel.")]
        public virtual ICollection<HotelRoom> HotelRooms { get; set; }

        [Comment("Collection of staff members working in the hotel.")]
        public virtual ICollection<Staff> Staff { get; set; }

        [Comment("Collection of bookings made in the hotel.")]
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
