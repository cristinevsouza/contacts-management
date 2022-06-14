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
            _contactRepository.Create(contact);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(ContactModel contact)
        {
            _contactRepository.Update(contact);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(long id)
        {
            ContactModel contact = _contactRepository.GetContact(id);
            _contactRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
