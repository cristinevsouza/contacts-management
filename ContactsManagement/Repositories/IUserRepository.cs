
using ContactsManagement.Models;

namespace ContactsManagement.Repositories
{
	public interface IUserRepository
	{
        List<UserModel> GetAll();
        UserModel GetUser(long id);
        UserModel FindByLogin(string login);
        UserModel Create(UserModel user);
        UserModel Update(UserModel user);
        bool Delete(long id);
    }
}

