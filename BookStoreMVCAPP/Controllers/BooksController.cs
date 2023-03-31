using Microsoft.AspNetCore.Mvc;
using BookStoreMVCAPP.Services;
using BookStoreMVCAPP.Models;

namespace BookStoreMVCAPP.Controllers
{
    public class BooksController : Controller
    {
        private IBookRepository repository;

        public BooksController(IBookRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View(repository.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            repository.Create(book);

            return RedirectToAction("Index");
        }
    }
}
