using System.ComponentModel.DataAnnotations;

namespace ContactsManagement.Models
{
	public class LoginModel
	{
		[Required(ErrorMessage = "Enter your login")]
		public string? Login { get; set; }

		[Required(ErrorMessage = "Enter your password")]
		public string? Password { get; set; }
	}
}
