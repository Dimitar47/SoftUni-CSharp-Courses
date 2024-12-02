using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HotelApp.Common.EntityValidationConstants.Payment;


namespace HotelApp.Data.Models
{
    public class Payment
    {
        public Payment()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        [Comment("Primary key and unique identifier for the payment.")]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Comment("The amount of the payment.")]
        public decimal Amount { get; set; }

        [Required]
        [Comment("The date the payment was made.")]
        public DateTime PaymentDate { get; set; }

        [Required]
        [MaxLength(PaymentMethodMaxLength)]
        [Comment("The method of payment - Credit Card, Cash, Bank Wire Transfer.")]
        public string PaymentMethod { get; set; } = null!;


        //Navigation Properties

        [Required]
        [Comment("The identifier for the associated booking.")]
        public Guid BookingId { get; set; }

        [ForeignKey(nameof(BookingId))]
        public virtual Booking Booking { get; set; } = null!;

    }
}
