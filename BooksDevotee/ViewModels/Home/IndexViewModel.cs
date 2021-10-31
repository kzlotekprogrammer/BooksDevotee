using BooksDevotee.Models;
using System.Collections.Generic;

namespace BooksDevotee.ViewModels.Home
{
    public class IndexViewModel
    {
        public IEnumerable<Book> BookList { get; set; }
    }
}
