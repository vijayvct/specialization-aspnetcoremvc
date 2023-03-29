using Microsoft.AspNetCore.Mvc;

namespace BookStoreMVCAPP.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
