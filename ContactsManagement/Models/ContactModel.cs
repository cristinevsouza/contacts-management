using System.ComponentModel.DataAnnotations;

namespace ContactsManagement.Models
{
    public class ContactModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Required field")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Required field")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Phone(ErrorMessage = "Inavalid phone number")]
        public string? PhoneNumber { get; set; }
    }
}
