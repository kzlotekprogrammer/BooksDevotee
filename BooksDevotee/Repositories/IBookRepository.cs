using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksDevotee.Models
{
    public interface IBookRepository
    {
        Book GetBook(int id);
        IEnumerable<Book> GetAllBooks();
        Book Add(Book book);
        Book Update(Book bookChanges);
        Book Delete(int id);
    }
}
