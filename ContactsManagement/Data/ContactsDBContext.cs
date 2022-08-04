using ContactsManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsManagement.Data
{
	public class ContactsDBContext : DbContext
	{
		public ContactsDBContext(DbContextOptions<ContactsDBContext> options) : base(options)
		{

		}

		public DbSet<ContactModel> Contacts => Set<ContactModel>();

		public DbSet<UserModel> Users => Set<UserModel>();
	}
}
