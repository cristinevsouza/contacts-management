using Microsoft.AspNetCore.Mvc;

namespace ContactsManagement.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult ConfirmDelete()
        {
            return View();
        }
    }
}
