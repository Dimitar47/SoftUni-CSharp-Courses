using HotelApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static HotelApp.Common.EntityValidationConstants.Booking;
using HotelApp.Web.ViewModels.Booking;

using HotelApp.Web.ViewModels.Hotel;
using Microsoft.AspNetCore.Mvc.Rendering;
using HotelApp.Data.Models;
using System.Globalization;


namespace HotelApp.Web.Controllers
{
    public class BookingController : BaseController
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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new AddBookingFormModel
            {
                Guests = await dbContext.Guests
                    .Select(g => new SelectListItem
                    {
                        Value = g.Id.ToString(),
                        Text = $"{g.FirstName} {g.LastName}"
                    })
                    .ToListAsync(),
                Hotels = await dbContext.Hotels
                    .Where(h => !h.IsDeleted)
                    .Select(h => new SelectListItem
                    {
                        Value = h.Id.ToString(),
                        Text = h.Name + " - " + h.Address
                    })
                    .ToListAsync(),
                AvailableRooms = Enumerable.Empty<SelectListItem>() 
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddBookingFormModel model)
        {
            if (!DateTime.TryParse(model.CheckinDate, out DateTime validCheckinDate))
            {
                ModelState.AddModelError(nameof(model.CheckinDate), "The Check-in Date is invalid.");
            }

            if (!DateTime.TryParse(model.CheckoutDate, out DateTime validCheckoutDate))
            {
                ModelState.AddModelError(nameof(model.CheckoutDate), "The Check-out Date is invalid.");
            }

            Guid hotelGuid = Guid.Empty;
            bool isHotelGuidValid = IsGuidValid(model.HotelId, ref hotelGuid);

            if (!isHotelGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            Guid roomGuid = Guid.Empty;
            bool isRoomGuidValid = IsGuidValid(model.RoomId, ref roomGuid);

            if (!isRoomGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            Guid guestGuid = Guid.Empty;
            bool isGuestGuidValid = IsGuidValid(model.GuestId, ref guestGuid);

            if (!isGuestGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            // Calculate the number of nights
            var stayDuration = (validCheckoutDate - validCheckinDate).Days;
            if (stayDuration <= 0)
            {
                ModelState.AddModelError(nameof(model.CheckoutDate), "Checkout date must be later than check-in date.");

            }

            var hotel = await dbContext.Hotels.FirstOrDefaultAsync(h => h.Id == Guid.Parse(model.HotelId) && !h.IsDeleted);

            if (hotel == null)
            {
                ModelState.AddModelError(nameof(model.HotelId), "The selected hotel is invalid.");
           
            }

            var guest = await dbContext.Guests.FirstOrDefaultAsync(g => g.Id == Guid.Parse(model.GuestId));

            if (guest == null)
            {
                ModelState.AddModelError(nameof(model.GuestId), "The selected guest is invalid.");
           
            }

            var room = await dbContext.Rooms
                .Include(r=>r.RoomType)
                .Include(r => r.RoomHotels)
                .FirstOrDefaultAsync(r =>
                    r.Id == Guid.Parse(model.RoomId) &&
                    !r.IsDeleted && 
                    r.RoomHotels.Any(rh => rh.HotelId == Guid.Parse(model.HotelId) && !rh.IsDeleted)); // Association is valid

            if (room == null)
            {
                ModelState.AddModelError(nameof(model.RoomId), "The selected room is invalid.");
             
            }
           

            if (!this.ModelState.IsValid)
            {
                //Render the same form with user entered values + model errors

                // Repopulate dropdown lists in case of validation failure

                model.Guests = await dbContext.Guests
                    .Select(g => new SelectListItem
                    {
                        Value = g.Id.ToString(),
                        Text = $"{g.FirstName} {g.LastName}"
                    })
                    .ToListAsync();

                model.Hotels = await dbContext.Hotels
                    .Where(h => !h.IsDeleted)
                    .Select(h => new SelectListItem
                    {
                        Value = h.Id.ToString(),
                        Text = h.Name + " - " + h.Address
                    })
                    .ToListAsync();

                model.AvailableRooms = await dbContext.Rooms
                     .Include(r => r.RoomType)
                     .Include(r => r.RoomHotels)
                     .Where(r => r.RoomHotels.Any(rh => rh.HotelId == hotel!.Id && !rh.IsDeleted) &&
                                 r.Status == "Available" && !r.IsDeleted)
                     .Select(r => new SelectListItem
                     {
                         Value = $"{r.Id}|{r.RoomType.PricePerNight:F2}",
                         Text = $"Room {r.RoomNumber} - {r.RoomType.Name} (${r.RoomType.PricePerNight:F2})",
                        
                     })
                     .ToListAsync();


                return this.View(model);
            }




 
            var pricePerNight = room!.RoomType.PricePerNight;

            // Calculate the total price
            var totalPrice = stayDuration * pricePerNight;

            model.TotalPrice = totalPrice;

            var booking = new Booking
            {
                CheckinDate = validCheckinDate,
                CheckoutDate = validCheckoutDate,
                TotalPrice = totalPrice,
                HotelId = hotel!.Id,
                GuestId = guest!.Id,
                RoomId = room.Id
            };



            room.Status = "Occupied";
            dbContext.Bookings.Add(booking);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
            

          
        }
    }
}
