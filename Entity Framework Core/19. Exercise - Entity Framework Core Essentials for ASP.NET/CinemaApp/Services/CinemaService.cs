using CinemaApp.Contracts;
using CinemaApp.Data.Common;
using CinemaApp.Data.Models;
using CinemaApp.Models;

namespace CinemaApp.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly IRepository repo;

        public CinemaService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task AddCinemaAsync(CinemaModel model)
        {
            if (repo.AllReadonly<Cinema>().Any(c => c.Name == model.Name))
            {
                throw new ArgumentException("Cinema already exists");
            }

            Cinema cinema = new Cinema()
            {
                Address = model.Address,
                Name = model.Name
            };

            await repo.AddAsync(cinema);
            await repo.SaveChangesAsync();
        }
    }
}
