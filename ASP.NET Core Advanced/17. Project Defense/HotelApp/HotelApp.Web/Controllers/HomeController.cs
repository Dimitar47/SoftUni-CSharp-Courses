using System.Diagnostics;  //System namespaces

using Microsoft.AspNetCore.Mvc; //Third-party namespaces

using HotelApp.Web.ViewModels; // Internal project namespaces

namespace HotelApp.Web.Controllers
{
    public class HomeController : Controller
    {
        

        public HomeController()
        {
           
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Home page";
            ViewData["Message"] = "Welcome to the Hotel Web App!";
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel() { RequestId=Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
