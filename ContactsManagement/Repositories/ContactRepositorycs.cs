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

        public ContactModel Edit(ContactModel contact)
        {
            throw new NotImplementedException();
        }
    }
}
