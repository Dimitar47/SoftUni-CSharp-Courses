using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HotelApp.Common.EntityValidationConstants.Hotel;
using static HotelApp.Common.EntityValidationMessages.Hotel;

namespace HotelApp.Web.ViewModels.Hotel
{
    public class EditHotelFormModel
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = NameRequiredMessage)]
        [MinLength(HotelNameMinLength)]
        [MaxLength(HotelNameMaxLength)]
        public string Name { get; set; } = null!;


        [Required(ErrorMessage = AddressRequiredMessage)]
        [MaxLength(HotelAddressMaxLength)]
        public string Address { get; set; } = null!;

        [Display(Name = "Image URL")]
        public string? ImageURL { get; set; }

        [Required(ErrorMessage = PhoneRequiredMessage)]
        [Phone]
        [MaxLength(HotelPhoneMaxLength)]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = EmailRequiredMessage)]
        [EmailAddress]
        [MaxLength(HotelEmailMaxLength)]
        public string Email { get; set; } = null!;


        [Required(ErrorMessage = StarsRequiredMessage)]
        [Range(HotelStarsMinLength, HotelStarsMaxLength)]
        public int Stars { get; set; }

        [Required(ErrorMessage = CheckinTimeRequiredMessage)]
        [Display(Name = "Check-in time")]
        public string CheckinTime { get; set; } = null!;

        [Required(ErrorMessage = CheckoutTimeRequiredMessage)]
        [Display(Name = "Check-out time")]
        public string CheckoutTime { get; set; } = null!;
    }
}
