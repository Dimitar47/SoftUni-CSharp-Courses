using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApp.Data.Models
{
    public class Booking
    {
        public Booking()
        {
            this.Id = Guid.NewGuid();
            this.Payments = new HashSet<Payment>();
        }

        [Key]
        [Comment("Primary key and unique identifier for the booking.")]
        public Guid Id { get; set; }

        [Required]
        [Comment("The check-in date for the booking.")]
        public DateTime CheckinDate { get; set; }

        [Required]
        [Comment("The check-out date for the booking.")]
        public DateTime CheckoutDate { get; set; }

        [Required]
        [Column(TypeName ="decimal(18,2)")]
        [Comment("The total price for the booking.")]
        public decimal TotalPrice { get; set; }


        //Navigation Properties

        [Required]
        [Comment("The identifier for the hotel the room belongs to.")]
        public Guid HotelId { get; set; }

        [ForeignKey(nameof(HotelId))]
        public virtual Hotel Hotel { get; set; } = null!;

        [Required]
        [Comment("The identifier for the guest making the booking.")]
        public Guid GuestId { get; set; }

        [ForeignKey(nameof(GuestId))]
        public virtual Guest Guest { get; set; } = null!;

        [Required]
        [Comment("The identifier of the room associated with the booking.")]
        public Guid RoomId { get; set; }

        [ForeignKey(nameof(RoomId))]
        public virtual Room Room { get; set; } = null!;

        [Comment("The identifier for the staff member managing the booking.")]
        public Guid? StaffId { get; set; }

        [ForeignKey(nameof(StaffId))]
        public virtual Staff? Staff { get; set; }

        [Comment("Collection of payments associated with this booking.")]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
