using GameZone.Data;
using GameZone.Data.Models;
using GameZone.Models;
using GameZone.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;

namespace GameZone.Controllers
{
    public class GameController : BaseController
    {
        private readonly IGameService service;

        public GameController(IGameService gameService)
        {
            service = gameService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            GameAddViewModel model = await service.GetAddModelAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GameAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userId = GetUserId();
            await service.AddGameAsync(model, userId);
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> All()
        {
            var model = await service.GetAllAsync();
            return View(model);
        }

        public async Task<IActionResult> AddToMyZone(int id)
        {
            Game game = await service.GetGameByIdAsync(id);

            if(game == null)
            {
                return BadRequest();
            }            
            var userId = GetUserId();

            await service.AddGameToMyZoneAsync(userId, game);
            return RedirectToAction(nameof(MyZone));
        }

        public async Task<IActionResult> MyZone()
        {
            var userId = GetUserId();
            var models = await service.AllZonedAsync(userId);

            if (!models.Any())
            {
                return RedirectToAction(nameof(All));
            }

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            GameEditViewModel model = await service.GetEditModelAsync(id);

            if (model == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (model.PublisherId != userId)
            {
                return Unauthorized();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, GameEditViewModel model)
        {
            var game = await service.GetGameByIdAsync(id);

            if (game == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (game.PublisherId != userId)
            {
                return Unauthorized();
            }

            await service.EditGameAsync(model, game);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> StrikeOut(int id)
        {
            var game = await service.GetGameByIdAsync(id);

            if(game == null)
            {
                return BadRequest();
            }

            var userId = GetUserId();

            await service.StrikeOutAsync(userId, game);

            return RedirectToAction(nameof(MyZone));
        }

        public async Task<IActionResult> Details(int id)
        {
            GameDetailsViewModel game = await service.GetGameDetails(id);

            if (game == null)
            {
                return BadRequest();
            }

            return View(game);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var game = await service.GetGameByIdAsync(id);

            if (game == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (game.PublisherId != userId)
            {
                return Unauthorized();
            }

            GameDeleteViewModel model = new GameDeleteViewModel
            {
                Id = game.Id,
                Title = game.Title
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, GameDeleteViewModel model)
        {
            var game = await service.GetGameByIdAsync(id);

            if (game == null)
            {
                return BadRequest();
            }

            await service.DeleteGameAsync(game);

            return RedirectToAction(nameof(All));
        }
    }
}
