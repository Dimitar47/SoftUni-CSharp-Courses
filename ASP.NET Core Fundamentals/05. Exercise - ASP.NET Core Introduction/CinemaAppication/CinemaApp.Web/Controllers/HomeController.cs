

namespace CinemaApp.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;

    using CinemaApp.Web.ViewModels;

    public class HomeController : Controller
    {


        public HomeController()
        {
           
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Home Page";
            ViewData["Message"] = "Welcome to the Cinema Web App!";
            return View();
        }

     
    }
}
