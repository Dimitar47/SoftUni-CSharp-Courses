using Microsoft.AspNetCore.Mvc;
using CinemaWebApp.Models; //Include the Movie model
using System.Collections.Generic;
using CinemaWebApp.Models.Data;
using CinemaWebApp.ViewModels; //For handling lists

namespace CinemaWebApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppDbContext _context;

        //Inject the AppDbContext using constructor dependency injection
        public MovieController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var movies = _context.Movies.ToList(); // Retrieve all movies from the database
            return View(movies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new MovieViewModel());
        }

        [HttpPost]
        public IActionResult Create(MovieViewModel viewModel)
        {
            //Validate the input data using ModelState
            if (ModelState.IsValid)
            {
                //Map the view model to the Movie entity
                var movie = new Movie
                {
                    Title = viewModel.Title,
                    Genre = viewModel.Genre,
                    ReleaseDate = viewModel.ReleaseDate,
                    Director = viewModel.Director,
                    Duration = viewModel.Duration,
                    Description = viewModel.Description,
                    ImageUrl = viewModel.ImageUrl
                };

                _context.Movies.Add(movie);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var movie = _context.Movies.Find(id); // Find the movie by id

            if(movie == null)
            {
                return NotFound(); // Return 404 Not Found
            }

            return View(movie);
        }

        [HttpGet]
        public IActionResult AddToProgram(int movieId)
        {
            //Find the movie by its id
            var movie = _context.Movies.Find(movieId);

            //If the movie is not found, redirect to the Index action
            if (movie == null)
            {
                return RedirectToAction("Index");
            }

            //Retrieve all cinemas from the database
            var cinemas = _context.Cinemas.ToList();


            //Create a view model to pass the movie and cinema data to the view
            AddMovieToCinemaProgramViewModel viewModel = new AddMovieToCinemaProgramViewModel
            {
                MovieId = movie.Id,         //Set the movie id
                MovieTitle = movie.Title,   //Set the movie title
                Cinemas = cinemas.Select(c => new CinemaCheckBoxItem
                {
                    Id = c.Id,              //Set the cinema id
                    Name = c.Name,          //Set the cinema name
                    IsSelected = false      //Set the default selection status
                }).ToList()
            };

            //Pass the view model to the view
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddToProgram(AddMovieToCinemaProgramViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var existingAssignments = _context.CinemasMovies
                .Where(cm => cm.MovieId == model.MovieId)
                .ToList();
            _context.RemoveRange(existingAssignments);

            foreach(var cinema in model.Cinemas)
            {
                if (cinema.IsSelected)
                {
                    var cinemaMovie = new CinemaMovie
                    {
                        CinemaId = cinema.Id,
                        MovieId = model.MovieId
                    };

                    _context.CinemasMovies.Add(cinemaMovie);
                }
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
