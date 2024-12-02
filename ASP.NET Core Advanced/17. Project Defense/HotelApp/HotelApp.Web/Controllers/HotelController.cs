using HotelApp.Data;
using HotelApp.Data.Models;
using HotelApp.Web.ViewModels.Hotel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static HotelApp.Common.EntityValidationConstants.Hotel;

using Microsoft.AspNetCore.Mvc.Rendering;
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


    }
}
