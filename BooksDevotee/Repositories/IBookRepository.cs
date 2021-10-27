using BooksDevotee.Models;
using System.Collections.Generic;

namespace BooksDevotee.Repositories
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
