using Humanizer.Localisation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data;
using SeminarHub.Models;
using System.Globalization;
using System.Security.Claims;
using System.Security.Policy;

namespace SeminarHub.Controllers
{
    [Authorize]
    public class SeminarController : Controller
    {
        private readonly SeminarHubDbContext context;

        public SeminarController(SeminarHubDbContext _context)
        {
            context = _context;
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new SeminarViewModel();

            model.Categories = await GetCategories();
            return View(model);
        }
        

        [HttpPost]
        public async Task<IActionResult> Add(SeminarViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                model.Categories = await GetCategories();
                return View(model);
            }

            DateTime dateAndTime;


            if (DateTime.TryParseExact(model.DateAndTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateAndTime)
                == false)
            {
                ModelState.AddModelError(nameof(model.DateAndTime), "Invalid date and time format");
                model.Categories = await GetCategories();

                return View(model);
            }

            Seminar seminar = new Seminar()
            {
                Topic = model.Topic,
                Lecturer = model.Lecturer,
                Details = model.Details,
                DateAndTime = dateAndTime,
                Duration = model.Duration,
                OrganizerId = GetCurrentUserId() ?? string.Empty,
                CategoryId = model.CategoryId



            };

            await context.Seminars.AddAsync(seminar);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await context.Seminars
                
                .Select(g => new SeminarInfoViewModel()
                {
                    Id = g.Id,
                    Topic = g.Topic,
                    Lecturer = g.Lecturer,
                    Category = g.Category.Name,
                    DateAndTime = g.DateAndTime.ToString("dd/MM/yyyy HH:mm"),
                    Organizer = g.Organizer.UserName ?? string.Empty,
                })
                .AsNoTracking()
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            string currentUserId = GetCurrentUserId() ?? string.Empty;

            var model = await context.Seminars
                .Where(g => g.SeminarsParticipants.Any(x => x.ParticipantId == currentUserId))
                .Select(g => new JoinedViewModel()
                {
                    Id = g.Id,
                    Topic = g.Topic,
                    Lecturer = g.Lecturer,
                    DateAndTime = g.DateAndTime.ToString("dd/MM/yyyy HH:mm"),
                    Organizer = g.Organizer.UserName ?? string.Empty,
                })
                .AsNoTracking()
                .ToListAsync();

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            Seminar? existingSeminar = await context.Seminars.Where(x => x.Id == id).Include(x => x.SeminarsParticipants).FirstOrDefaultAsync();

            if (existingSeminar == null)
            {
                throw new ArgumentException("Invalid id");
            }
            string currentUserId = GetCurrentUserId() ?? string.Empty;

            if (existingSeminar.SeminarsParticipants.Any(x => x.ParticipantId == currentUserId)) 
            {

                return RedirectToAction(nameof(All));

            }

            existingSeminar.SeminarsParticipants.Add(new SeminarParticipant { ParticipantId = currentUserId, Seminar = existingSeminar });

            await context.SaveChangesAsync();



            return RedirectToAction(nameof(Joined));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            Seminar? existingSeminar = await context.Seminars.Where(x => x.Id == id).Include(x => x.SeminarsParticipants).FirstOrDefaultAsync();

            if (existingSeminar == null)
            {
                throw new ArgumentException("Invalid id");
            }

            string currentUserId = GetCurrentUserId() ?? string.Empty;
            SeminarParticipant? seminarParticipant = existingSeminar.SeminarsParticipants.FirstOrDefault(x => x.ParticipantId == currentUserId);
            if (seminarParticipant != null)
            {
                existingSeminar.SeminarsParticipants.Remove(seminarParticipant);

                await context.SaveChangesAsync();
            }



            return RedirectToAction(nameof(Joined));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await context.Seminars.Where(g => g.Id == id).AsNoTracking().Select(g => new SeminarViewModel
                {
                    Topic = g.Topic,
                    Lecturer = g.Lecturer,
                    Details = g.Details,
                    DateAndTime = g.DateAndTime.ToString("dd/MM/yyyy HH:mm"),
                    Duration = g.Duration,
                    CategoryId = g.CategoryId
                }).FirstOrDefaultAsync();

            model.Categories = await GetCategories();
            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Edit(SeminarViewModel model, int id)
        {
            if (ModelState.IsValid == false)
            {
                model.Categories = await GetCategories();
                return View(model);
            }

            DateTime dateAndTime;


            if (DateTime.TryParseExact(model.DateAndTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateAndTime)
                == false)
            {
                ModelState.AddModelError(nameof(model.DateAndTime), "Invalid date and time format");
                model.Categories = await GetCategories();

                return View(model);
            }
            Seminar? existingSeminar = await context.Seminars.FindAsync(id);

            if (existingSeminar == null)
            {
                throw new ArgumentException("Invalid id");
            }
            string currentUserId = GetCurrentUserId() ?? string.Empty;

            if (existingSeminar.OrganizerId != currentUserId)
            {
                return RedirectToAction(nameof(All));
            }
            existingSeminar.Topic = model.Topic;
            existingSeminar.Lecturer = model.Lecturer;
            existingSeminar.Details = model.Details;
            existingSeminar.OrganizerId = GetCurrentUserId() ?? string.Empty;
            existingSeminar.DateAndTime = dateAndTime;
            existingSeminar.Duration = model.Duration;
            existingSeminar.CategoryId = model.CategoryId;






            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await context.Seminars.Where(x => x.Id == id).Select(x => new DetailsViewModel()
            {
                Id = x.Id,
                Topic = x.Topic,
                DateAndTime = x.DateAndTime.ToString("dd/MM/yyyy HH:mm"),
                Duration = x.Duration,
                Lecturer = x.Lecturer,
                Category = x.Category.Name,
                Details = x.Details,
                Organizer = x.Organizer.UserName ?? string.Empty
            }).FirstOrDefaultAsync();



            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await context.Seminars.Where(x => x.Id == id).AsNoTracking().Select(x =>
            new DeleteViewModel()
            {
                Id = x.Id,
                Topic = x.Topic,
                DateAndTime = x.DateAndTime
            }).FirstOrDefaultAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(DeleteViewModel model)
        {
            Seminar? seminar = await context.Seminars.Where(x => x.Id == model.Id).FirstOrDefaultAsync();

            if (seminar != null)
            {
                context.Seminars.Remove(seminar);
                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(All));
        }


        private async Task<List<Category>> GetCategories()
        {
            return await context.Categories.ToListAsync();
        }

        private string? GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

    }
}
