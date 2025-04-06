using SeminarHub.Data.Models;
using SeminarHub.Models;

namespace SeminarHub.Contracts
{
    public interface ISeminarService
    {
        Task AddSeminarAsync(AddSeminarViewModel seminar, string userId);
        Task AddSeminarToJoinedAsync(string userId, JoinSeminarViewModel seminar);

        Task<AddSeminarViewModel> GetAddSeminarModelAsync();

        Task<IEnumerable<AllSeminarViewModel>> GetAllSeminarsAsync();

        Task<IEnumerable<JoinedSeminarViewModel>> GetJoinedSeminarsAsync(string iserId);

        Task<JoinSeminarViewModel?> GetSeminarByIdAsync(int id);

        Task LeaveSeminar(string userId, JoinSeminarViewModel seminar);

        Task<SeminarDetailsViewModel> GetSeminarDetails(int id);

        Task<AddSeminarViewModel> GetSeminarToEdit(int id);
        Task<Seminar> FindAsync(int id);

        Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync();
        Task EditSeminarAsync(AddSeminarViewModel model, Seminar seminarToEdit);
        Task DeleteSeminarAsync(Seminar seminar);
    }
}
