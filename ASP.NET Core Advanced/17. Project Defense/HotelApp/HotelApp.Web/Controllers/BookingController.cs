using HotelApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static HotelApp.Common.EntityValidationConstants.Booking;
using HotelApp.Web.ViewModels.Booking;

namespace HotelApp.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly HotelDbContext dbContext;

        public BookingController(HotelDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<IActionResult> Index()
        {
            var bookings = await dbContext.Bookings
                .Include(b => b.Guest)
                .Include(b => b.Room)
                .ThenInclude(r => r.RoomType)
                .Include(b => b.Hotel)
                .Select(b => new BookingIndexViewModel
                {
                    Id = b.Id.ToString(),
                    GuestName = $"{b.Guest.FirstName} {b.Guest.LastName}",
                    HotelName = b.Hotel.Name,
                    RoomType = b.Room.RoomType.Name,
                    RoomNumber = b.Room.RoomNumber,
                    CheckinDate = b.CheckinDate.ToString(CheckInOutDateFormat),
                    CheckoutDate = b.CheckoutDate.ToString(CheckInOutDateFormat),
                    TotalPrice = b.TotalPrice               
                })
                .ToListAsync();

            return View(bookings);
         
        }
        
    

    }
}
