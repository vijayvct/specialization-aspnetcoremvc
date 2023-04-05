using BookStoreMVCAPP.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreMVCAPP.ViewComponents
{
	public class LanguageCountViewComponent:ViewComponent
	{
		private readonly IBookRepository repository;

		public LanguageCountViewComponent(IBookRepository repository)
        {
			this.repository = repository;
		}

		public IViewComponentResult Invoke()
		{
			var result = repository.BookCountByLanguage();

			return View(result);
		}
    }
}
