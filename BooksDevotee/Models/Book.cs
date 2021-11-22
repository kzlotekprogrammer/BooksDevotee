using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksDevotee.Models
{
    public enum BookStatus
    {
        Available = 0,
        NotAvailable = 1
    }

    public class Book
    {
        public int BookId { get; set; }

        [Display(Name = "Autor")]
        [Required]
        public string Author { get; set; }

        [Display(Name = "Tytuł")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Display(Name = "Cena")]
        [Required]
        public decimal Price { get; set; }

        public int? ImageId { get; set; }

        [Display(Name = "Ilość stron")]
        public int? Pages { get; set; }

        [Display(Name = "Wymiary")]
        public string Dimensions { get; set; }

        [Display(Name = "Data wydania")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Wydawca")]
        public string Publisher { get; set; }

        [Display(Name = "Typ okładki")]        
        public string CoverType { get; set; }
        public BookStatus Status { get; set; }

        public Image Image { get; set; }
        public virtual ICollection<BookCategory> BookCategories { get; set; }
        public ICollection<BasketBook> BasketBooks { get; set; }
    }
}
