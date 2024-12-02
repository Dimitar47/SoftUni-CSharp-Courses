using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApp.Data.Models
{
    public class HotelRoom
    {
        
        [Comment("The identifier for the associated hotel.")]
        public Guid? HotelId { get; set; }

        [ForeignKey(nameof(HotelId))]
        public virtual Hotel? Hotel { get; set; } 

        [Required]
        [Comment("The identifier for the associated room.")]
        public Guid RoomId { get; set; }

        [ForeignKey(nameof(RoomId))]
        public virtual Room Room { get; set; } = null!;

        [Required]
        public bool IsDeleted { get; set; }
        
    }
}
