using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HotelApp.Common.EntityValidationConstants.Room;
using static HotelApp.Common.EntityValidationMessages.Room;
namespace HotelApp.Web.ViewModels.Room
{
    public class EditRoomFormModel
    {
        [Required]
        public string RoomId { get; set; } = null!;

        [Required(ErrorMessage = RoomNumberRequiredMessage)]
        [Range(RoomNumberMinLength, RoomNumberMaxLength)]
        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }

        [Required(ErrorMessage = RoomStatusRequiredMessage)]
        [MaxLength(RoomStatusMaxLength)]
        [Display(Name = "Status")]
        public string Status { get; set; } = null!;

        [Display(Name = "Image URL")]
        public string? ImageURL { get; set; }

        [Display(Name = "Hotel")]
        public Guid? HotelId { get; set; }

        public IEnumerable<SelectListItem> Hotels { get; set; } = new List<SelectListItem>();

        [Required]
        [Display(Name = "Room Type")]
        public Guid RoomTypeId { get; set; }

        public IEnumerable<SelectListItem> RoomTypes { get; set; } = new List<SelectListItem>();

        public IEnumerable<SelectListItem> StatusOptions { get; set; } = new List<SelectListItem>();

    }
}
