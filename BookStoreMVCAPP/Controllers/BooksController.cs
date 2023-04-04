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
            if (ModelState.IsValid)
            {
                repository.Create(book);

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Details(int? id)
        {
            var book = repository.Get(id);

            if (book == null)
            {
                Response.StatusCode = 404;
                return View("BookNotFound", id);
            }

            return View(book);
        }

        public IActionResult GetData()
        {
            throw new Exception("This is some error message");
        }

        //[Route("Books/Demo")]
        //public IActionResult GetServerError()
        //{
        //    //return StatusCode(StatusCodes.Status500InternalServerError, new {Message="Hello"});
        //    ;
        //}

        [HttpGet]
        public IActionResult Delete(int? id) 
        {
            var book = repository.Get(id);

            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = repository.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
