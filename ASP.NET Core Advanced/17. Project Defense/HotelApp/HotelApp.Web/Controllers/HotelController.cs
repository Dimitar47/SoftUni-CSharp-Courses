using HotelApp.Data;
using HotelApp.Data.Models;
using HotelApp.Web.ViewModels.Hotel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static HotelApp.Common.EntityValidationConstants.Hotel;

using Microsoft.AspNetCore.Mvc.Rendering;
using HotelApp.Web.ViewModels.Room;
namespace HotelApp.Web.Controllers
{
    public class HotelController : BaseController
    {
        private readonly HotelDbContext dbContext;

        public HotelController(HotelDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<HotelIndexViewModel> allHotels = await this.dbContext.Hotels
                 .Where(h => !h.IsDeleted)
                .Select(h => new HotelIndexViewModel()
                {
                    Id = h.Id.ToString(),
                    Name = h.Name,
                    Address = h.Address,
                    ImageURL = h.ImageURL
                })
                .OrderBy(h => h.Name)
                .ThenBy(h => h.Address)
                .ToListAsync();

            return View(allHotels);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddHotelFormModel inputModel)
        {

            bool isCheckinTimeValid = TimeSpan.TryParseExact(inputModel.CheckinTime, CheckInOutTimeSpanFormat, CultureInfo.InvariantCulture, TimeSpanStyles.None, out TimeSpan validCheckinTime);

            if (!isCheckinTimeValid)
            {
                this.ModelState.AddModelError(nameof(inputModel.CheckinTime),
                    String.Format("The Check-in Time must be in the following format: {0}", CheckInOutTimeSpanFormat));
            }


            bool isCheckoutTimeValid = TimeSpan.TryParseExact(inputModel.CheckoutTime, CheckInOutTimeSpanFormat, CultureInfo.InvariantCulture, TimeSpanStyles.None, out TimeSpan validCheckoutTime);

            if (!isCheckoutTimeValid)
            {
                this.ModelState.AddModelError(nameof(inputModel.CheckoutTime),
                    String.Format("The Check-out Time must be in the following format: {0}", CheckInOutTimeSpanFormat));
            }


            if (!this.ModelState.IsValid)
            {
                //Render the same form with user entered values + model errors
                return this.View(inputModel);
            }


            Hotel hotel = new Hotel()
            {
                Name = inputModel.Name,
                Address = inputModel.Address,
                ImageURL = inputModel.ImageURL,
                Phone = inputModel.Phone,
                Email = inputModel.Email,
                Stars = inputModel.Stars,
                CheckinTime = validCheckinTime,
                CheckoutTime = validCheckoutTime
            };


            await this.dbContext.Hotels.AddAsync(hotel);
            await this.dbContext.SaveChangesAsync();

            return this.RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            Guid hotelGuid = Guid.Empty;
            bool isGuidValid = IsGuidValid(id, ref hotelGuid);

            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            Hotel? hotel = await this.dbContext.Hotels
                .Where(h => h.IsDeleted == false)
                .Include(h => h.HotelRooms.Where(hr => hr.IsDeleted == false))
                .ThenInclude(hr => hr.Room)
                .FirstOrDefaultAsync(h => h.Id == hotelGuid);

            // Invalid(Non-existing) GUID in the URL
            if (hotel == null)
            {
                return this.RedirectToAction(nameof(Index));
            }



            // Optional: Get rooms that are not associated with any hotel
            var unassociatedRooms = await this.dbContext.Rooms
                .Where(r => r.RoomHotels.Count == 0 && !r.IsDeleted) // Rooms with no hotel association
                .Select(r => new HotelRoomViewModel
                {
                    RoomNumber = r.RoomNumber,
                    Status = r.Status,
                    ImageURL = r.ImageURL
                })
                .ToListAsync();

            var hotelRooms = hotel.HotelRooms
                                     .Where(hr => hr.IsDeleted == false && hr.Room.IsDeleted == false)
                                    .Select(hr => new HotelRoomViewModel()
                                    {
                                        RoomNumber = hr.Room.RoomNumber,
                                        Status = hr.Room.Status,
                                        ImageURL = hr.Room.ImageURL
                                    })
                                    .OrderBy(hrvm => hrvm.RoomNumber)
                                    .ToList();

            HotelDetailsViewModel viewModel = new HotelDetailsViewModel()
            {
                Name = hotel.Name,
                Address = hotel.Address,
                ImageURL = hotel.ImageURL,
                Phone = hotel.Phone,
                Email = hotel.Email,
                Stars = hotel.Stars,
                CheckinTime = hotel.CheckinTime.ToString(CheckInOutTimeSpanFormat),
                CheckoutTime = hotel.CheckoutTime.ToString(CheckInOutTimeSpanFormat),
                Rooms = hotelRooms,
                UnassociatedRooms = unassociatedRooms

            };

            return this.View(viewModel);
        }



    }
}
