using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Web.ViewModels.Room
{
    public class RoomDetailsViewModel
    {
        [Display(Name = "Image URL")]
        public string? ImageURL { get; set; }

        [Display(Name = "Associated Hotels")]
        public List<string> Hotels { get; set; } = new List<string>();

        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }

        public string Status { get; set; } = null!;


        [Display(Name ="Room Type")]
        public string TypeName { get; set; } = null!;

        [Display(Name = "Room Description")]
        public string? TypeDescription { get; set; }

        [Display(Name = "Price per night")]
        public decimal TypePricePerNight { get; set; } 

        [Display(Name ="Room Capacity")]
        public int TypeCapacity { get; set; }



    }
}
