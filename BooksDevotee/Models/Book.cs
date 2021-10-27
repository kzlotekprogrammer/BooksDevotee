using System;
using System.Collections.Generic;

namespace BooksDevotee.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? ImageId { get; set; }
        public int? Pages { get; set; }
        public string Dimensions { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Publisher { get; set; }
        public string CoverType { get; set; }

        public Image Image { get; set; }
        public virtual ICollection<BookCategory> BookCategories { get; set; }
        public ICollection<BasketBook> BasketBooks { get; set; }
    }
}
