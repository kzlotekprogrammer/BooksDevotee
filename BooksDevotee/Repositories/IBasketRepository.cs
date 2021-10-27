using BooksDevotee.Models;
using System.Collections.Generic;

namespace BooksDevotee.Repositories
{
    public interface IBasketRepository
    {
        Basket GetBasket(int id);
        IEnumerable<Basket> GetAllBaskets();
        Basket Add(Basket basket);
        Basket Update(Basket basketChanges);
        Basket Delete(int id);
    }
}
