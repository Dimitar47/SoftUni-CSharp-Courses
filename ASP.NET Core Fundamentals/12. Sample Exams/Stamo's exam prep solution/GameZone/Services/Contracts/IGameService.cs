using GameZone.Data.Models;
using GameZone.Models;

namespace GameZone.Services.Contracts
{
    public interface IGameService
    {
        Task AddGameAsync(GameAddViewModel game, string userId);

        Task AddGameToMyZoneAsync(string userId, Game game);

        Task<IEnumerable<GameAllViewModel>> GetAllAsync();

        Task<IEnumerable<GameAddToMyZoneViewModel>> AllZonedAsync(string userId);
        Task<GameAddViewModel> GetAddModelAsync();
        Task<Game> GetGameByIdAsync(int id);
        Task<GameEditViewModel> GetEditModelAsync(int id);
        Task EditGameAsync(GameEditViewModel model, Game game);
        Task StrikeOutAsync(string userId, Game game);
        Task<GameDetailsViewModel> GetGameDetails(int id);
        Task DeleteGameAsync(Game game);
    }
}
