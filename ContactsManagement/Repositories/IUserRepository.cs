
using ContactsManagement.Models;

namespace ContactsManagement.Repositories
{
	public interface IUserRepository
	{
        List<UserModel> GetAll();
        UserModel GetUser(long id);
        UserModel Create(UserModel user);
        UserModel Update(UserModel user);
        bool Delete(long id);
    }
}

