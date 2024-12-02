using System.ComponentModel.DataAnnotations;
using static HotelApp.Common.EntityValidationConstants.Hotel;
using static HotelApp.Common.EntityValidationMessages.Hotel;



namespace HotelApp.Web.ViewModels.Hotel
{
    public class AddHotelFormModel
    {
        public AddHotelFormModel()
        {
            CheckinTime = new TimeSpan(14, 0, 0).ToString(CheckInOutTimeSpanFormat);
            CheckoutTime = new TimeSpan(11, 0, 0).ToString(CheckInOutTimeSpanFormat);
        }


        [Required(ErrorMessage = NameRequiredMessage)]
        [MinLength(HotelNameMinLength)]
        [MaxLength(HotelNameMaxLength)]
        public string Name { get; set; } = null!;


        [Required(ErrorMessage = AddressRequiredMessage)]
        [MaxLength(HotelAddressMaxLength)]
        public string Address { get; set; } = null!;

        [Display(Name ="Image URL")]
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
        [Range(HotelStarsMinLength,HotelStarsMaxLength)]
        public int Stars { get; set; }

        [Required(ErrorMessage = CheckinTimeRequiredMessage)]
        [Display(Name= "Check-in time")]
        public string CheckinTime { get; set; }

        [Required(ErrorMessage = CheckoutTimeRequiredMessage)]
        [Display(Name = "Check-out time")]
        public string CheckoutTime { get; set; }
    }
}
