using HotelApp.Data;
using HotelApp.Web.ViewModels.Room;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Web.Controllers
{
    public class RoomController : BaseController
    {
        private readonly HotelDbContext dbContext;

        public RoomController(HotelDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //Perfect
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var roomAssociations = await dbContext.HotelsRooms
                                     .Include(hr => hr.Hotel)
                                     .Include(hr => hr.Room)
                                     .ThenInclude(r => r.RoomType)
                                     .Where(hr => !hr.IsDeleted &&
                                             !hr.Room.IsDeleted &&
                                             !hr.Hotel.IsDeleted)
                                     .Select(hr => new RoomIndexViewModel
                                     {
                                         Id = hr.Room.Id.ToString(),
                                         RoomNumber = hr.Room.RoomNumber,
                                         Status = hr.Room.Status,
                                         ImageURL = hr.Room.ImageURL,
                                         RoomTypeName = hr.Room.RoomType.Name,
                                         HotelName = hr.Hotel != null ? hr.Hotel.Name : "Unassociated",
                                         HotelAddress = hr.Hotel != null ? hr.Hotel.Address : "N/A"
                                     })
                                     .ToListAsync();


            var unassociatedRooms = await dbContext.Rooms
                .Include(r => r.RoomType)
                .Where(r => !r.IsDeleted &&
                       !r.RoomHotels.Any(rh =>
                           !rh.IsDeleted && !rh.Hotel.IsDeleted))
                .Select(r => new RoomIndexViewModel
                {
                    Id = r.Id.ToString(),
                    RoomNumber = r.RoomNumber,
                    Status = r.Status,
                    ImageURL = r.ImageURL,
                    RoomTypeName = r.RoomType.Name,
                    HotelName = "Unassociated",
                    HotelAddress = "N/A"
                })
                .ToListAsync();

            var rooms = roomAssociations.Concat(unassociatedRooms)
                               .OrderBy(r => r.RoomNumber)
                               .ToList();

            return this.View(rooms);
        }

    }
}
