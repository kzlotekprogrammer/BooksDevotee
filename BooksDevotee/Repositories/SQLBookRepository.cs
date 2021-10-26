using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;

namespace BooksDevotee.Models
{
    public class SQLBookRepository : IBookRepository
    {
        private readonly AppDbContext context;

        public SQLBookRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Book Add(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
            return book;
        }

        public Book Delete(int id)
        {
            Book book = context.Books.Find(id);
            if (book != null)
            {
                context.Books.Remove(book);
                context.SaveChanges();
            }
            return book;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return context.Books;
        }

        public Book GetBook(int id)
        {
            return context.Books.Find(id);
        }

        public Book Update(Book bookChanges)
        {
            EntityEntry<Book> book = context.Books.Attach(bookChanges);
            book.State = EntityState.Modified;
            context.SaveChanges();
            return bookChanges;
        }
    }
}
