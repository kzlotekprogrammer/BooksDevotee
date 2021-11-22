using BooksDevotee.Models;
using System.Collections.Generic;

namespace BooksDevotee.Repositories
{
    public interface IBasketRepository
    {
        Basket AddBasket(Basket basket);
        Basket GetActiveBasketByUserName(string userName);
        Basket GetBasketDataById(int id);
        Basket GetBasketById(int id);
        Basket UpdateBasket(Basket basket);
        List<Basket> GetAllOrders();

        BasketBook AddBasketBook(BasketBook basketBook);
        BasketBook GetBasketBook(int basketId, int bookId);
        BasketBook UpdateBasketBook(BasketBook basketBook);
        BasketBook DeleteBasketBook(int basketId, int bookId);
    }
}
