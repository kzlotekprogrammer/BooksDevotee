using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksDevotee.Models
{
    public class BookCategory
    {
        public int CategoryId { get; set; }
        public int BookId { get; set; }

        public Category Category { get; set; }
        public Book Book { get; set; }
    }
}
