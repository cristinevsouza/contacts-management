using ContactsManagement.Models;
using ContactsManagement.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsManagement.Controllers
{
	public class LoginController : Controller
	{
		private readonly IUserRepository _userRepository;

		public LoginController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Enter(LoginModel loginModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					UserModel user = _userRepository.FindByLogin(loginModel.Login!);

					if (user != null)
					{
						if (user.PasswordValidator(loginModel.Password!))
						{
							return RedirectToAction("Index", "Home");
						}

						TempData["ErrorMessage"] = $"Invalid user password, try again.";
					}

					TempData["ErrorMessage"] = $"Invalid username or password. Please, try again.";
				}

				return View("Index");
			}
			catch (Exception error)
			{
				TempData["ErrorMessage"] = $"Oops, we were unable to realize your login, please try again. {error.Message}";
				return RedirectToAction("Index");
			}
		}
	}
}
