using GameZone.Data;
using GameZone.Data.Models;
using GameZone.Models;
using GameZone.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace GameZone.Services
{
    public class GameService : IGameService
    {
        private readonly GameZoneDbContext context;

        public GameService(GameZoneDbContext gameZoneDbContext)
        {
            context = gameZoneDbContext;
        }

        public async Task AddGameAsync(GameAddViewModel game, string userId)
        {
            string dateTimeString = $"{game.ReleasedOn}";

            if (!DateTime.TryParseExact(dateTimeString, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime parseDateTime))
            {
                throw new InvalidOperationException("Invalid date format.");
            }

            var gameData = new Game
            {
                Title = game.Title,
                Description = game.Description,
                ImageUrl = game.ImageUrl,
                PublisherId = userId,
                ReleasedOn = parseDateTime,
                GenreId = game.GenreId
            };

            await context.Games.AddAsync(gameData);
            await context.SaveChangesAsync();
        }

        public async Task AddGameToMyZoneAsync(string userId, Game game)
        {
            bool isAlreadyAdded = await context.GamersGames
                .AnyAsync(gg => gg.GamerId == userId && gg.GameId == game.Id);

            if (isAlreadyAdded)
            {
                return;
            }

            var gamerGame = new GamerGame
            {
                GamerId = userId,
                GameId = game.Id
            };

            await context.GamersGames.AddAsync(gamerGame);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GameAllViewModel>> GetAllAsync()
        {
            return await context.Games
                .Select(g => new GameAllViewModel
                {
                    Id = g.Id,
                    Title = g.Title,
                    ImageUrl = g.ImageUrl,
                    ReleasedOn = g.ReleasedOn.ToString("yyyy-MM-dd"),
                    Publisher = g.Publisher.UserName,
                    Genre = g.Genre.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<GameAddToMyZoneViewModel>> AllZonedAsync(string userId)
        {
            return await context.GamersGames
                .Where(gg => gg.GamerId == userId)
                .Select(gg => new GameAddToMyZoneViewModel
                {
                    Id = gg.Game.Id,
                    Title = gg.Game.Title,
                    ImageUrl = gg.Game.ImageUrl,
                    ReleasedOn = gg.Game.ReleasedOn.ToString("yyyy-MM-dd"),
                    Genre = gg.Game.Genre.Name,
                    Publisher = gg.Game.Publisher.UserName
                })
                .ToListAsync();
        }

        public async Task<GameAddViewModel> GetAddModelAsync()
        {
            var genres = await context.Genres
                .Select(g => new GenreViewModel
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToListAsync();

            var model = new GameAddViewModel
            {
                Genres = genres
            };

            return model;
        }

        public async Task<Game> GetGameByIdAsync(int id)
        {
            return await context.Games
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<GameEditViewModel> GetEditModelAsync(int id)
        {
            var genres = await context.Genres
                .Select(g => new GenreViewModel
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToListAsync();

            var game = await context.Games
                .Where(g => g.Id == id)
                .Select(g => new GameEditViewModel
                {
                    Title = g.Title,
                    Description = g.Description,
                    ImageUrl = g.ImageUrl,
                    ReleasedOn = g.ReleasedOn.ToString("yyyy-MM-dd"),
                    GenreId = g.GenreId,
                    Genres = genres,
                    PublisherId = g.PublisherId
                })
                .FirstOrDefaultAsync();

            return game;
        }

        public async Task EditGameAsync(GameEditViewModel model, Game game)
        {
            string dateTimeString = $"{model.ReleasedOn}";

            if (!DateTime.TryParseExact(dateTimeString, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                               DateTimeStyles.None, out DateTime parseDateTime))
            {
                throw new InvalidOperationException("Invalid date format.");
            }

            game.Title = model.Title;
            game.Description = model.Description;
            game.ImageUrl = model.ImageUrl;
            game.ReleasedOn = parseDateTime;
            game.GenreId = model.GenreId;

            await context.SaveChangesAsync();
        }

        public async Task StrikeOutAsync(string userId, Game game)
        {
            var gamerGame = await context.GamersGames
                .FirstOrDefaultAsync(gg => gg.GamerId == userId && gg.GameId == game.Id);

            if (gamerGame != null)
            {
                context.GamersGames.Remove(gamerGame);
                await context.SaveChangesAsync();
            }
        }

        public async Task<GameDetailsViewModel> GetGameDetails(int id)
        {
            GameDetailsViewModel game = await context.Games
                .Where(g => g.Id == id)
                .Select(g => new GameDetailsViewModel
                {
                    Id = g.Id,
                    Title = g.Title,
                    Description = g.Description,
                    ImageUrl = g.ImageUrl,
                    ReleasedOn = g.ReleasedOn.ToString("yyyy-MM-dd"),
                    Genre = g.Genre.Name,
                    Publisher = g.Publisher.UserName
                })
                .FirstOrDefaultAsync();

            return game;
        }

        public Task DeleteGameAsync(Game game)
        {
            context.Games.Remove(game);
            return context.SaveChangesAsync();
        }
    }
}
