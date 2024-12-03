using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Web.ViewModels.Room
{
    public class RoomIndexViewModel
    {
        public string Id { get; set; } = null!;

        public int RoomNumber { get; set; }

        public string Status { get; set; } = null!;

        public string? ImageURL { get; set; }

        public string HotelName { get; set; } = null!;

        public string HotelAddress { get; set; } = null!;

        public string RoomTypeName { get; set; } = null!;
       
    }
}
