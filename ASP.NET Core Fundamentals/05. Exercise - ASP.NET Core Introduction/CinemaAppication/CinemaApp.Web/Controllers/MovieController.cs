using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CinemaApp.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly CinemaDbContext dbContext;
        public MovieController(CinemaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Movie> allMovies = this.dbContext.Movies.ToList();


            return View(allMovies);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(AddMovieInputModel inputModel)
        {
           

           
            bool isRealeaseDateValid = DateTime.TryParseExact(inputModel.ReleaseDate, "dd/MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);
            if (!isRealeaseDateValid)
            {
                this.ModelState.AddModelError(nameof(inputModel.ReleaseDate), 
                    "The Release Date must be in the following format: dd/MM/yyyy");
                return this.View(inputModel);
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            Movie movie = new Movie()
            {
                Title = inputModel.Title,
                Genre = inputModel.Genre,
                ReleaseDate = releaseDate,
                Director = inputModel.Director,
                Duration = inputModel.Duration,
                Description = inputModel.Description
            };
            this.dbContext.Movies.Add(movie);
            this.dbContext.SaveChanges();

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            bool isIdValid = Guid.TryParse(id, out Guid guidId);
            if (!isIdValid)
            {
               return this.RedirectToAction(nameof(Index));
            }
            Movie? movie = this.dbContext.Movies.FirstOrDefault(m => m.Id == guidId);
            if (movie == null)
            {
               return this.RedirectToAction(nameof(Index));
            }

            return View(movie);
        }
    }
}
