using System.Collections.Generic;

namespace BooksDevotee.Models
{
    public interface IBasketBookRepository
    {
        BasketBook GetBasketBook(int id);
        IEnumerable<BasketBook> GetAllBasketBooks();
        BasketBook Add(BasketBook basketBook);
        BasketBook Update(BasketBook basketBookChanges);
        BasketBook Delete(int id);
    }
}
