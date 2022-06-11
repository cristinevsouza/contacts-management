using ContactsManagement.Models;

namespace ContactsManagement.Repositories
{
    public interface IContactRepository
    {
        List<ContactModel> GetAll();

        ContactModel Create(ContactModel contact);

        ContactModel Edit(ContactModel contact);

    }
}
