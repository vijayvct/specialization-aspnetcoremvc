using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace BookStoreMVCAPP.Controllers
{
    public class HomeController : Controller
    {
        //http://localhost/home/index
        public IActionResult Index()
        {
            ViewBag.Title = "Home Index Page";

            ViewData["Message"] = "Welcome to Asp.Net Core MVC Application";

            var cities = 
                new List<String> { "Mumbai", "Chennai", "Pune", "Delhi", "Bengaluru", "Hyderabad" };

            ViewData["cities"] = cities;

            ViewBag.Cities = cities;

            TempData["name"] = "Vijay Vishwakarma";

            return View();
        }

        //http://localhost/home/about -> info.cshtml
        public IActionResult About() 
        {

            return View("Info");
        }

        public string GetString()
        {
            return "This is a Simple String Message";
        }

        public JsonResult GetData()
        {
            return Json(new { id = 101, name = "Malcolm" });
        }
    }
}
