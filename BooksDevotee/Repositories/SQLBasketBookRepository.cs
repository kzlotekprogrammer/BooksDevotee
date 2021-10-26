using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;

namespace BooksDevotee.Models
{
    public class SQLBasketBookRepository
    {
        private readonly AppDbContext context;

        public SQLBasketBookRepository(AppDbContext context)
        {
            this.context = context;
        }

        public BasketBook Add(BasketBook basketBook)
        {
            context.BasketBooks.Add(basketBook);
            context.SaveChanges();
            return basketBook;
        }

        public BasketBook Delete(int id)
        {
            BasketBook basketBook = context.BasketBooks.Find(id);
            if (basketBook != null)
            {
                context.BasketBooks.Remove(basketBook);
                context.SaveChanges();
            }
            return basketBook;
        }

        public IEnumerable<BasketBook> GetAllBasketBooks()
        {
            return context.BasketBooks;
        }

        public BasketBook GetBasketBook(int id)
        {
            return context.BasketBooks.Find(id);
        }

        public BasketBook Update(BasketBook basketBookChanges)
        {
            EntityEntry<BasketBook> book = context.BasketBooks.Attach(basketBookChanges);
            book.State = EntityState.Modified;
            context.SaveChanges();
            return basketBookChanges;
        }
    }
}
