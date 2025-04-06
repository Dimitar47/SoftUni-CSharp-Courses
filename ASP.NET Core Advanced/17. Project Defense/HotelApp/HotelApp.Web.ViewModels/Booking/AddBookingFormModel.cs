using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HotelApp.Common.EntityValidationMessages.Booking;
using static HotelApp.Common.EntityValidationConstants.Booking;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace HotelApp.Web.ViewModels.Booking
{
    public class AddBookingFormModel
    {
        [Required(ErrorMessage = CheckinDateRequiredMessage)]
        [Display(Name = "Check-in Date")]
        public string CheckinDate { get; set; } = null!;

        [Required(ErrorMessage = CheckoutDateRequiredMessage)]
        [Display(Name = "Check-out Date")]
        public string CheckoutDate { get; set; } = null!;


        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; } 


        [Required(ErrorMessage = GuestRequiredMessage)]
        [Display(Name = "Guest")]
        public string GuestId { get; set; } = null!;

        [Required(ErrorMessage = HotelRequiredMessage)]
        [Display(Name = "Hotel")]
        public string HotelId { get; set; } = null!;

        [Required(ErrorMessage = RoomRequiredMessage)]
        [Display(Name = "Room")]
        public string RoomId { get; set; } = null!;

        public IEnumerable<SelectListItem> Guests { get; set; } =  new List<SelectListItem>();
        public IEnumerable<SelectListItem> Hotels { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> AvailableRooms { get; set; } = new List<SelectListItem>();
    }
}
