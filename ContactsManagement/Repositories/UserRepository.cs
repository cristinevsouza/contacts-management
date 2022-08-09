using ContactsManagement.Data;
using ContactsManagement.Models;

namespace ContactsManagement.Repositories
{

	public class UserRepository : IUserRepository
	{
		private readonly ContactsDBContext _context;

		public UserRepository(ContactsDBContext context)
		{
			_context = context;
		}

		public List<UserModel> GetAll()
		{
			return _context.Users.ToList();
		}

		public UserModel GetUser(long id)
		{
			return _context.Users.FirstOrDefault(x => x.Id == id)!;
		}

		public UserModel FindByLogin(string login)
		{
			return _context.Users.FirstOrDefault(x => x.Login!.ToUpper() == login.ToUpper())!;

		}

		public UserModel Create(UserModel user)
		{
			user.CreatedAt = DateTime.Now;
			_context.Users.Add(user);
			_context.SaveChanges();
			return user;
		}

		public UserModel Update(UserModel user)
		{
			UserModel userDB = GetUser(user.Id);
			if (userDB == null) throw new Exception("There was a error while updating!");
			userDB.Name = user.Name;
			userDB.Email = user.Email;
			userDB.Login = user.Login;
			userDB.UserType = user.UserType;
			userDB.UpdatedAt = DateTime.Now;
			_context.Users.Update(userDB);
			_context.SaveChanges();
			return userDB;
		}

		public bool Delete(long id)
		{
			UserModel UserDB = GetUser(id);
			if (UserDB == null) throw new Exception("There was an error deleting the user");
			_context.Users.Remove(UserDB);
			_context.SaveChanges();
			return true;
		}
	}
}