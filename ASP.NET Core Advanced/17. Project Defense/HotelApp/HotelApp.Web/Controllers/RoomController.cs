using HotelApp.Data;
using HotelApp.Data.Models;
using HotelApp.Web.ViewModels.Room;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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


      
        [HttpGet]
        public async Task<IActionResult> Create()
        {


            var hotelsList = await dbContext.Hotels
                .Where(h => h.IsDeleted == false)
                .Select(h => new SelectListItem
                {
                    Value = h.Id.ToString(),
                    Text = h.Name + " - " + h.Address
                })
                .ToListAsync();




            var roomTypes = dbContext.RoomTypes
                                    .Select(rt => new SelectListItem
                                    {
                                        Value = rt.Id.ToString(),
                                        Text = rt.Name
                                    })
                                    .AsEnumerable()
                                    .DistinctBy(rt => rt.Text)
                                    .ToList();


            var model = new AddRoomFormModel
            {
                Hotels = hotelsList,
                RoomTypes = roomTypes
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddRoomFormModel model)
        {
            var hotelsList = await dbContext.Hotels
                                           .Where(h => h.IsDeleted == false)
                                           .Select(h => new SelectListItem
                                           {
                                               Value = h.Id.ToString(),
                                               Text = h.Name + " - " + h.Address
                                           })

                                           .ToListAsync();

            var roomTypes = dbContext.RoomTypes
                                    .Select(rt => new SelectListItem
                                    {
                                        Value = rt.Id.ToString(),
                                        Text = rt.Name
                                    })
                                     .AsEnumerable()
                                    .DistinctBy(rt => rt.Text)
                                    .ToList();

            if (!ModelState.IsValid)
            {
                model.Hotels = hotelsList;
                model.RoomTypes = roomTypes;
                return View(model);
            }



            if (model.HotelId.HasValue)
            {
                var roomExistsInHotel = await dbContext.HotelsRooms
                    .Where(hr => hr.IsDeleted == false && hr.Hotel!.IsDeleted == false && hr.Room.IsDeleted == false)
                    .AnyAsync(hr => hr.HotelId == model.HotelId && hr.Room.RoomNumber == model.RoomNumber);

                if (roomExistsInHotel)
                {

                    ModelState.AddModelError("RoomNumber", "This room number already exists in the selected hotel.");
                    model.Hotels = hotelsList;
                    model.RoomTypes = roomTypes;
                    return View(model);
                }
            }
            else
            {

                var unassociatedRoomExists = await dbContext.Rooms
                                                .Where(r => !r.IsDeleted && !r.RoomHotels.Any(rh => !rh.IsDeleted && !rh.Hotel.IsDeleted))
                                                .AnyAsync(r => r.RoomNumber == model.RoomNumber);

                //"For each room, check that it has no active associations in the RoomHotels collection. In other words, ensure there are no HotelRooms entries linked to the room where the IsDeleted flag is false (meaning the association is not deleted)."

                if (unassociatedRoomExists)
                {
                    ModelState.AddModelError("RoomNumber", "An unassociated room with this room number already exists.");
                    model.Hotels = hotelsList;
                    model.RoomTypes = roomTypes;
                    return View(model);
                }
            }


            Room room = new Room
            {
                RoomNumber = model.RoomNumber,
                Status = model.Status,
                ImageURL = model.ImageURL,
                RoomTypeId = model.RoomTypeId
            };


            await dbContext.Rooms.AddAsync(room);
            await dbContext.SaveChangesAsync();


            if (model.HotelId.HasValue)
            {

                var hotelRoom = new HotelRoom
                {
                    RoomId = room.Id,
                    HotelId = model.HotelId.Value
                };


                await dbContext.HotelsRooms.AddAsync(hotelRoom);
                await dbContext.SaveChangesAsync();
            }


            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            Guid roomGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref roomGuid);

            if (!isGuidValid)
            {
                // Invalid id format
                return this.RedirectToAction(nameof(Index));
            }

            Room? room = await this.dbContext.Rooms
                                    .Where(r => r.IsDeleted == false)
                                    .Include(r => r.RoomType)
                                    .Include(r => r.RoomHotels)
                                    .ThenInclude(rh => rh.Hotel)
                                    .FirstOrDefaultAsync(r => r.Id == roomGuid);


            if (room == null)
            {
                // Non-existing room guid
                return this.RedirectToAction(nameof(Index));
            }

            RoomDetailsViewModel viewModel = new RoomDetailsViewModel()
            {
                Hotels = room.RoomHotels
                  .Where(hr => hr.IsDeleted == false && hr.Hotel.IsDeleted == false && hr.Room.IsDeleted == false)
                 .Select(hr => $"{hr.Hotel?.Name ?? "Unassociated"} - {hr.Hotel?.Address ?? "N/A"}")
                 .ToList(),
                RoomNumber = room.RoomNumber,
                Status = room.Status,
                ImageURL = room.ImageURL,
                TypeName = room.RoomType.Name,
                TypeDescription = room.RoomType.Description,
                TypePricePerNight = room.RoomType.PricePerNight,
                TypeCapacity = room.RoomType.Capacity
            };


            if (viewModel.Hotels.Count == 0)
            {
                viewModel.Hotels.Add("This room is not yet associated with any hotel.");
            }

            return this.View(viewModel);



        }



    }
}
