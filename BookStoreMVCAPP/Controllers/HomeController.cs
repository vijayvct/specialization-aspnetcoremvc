using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace BookStoreMVCAPP.Controllers
{
    public class HomeController : Controller
    {
        //http://localhost/home/index
        public IActionResult Index()
        {
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
