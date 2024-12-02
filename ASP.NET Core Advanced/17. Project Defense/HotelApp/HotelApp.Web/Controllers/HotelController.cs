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

        
    }
}
