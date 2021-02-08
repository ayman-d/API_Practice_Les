using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Commander.DTOs.ApplicationUserDTOs
{
    public class UserRegisterDTO
    {
        [Required(ErrorMessage = "User name is required")]
        [StringLength(20, ErrorMessage = "User name cannot be more than 20 characters long")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "The email entered is not in the correct format")]
        public string Email { get; set; }
        [PasswordPropertyText]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("Password", ErrorMessage = "Password and confirm password do not match, please try again")]
        public string ConfirmPassword { get; set; }
    }
}