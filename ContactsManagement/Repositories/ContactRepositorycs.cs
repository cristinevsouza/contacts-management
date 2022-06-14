using ContactsManagement.Data;
using ContactsManagement.Models;
using ContactsManagement.Repositories;

namespace ContactsManagement.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactsDBContext _contactDBContext;

        public ContactRepository(ContactsDBContext contactDBContext)
        {
            _contactDBContext = contactDBContext;
        }

        public ContactModel GetContact(long id)
        {
            return _contactDBContext.Contacts.FirstOrDefault(x => x.Id == id);  
        }

        public List<ContactModel> GetAll()
        {
            return _contactDBContext.Contacts.ToList();
        }

        public ContactModel Create(ContactModel contact)
        {
            _contactDBContext.Contacts.Add(contact);
            _contactDBContext.SaveChanges();
            return contact;
        }

        public ContactModel Update(ContactModel contact)
        {
            ContactModel contactDB = GetContact(contact.Id);

            if (contactDB == null) throw new System.Exception("There was an error editing the contact");

            contactDB.Name = contact.Name;
            contactDB.Email = contact.Email;
            contactDB.PhoneNumber = contact.PhoneNumber;

            _contactDBContext.Contacts.Update(contactDB);
            _contactDBContext.SaveChanges();

            return contactDB;
        }

        public bool Delete(long id)
        {
            ContactModel contactDB = GetContact(id);

            if (contactDB == null) throw new System.Exception("There was an error deleting the contact");

            _contactDBContext.Contacts.Remove(contactDB);
            _contactDBContext.SaveChanges();

            return true;
        }
    }
}
