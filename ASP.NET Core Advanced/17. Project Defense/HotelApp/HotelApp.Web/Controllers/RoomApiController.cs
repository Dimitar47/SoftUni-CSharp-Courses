using HotelApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Web.Controllers
{


    [Route("api/[controller]")]
    public class RoomApiController : Controller
    {
        private readonly HotelDbContext dbContext;

        public RoomApiController(HotelDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("GetAvailableRooms")]
        public async Task<JsonResult> GetAvailableRooms(string? id)
        {
            if (string.IsNullOrWhiteSpace(id) || !Guid.TryParse(id, out Guid hotelGuid))
            {
                return Json(new { success = false, message = "Invalid hotel ID format." });
            }

            var rooms = await dbContext.Rooms
                .Include(r => r.RoomType)
                .Include(r => r.RoomHotels)
                .Where(r => r.RoomHotels.Any(rh => rh.HotelId == hotelGuid && !rh.IsDeleted) &&
                            r.Status == "Available" && !r.IsDeleted)
                .Select(r => new
                {
                    Value = $"{r.Id}|{r.RoomType.PricePerNight:F2}",
                    Text = $"Room {r.RoomNumber} - {r.RoomType.Name} (${r.RoomType.PricePerNight:F2})",
                    PricePerNight = r.RoomType.PricePerNight
                })
                .ToListAsync();

            if (!rooms.Any())
            {
                return Json(new { success = false, message = "No rooms available for this hotel." });
            }

            return Json(new { success = true, rooms });
        }

    }
}
