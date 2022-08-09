using Microsoft.AspNetCore.Mvc;
using ContactsManagement.Models;
using ContactsManagement.Repositories;

namespace ContactsManagement.Controllers
{
	public class UserController : Controller
	{
		private readonly IUserRepository _userRepository;

		public UserController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public IActionResult Index()
		{
			var users = _userRepository.GetAll();

			return View(users);
		}

		public IActionResult Create()
		{
			return View();
		}

		public IActionResult Edit(long id)
		{
			UserModel user = _userRepository.GetUser(id);
			return View(user);
		}

		public IActionResult DeleteConfirmed(long id)
		{
			UserModel user = _userRepository.GetUser(id);
			return View(user);
		}

		[HttpPost]
		public IActionResult Create(UserModel user)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_userRepository.Create(user);
					TempData["SuccessMessage"] = "User successfully added.";
					return RedirectToAction("Index");
				}

				return View(user);
			}
			catch (System.Exception error)
			{
				TempData["ErrorMessage"] = $"Oops, we were unable to add your user, please try again. {error.Message}";
				return RedirectToAction("Index");
			}
		}

		[HttpPost]
		public IActionResult Edit(UserWithoutPasswordModel userWP)
		{
			try
			{
				UserModel user = null!;

				if (ModelState.IsValid)
				{
					user = new UserModel()
					{
						Id = userWP.Id,
						Name = userWP.Name,
						Login = userWP.Login,
						Email = userWP.Email,
						UserType = userWP.UserType
					};

					user = _userRepository.Update(user);
					TempData["SuccessMessage"] = "User successfully edited.";
					return RedirectToAction("Index");
				}

				return View(user);
			}
			catch (Exception error)
			{
				TempData["ErrorMessage"] = $"Oops, we were unable to edit your user, please try again. {error.Message}";
				return RedirectToAction("Index");
			}
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult Delete(long id)
		{

			try
			{
				bool deleted = _userRepository.Delete(id);

				if (deleted)
				{
					TempData["SuccessMessage"] = "User successfully deleted!";
				}
				else
				{
					TempData["ErrorMessage"] = $"Oops, we were unable to delete your user!";
				}
				return RedirectToAction("Index");
			}
			catch (Exception error)
			{
				TempData["ErrorMessage"] = $"Oops, we were unable to delete your user, please try again. {error.Message}";
				return RedirectToAction("Index");
			}
		}

	}

}