using BookStoreMVCAPP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreMVCAPP.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<IdentityUser> userManager;
		private readonly SignInManager<IdentityUser> signInManager;

		public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
			this.userManager = userManager;
			this.signInManager = signInManager;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(Register model)
		{
			if(ModelState.IsValid) 
			{
				//copy data from register to IdentityUser
				var user = new IdentityUser
				{
					UserName = model.Email,
					Email = model.Email
				};

				//store use data in AspNetUsers database table 
				var result = await userManager.CreateAsync(user,model.Password);

				//if user is successfully created, sign-in the user using 
				//SignInManager and redirect to index action of BooksController
				if(result.Succeeded) 
				{
					await signInManager.SignInAsync(user, isPersistent: false);
					return RedirectToAction("Index", "Books");
				}

				//If there are any errors, add them to the ModelState Object 
				//which will ne displayed by the validation summary tag helper
				foreach(var error in result.Errors) 
				{
					ModelState.AddModelError(string.Empty,error.Description);
				}
			}
			return View(model);
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(Login model)
		{
			if(ModelState.IsValid)
			{
				var result = await signInManager.PasswordSignInAsync(
					model.Email, model.Password, model.RememberMe, false);

				if(result.Succeeded)
				{
					return RedirectToAction("index", "books");
				}

				ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
							
			}
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();
			return RedirectToAction("Index", "Books");
		}
    }
}
