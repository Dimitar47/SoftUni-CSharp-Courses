using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HotelApp.Common.EntityValidationConstants.Room;


namespace HotelApp.Data.Models
{
    public class Room
    {
        public Room()
        {
            this.Id = Guid.NewGuid();
            this.Bookings = new HashSet<Booking>();
            this.RoomHotels = new HashSet<HotelRoom>();
        }

        [Key]
        [Comment("Primary key and unique identifier for the room.")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(RoomNumberMaxLength)]
        [Comment("Unique number identifying the room within a hotel.")]
        public int RoomNumber { get; set; }


        [Required]
        [MaxLength(RoomStatusMaxLength)]
        [Comment("The status of the room - Available, Occupied, Cleaning")]
        public string Status { get; set; } = null!;


        [Comment("The image URL for the room's picture.")]
        public string? ImageURL { get; set; }

        //Navigation Properties
        [Required]
        public bool IsDeleted { get; set; } 

        [Required]
        [Comment("The identifier for the room's type")]
        public Guid RoomTypeId { get; set; }

        [ForeignKey(nameof(RoomTypeId))]
        public virtual RoomType RoomType { get; set; } = null!;


        [Comment("Collection of bookings associated with this room.")]
        public virtual ICollection<Booking> Bookings { get; set; }

        [Comment("Collection of hotels associated with the room.")]
        public virtual ICollection<HotelRoom> RoomHotels { get; set; }
    }
}
