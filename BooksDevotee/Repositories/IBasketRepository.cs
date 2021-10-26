using System.Collections.Generic;

namespace BooksDevotee.Models
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
