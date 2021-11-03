using System.ComponentModel.DataAnnotations;

namespace BooksDevotee.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Pole email jest wymagane")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Pole hasło jest wymagane")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Pamiętaj hasło")]
        public bool RememberMe { get; set; }
    }
}
