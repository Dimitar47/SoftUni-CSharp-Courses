
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HotelApp.Common.EntityValidationConstants.RoomType;
using static HotelApp.Common.EntityValidationMessages.RoomType;
namespace HotelApp.Data.Models
{
    public class RoomType
    {
        public RoomType()
        {
            this.Id = Guid.NewGuid();
            this.Rooms = new HashSet<Room>();
        }

        [Key]
        [Comment("Primary key and unique identifier for the room type.")]
        public Guid Id { get; set; }


        [Required]
        [MaxLength(RoomTypeNameMaxLength)]
       
        [Comment("The name of the room type - Single, Double, Suite.")] //According to Wikipedia a suite means:
                                                                       //A suite in a hotel or other public accommodation (eg a cruise ship)                                    denotes, according to most dictionary definitions, connected rooms                                      under one room number.
        public string Name { get; set; } = null!;

        [MaxLength(RoomTypeDescriptionMaxLength)]
        [Comment("A description of the room type, detailing features or amenities.")]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Comment("The nightly price for this type of room.")]
        public decimal PricePerNight { get; set; }

        [Required]
        [Comment("The maximum capacity of this room type.")]
        public int Capacity { get; set; }



        //Navigation Properties

        [Comment("Collection of rooms that belong to this room type.")]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}