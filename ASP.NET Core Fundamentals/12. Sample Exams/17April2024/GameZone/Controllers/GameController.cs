using GameZone.Data;
using GameZone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Globalization;
using System.Security.Claims;
using static GameZone.Constants.ModelConstants;
namespace GameZone.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly GameZoneDbContext context;

        public GameController(GameZoneDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await context.Games
                .Where(g=>g.IsDeleted == false)
                .Select(g=> new GameInfoViewModel() 
                { 
                    Id = g.Id,
                    Title = g.Title,
                    ImageUrl = g.ImageUrl,
                    Genre = g.Genre.Name,
                    ReleasedOn = g.ReleasedOn.ToString(GameReleasedOnDateFormat),
                    Publisher = g.Publisher.UserName ?? string.Empty,
                })
                .AsNoTracking()
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new GameViewModel();

            model.Genres = await GetGenres();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GameViewModel model)
        {
            if(ModelState.IsValid == false)
            {
                model.Genres = await GetGenres();
                return View(model);
            }

            DateTime releasedOn;


            if(DateTime.TryParseExact(model.ReleasedOn,GameReleasedOnDateFormat,CultureInfo.InvariantCulture,DateTimeStyles.None,out releasedOn) 
                == false)
            {
                ModelState.AddModelError(nameof(model.ReleasedOn), "Invalid date format");
                model.Genres = await GetGenres();

                return View(model);
            }

            Game game = new Game()
            {
              Title = model.Title,
              Description = model.Description,
              ImageUrl = model.ImageUrl,
              PublishedId = GetCurrentUserId() ?? string.Empty,
              ReleasedOn = releasedOn,
              GenreId = model.GenreId,

              


            };

            await context.Games.AddAsync(game);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await context.Games.Where(g => g.Id == id)
                .Where(g=>g.IsDeleted == false).AsNoTracking().Select(g => new GameViewModel
            {
                Title = g.Title,
                ImageUrl = g.ImageUrl,
                Description = g.Description,
                ReleasedOn = g.ReleasedOn.ToString(GameReleasedOnDateFormat),
                GenreId = g.GenreId
            }).FirstOrDefaultAsync();

            model.Genres = await GetGenres();
            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Edit(GameViewModel model,int id)
        {
            if (ModelState.IsValid == false)
            {
                model.Genres = await GetGenres();
                return View(model);
            }

            DateTime releasedOn;


            if (DateTime.TryParseExact(model.ReleasedOn, GameReleasedOnDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out releasedOn)
                == false)
            {
                ModelState.AddModelError(nameof(model.ReleasedOn), "Invalid date format");
                model.Genres = await GetGenres();

                return View(model);
            }
            Game? existingGame = await context.Games.FindAsync(id);

            if(existingGame  == null || existingGame.IsDeleted)
            {
                throw new ArgumentException("Invalid id");
            }
            string currentUserId = GetCurrentUserId() ?? string.Empty;

            if(existingGame.PublishedId != currentUserId)
            {
                return RedirectToAction(nameof(All));
            }
          
                existingGame.Title = model.Title;
                existingGame.Description = model.Description;
                existingGame.ImageUrl = model.ImageUrl;
                existingGame.PublishedId = GetCurrentUserId() ?? string.Empty;
                existingGame.ReleasedOn = releasedOn;
                existingGame.GenreId = model.GenreId;





         
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }


        [HttpGet]
        public async Task<IActionResult> MyZone()
        {
           string currentUserId = GetCurrentUserId() ?? string.Empty;
      
            var model = await context.Games
                .Where(g => g.IsDeleted == false)
                .Where(g => g.GamersGames.Any(x => x.GamerId == currentUserId))
                .Select(g => new GameInfoViewModel()
                {
                    Id = g.Id,
                    Title = g.Title,
                    ImageUrl = g.ImageUrl,
                    Genre = g.Genre.Name,
                    ReleasedOn = g.ReleasedOn.ToString(GameReleasedOnDateFormat),
                    Publisher = g.Publisher.UserName ?? string.Empty,
                })
                .AsNoTracking()
                .ToListAsync();

            return View(model);
            
        }

        [HttpGet]
        public async Task<IActionResult> AddToMyZone(int id)
        {
            Game? existingGame = await context.Games.Where(x => x.Id == id).Include(x => x.GamersGames).FirstOrDefaultAsync();

            if (existingGame == null || existingGame.IsDeleted)
            {
                throw new ArgumentException("Invalid id");
            }
            string currentUserId = GetCurrentUserId() ?? string.Empty;

            if(existingGame.GamersGames.Any(x=>x.GamerId == currentUserId)) //if it exists , ako go ima
            {

                    return RedirectToAction(nameof(All));
   
            }

                existingGame.GamersGames.Add(new GamerGame { GamerId = currentUserId, Game = existingGame });

                await context.SaveChangesAsync();

        

            return RedirectToAction(nameof(MyZone));
        }

        [HttpGet]
        public async Task<IActionResult> StrikeOut(int id)
        {
            Game? existingGame = await context.Games.Where(x => x.Id == id).Include(x => x.GamersGames).FirstOrDefaultAsync();

            if (existingGame == null || existingGame.IsDeleted)
            {
                throw new ArgumentException("Invalid id");
            }

            string currentUserId = GetCurrentUserId() ?? string.Empty;
            GamerGame? gamerGame =  existingGame.GamersGames.FirstOrDefault(x => x.GamerId == currentUserId);
            if (gamerGame !=null)
            {
                existingGame.GamersGames.Remove(gamerGame);

                await context.SaveChangesAsync();
            }



            return RedirectToAction(nameof(MyZone));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await context.Games.Where(x => x.Id == id).Select(x=> new GameDetailsViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                ImageUrl = x.ImageUrl,
                Description = x.Description,
                Genre = x.Genre.Name,
                ReleasedOn = x.ReleasedOn.ToString(GameReleasedOnDateFormat),
                Publisher = x.Publisher.UserName ?? string.Empty
            }).FirstOrDefaultAsync();



            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await context.Games.Where(x => x.Id == id).Where(x=>x.IsDeleted ==false).AsNoTracking().Select(x => new GameDeleteViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Publisher = x.Publisher.UserName ?? string.Empty
            }).FirstOrDefaultAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(GameDeleteViewModel model)
        {
            Game? game = await context.Games.Where(x => x.Id == model.Id).Where(x => x.IsDeleted == false).FirstOrDefaultAsync();

            if (game != null)
            {
                game.IsDeleted = true;
                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(All));
        }


        private string? GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        private async Task<List<Genre>> GetGenres()
        {
            return await context.Genres.ToListAsync();
        }
    }
}
