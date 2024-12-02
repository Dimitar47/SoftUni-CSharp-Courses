using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Web.ViewModels.Room
{
    public class HotelRoomViewModel
    {
        public int RoomNumber { get; set; }

        public string Status { get; set; } = null!;
        
        public string? ImageURL { get; set; }
    }
}
