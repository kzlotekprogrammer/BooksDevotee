using BooksDevotee.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace BooksDevotee.Repositories
{
    public class SQLBookRepository : IBookRepository
    {
        private readonly AppDbContext context;

        public SQLBookRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Book GetBook(int id)
        {
            return context.Books
                .Where(b => b.BookId == id && b.Status == BookStatus.Available)
                .Include(b => b.Image)
                .Include(b => b.BookCategories)
                .ThenInclude(bc => bc.Category)
                .FirstOrDefault();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return context.Books
                .Where(b => b.Status == BookStatus.Available)
                .Include(b => b.Image)
                .Include(b => b.BookCategories)
                .ThenInclude(bc => bc.Category);
        }

        public Book Add(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
            return book;
        }
        
        public Book Update(Book bookChanges)
        {
            EntityEntry<Book> book = context.Books.Attach(bookChanges);
            book.State = EntityState.Modified;
            context.SaveChanges();
            return bookChanges;
        }

        public Book Delete(int id)
        {
            Book book = context.Books.Find(id);
            if (book != null)
            {
                book.Status = BookStatus.NotAvailable;
                Update(book);
            }
            return book;
        }
    }
}
