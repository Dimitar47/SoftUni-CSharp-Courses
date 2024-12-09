using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Web.ViewModels.Room
{
    public class RoomDeleteViewModel
    {
        public string RoomId { get; set; } = null!;

        public int RoomNumber { get; set; } 

        public string RoomTypeName { get; set; } = null!;

        public string RoomStatus { get; set; } = null!;

        public bool IsAssociated { get; set; } 

       
        public string? HotelName { get; set; }

        public string? HotelAddress { get; set; }
    }
}
