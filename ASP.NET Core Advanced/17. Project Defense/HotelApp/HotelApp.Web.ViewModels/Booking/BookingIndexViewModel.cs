using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Web.ViewModels.Booking
{
    public class BookingIndexViewModel
    {

        public string Id { get; set; } = null!;

        public string GuestName { get; set; } = null!;

        public string HotelName { get; set; } = null!;

        public string RoomType { get; set; } = null!;

        public int RoomNumber { get; set; }

        public string CheckinDate { get; set; } = null!;

        public string CheckoutDate { get; set; } = null!;

        public decimal TotalPrice { get; set; }
    }
}
