using HotelApp.Web.ViewModels.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Web.ViewModels.Hotel
{
    public class HotelDetailsViewModel
    {

        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int Stars { get; set; }

        public string? ImageURL { get; set; }

        public string CheckinTime { get; set; } = null!;

        public string CheckoutTime { get; set; } = null!;

        public IEnumerable<HotelRoomViewModel> Rooms { get; set; } = new HashSet<HotelRoomViewModel>();


        public IEnumerable<HotelRoomViewModel> UnassociatedRooms { get; set; } = new HashSet<HotelRoomViewModel>();
    }

   
}
