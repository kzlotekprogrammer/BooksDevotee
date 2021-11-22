using BooksDevotee.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace BooksDevotee.Repositories
{
    public class SQLBasketRepository : IBasketRepository
    {
        private readonly AppDbContext context;

        public SQLBasketRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Basket AddBasket(Basket basket)
        {
            context.Baskets.Add(basket);
            context.SaveChanges();
            return basket;
        }

        public Basket GetActiveBasketByUserName(string userId)
        {
            return context.Baskets
                .Where(b => b.ApplicationUserId == userId && b.Status == BasketStatus.Active)
                .FirstOrDefault();
        }

        public Basket GetBasketDataById(int id)
        {
            return context.Baskets
                .Where(b => b.BasketId == id)
                .Include(b => b.ApplicationUser)
                .Include(b => b.BasketBooks)
                .ThenInclude(b => b.Book)
                .ThenInclude(b => b.Image)
                .FirstOrDefault();
        }

        public Basket GetBasketById(int id)
        {
            return context.Baskets
                .Where(b => b.BasketId == id)
                .FirstOrDefault();
        }

        public Basket UpdateBasket(Basket basketChanges)
        {
            EntityEntry<Basket> basket = context.Baskets.Attach(basketChanges);
            basket.State = EntityState.Modified;
            context.SaveChanges();
            return basketChanges;
        }

        public List<Basket> GetAllOrders()
        {
            List<BasketStatus> allowedStatuses = new List<BasketStatus>()
            {
                BasketStatus.Canceled,
                BasketStatus.Paid,
                BasketStatus.Prepared,
                BasketStatus.Sent
            };

            return context.Baskets
                .Where(b => allowedStatuses.Contains(b.Status))
                .Include(b => b.ApplicationUser)
                .Include(b => b.BasketBooks)
                .ThenInclude(bb => bb.Book)
                .ToList();
        }

        public BasketBook AddBasketBook(BasketBook basketBook)
        {
            context.BasketBooks.Add(basketBook);
            context.SaveChanges();
            return basketBook;
        }

        public BasketBook GetBasketBook(int basketId, int bookId)
        {
            return context.BasketBooks
                .Where(bb => bb.BasketId == basketId && bb.BookId == bookId)
                .FirstOrDefault();
        }

        public BasketBook UpdateBasketBook(BasketBook basketBookChanges)
        {
            EntityEntry<BasketBook> basket = context.BasketBooks.Attach(basketBookChanges);
            basket.State = EntityState.Modified;
            context.SaveChanges();
            return basketBookChanges;
        }

        public BasketBook DeleteBasketBook(int basketId, int bookId)
        {
            BasketBook basketBook = context.BasketBooks
                .Where(bb => bb.BasketId == basketId && bb.BookId == bookId)
                .FirstOrDefault();

            if (basketBook != null)
            {
                context.BasketBooks.Remove(basketBook);
                context.SaveChanges();
            }
            return basketBook;
        }
    }
}
