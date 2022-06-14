using ContactsManagement.Models;
using ContactsManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ContactsManagement.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public IActionResult Index()
        {
            var contacts = _contactRepository.GetAll();

            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(long id)
        {
            ContactModel contact = _contactRepository.GetContact(id);
            return View(contact);
        }

        public IActionResult ConfirmDelete(long id)
        {
            ContactModel contact = _contactRepository.GetContact(id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.Create(contact);
                    TempData["SuccessMessage"] = "Contact successfully added.";
                    return RedirectToAction("Index");
                }

                return View(contact);
            }
            catch (System.Exception error)
            {
                TempData["ErrorMessage"] = $"Oops, we were unable to add your contact, please try again. {error.Message}";
                return RedirectToAction("Index");   
            }    
        }

        [HttpPost]
        public IActionResult Edit(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.Update(contact);
                    TempData["SuccessMessage"] = "Contact successfully edited.";
                    return RedirectToAction("Index");
                }
                return View(contact);
            }
            catch (System.Exception error)
            {
                TempData["ErrorMessage"] = $"Oops, we were unable to edit your contact, please try again. {error.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Delete(long id)
        {
            try
            {
                bool deleted = _contactRepository.Delete(id);

                if (deleted)
                {
                    TempData["SuccessMessage"] = "Contact successfully deleted!";
                }
                else
                {
                    TempData["ErrorMessage"] = $"Oops, we were unable to delete your contact!";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception error)
            {
                TempData["ErrorMessage"] = $"Oops, we were unable to delete your contact, please try again. {error.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
