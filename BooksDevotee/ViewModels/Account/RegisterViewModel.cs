using System.ComponentModel.DataAnnotations;

namespace BooksDevotee.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Pole Email jest wymwane")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Pole Hasło jest wymwane")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło")]
        [Compare(nameof(Password), ErrorMessage = "Hasła różnią się od siebie")]
        public string ConfirmPassword { get; set; }
    }
}
