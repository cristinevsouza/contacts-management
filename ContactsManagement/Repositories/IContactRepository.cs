using ContactsManagement.Models;

namespace ContactsManagement.Repositories
{
    public interface IContactRepository
    {
        ContactModel? GetContact(long id); 

        List<ContactModel> GetAll();

        ContactModel Create(ContactModel contact);

        ContactModel Update(ContactModel contact);

        bool Delete(long id);
    }
}
