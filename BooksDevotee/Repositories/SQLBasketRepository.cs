using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;

namespace BooksDevotee.Models
{
    public class SQLBasketRepository : IBasketRepository
    {
        private readonly AppDbContext context;

        public SQLBasketRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Basket Add(Basket basket)
        {
            context.Baskets.Add(basket);
            context.SaveChanges();
            return basket;
        }

        public Basket Delete(int id)
        {
            Basket basket = context.Baskets.Find(id);
            if (basket != null)
            {
                context.Baskets.Remove(basket);
                context.SaveChanges();
            }
            return basket;
        }

        public IEnumerable<Basket> GetAllBaskets()
        {
            return context.Baskets;
        }

        public Basket GetBasket(int id)
        {
            return context.Baskets.Find(id);
        }

        public Basket Update(Basket basketChanges)
        {
            EntityEntry<Basket> basket = context.Baskets.Attach(basketChanges);
            basket.State = EntityState.Modified;
            context.SaveChanges();
            return basketChanges;
        }
    }
}
