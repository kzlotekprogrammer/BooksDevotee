using System.ComponentModel.DataAnnotations;

namespace BooksDevotee.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Display(Name = "Imię")]
        [Required(ErrorMessage = "Pole imię jest wymagane")]
        public string FirstName { get; set; }

        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "Pole nazwisko jest wymagane")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Pole Email jest wymagane")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Pole Hasło jest wymagane")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło")]
        [Compare(nameof(Password), ErrorMessage = "Hasła różnią się od siebie")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Numer telefonu")]
        [Required(ErrorMessage = "Pole numer telefonu jest wymagane")]
        [RegularExpression(@"^[0-9]{9}$", ErrorMessage = "Niepoprawny numer telefonu")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Firma")]
        public string Buisness { get; set; }

        [Display(Name = "Kraj")]
        [Required(ErrorMessage = "Pole kraj jest wymagane")]
        public string Country { get; set; }

        [Display(Name = "Miasto")]
        [Required(ErrorMessage = "Pole miasto jest wymagane")]
        public string City { get; set; }

        [Display(Name = "Kod pocztowy")]
        [Required(ErrorMessage = "Pole kod pocztowy jest wymagane")]
        [RegularExpression(@"^[0-9]{2}-[0-9]{3}$", ErrorMessage = "Niepoprawny kod pocztowy")]
        public string PostalCode { get; set; }

        [Display(Name = "Ulica i numer domu")]
        [Required(ErrorMessage = "Pole ulica i numer domu jest wymagane")]
        public string StreetAndNumber { get; set; }
    }
}
