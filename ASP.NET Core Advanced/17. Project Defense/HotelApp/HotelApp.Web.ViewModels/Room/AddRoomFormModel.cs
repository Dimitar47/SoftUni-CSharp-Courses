using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using static HotelApp.Common.EntityValidationConstants.Room;
using static HotelApp.Common.EntityValidationMessages.Room;

namespace HotelApp.Web.ViewModels.Room
{
    public class AddRoomFormModel
    {
       
        [Required(ErrorMessage = RoomNumberRequiredMessage)]
        [Range(RoomNumberMinLength, RoomNumberMaxLength)]
        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }

        [Required(ErrorMessage = RoomStatusRequiredMessage)]
        [MaxLength(RoomStatusMaxLength)]
        [Display(Name = "Status")]
        public string Status { get; set; } = "Available"; // Default value

        [Display(Name = "Image URL")]
        public string? ImageURL { get; set; }

        
        [Display(Name = "Hotel")]
        public Guid? HotelId { get; set; }

        public IEnumerable<SelectListItem> Hotels { get; set; } = new List<SelectListItem>();

        [Required]
        [Display(Name = "Room Type")]
        public Guid RoomTypeId { get; set; }

        public IEnumerable<SelectListItem> RoomTypes { get; set; } = new List<SelectListItem>();


     
        
      
    }
}

