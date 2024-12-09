using HotelApp.Web.ViewModels.Hotel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


using static HotelApp.Common.EntityValidationConstants.Room;
using static HotelApp.Common.EntityValidationMessages.Room;


namespace HotelApp.Web.ViewModels.Room
{
    public class AddRoomToHotelInputModel
    {
        [Required]
        public string RoomId { get; set; } = null!;

        [Required(ErrorMessage = RoomNumberRequiredMessage)]
        [Range(RoomNumberMinLength, RoomNumberMaxLength)]
        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }

        [Required(ErrorMessage = "You must select a hotel.")]
        [Display(Name ="Hotel")]
        public string SelectedHotelId { get; set; } = null!;

        public IEnumerable<SelectListItem> Hotels { get; set; } = new List<SelectListItem>();
    }
}
