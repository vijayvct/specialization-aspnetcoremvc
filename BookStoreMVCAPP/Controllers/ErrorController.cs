using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreMVCAPP.Controllers
{
	public class ErrorController : Controller
	{
		[Route("Error/{statusCode}")]
		public IActionResult ErrorHandler(int statusCode)
		{
			switch(statusCode) 
			{
				case 404:
					ViewBag.ErrorMessage = "Sorry, the resource you request could not be found";
					break;

				case 500:
					ViewBag.ErrorMessage = "Something went wrong at the server";
					break;
			}

			return View("NotFound");
		}

		[Route("Error")]
		public IActionResult Error()
		{
			var exceptionHandler= HttpContext.Features.Get<IExceptionHandlerPathFeature>();

			ViewBag.ExceptionPath=exceptionHandler.Path;
			ViewBag.ExceptionMessage = exceptionHandler.Error.Message;
			ViewBag.StackTrace = exceptionHandler.Error.StackTrace;

			return View("Error");
		}
	}
}
