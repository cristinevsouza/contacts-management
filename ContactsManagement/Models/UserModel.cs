using ContactsManagement.Enums;
using System.ComponentModel.DataAnnotations;

namespace ContactsManagement.Models
{
    public class UserModel
    {
        public long Id { get; set; }

		[Required(ErrorMessage = "Enter your name")]
		public string? Name { get; set; }

		[Required(ErrorMessage = "Enter your login")]
		public string? Login { get; set; }

		[Required(ErrorMessage = "Enter your email")]
		[EmailAddress(ErrorMessage = "E-mail informed is invalid!")]
		public string? Email { get; set; }

		[Required(ErrorMessage = "Inform your user type")]
		public UserType? UserType { get; set; }

		[Required(ErrorMessage = "Enter your password")]
		public string? Password { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }


		
	}
}