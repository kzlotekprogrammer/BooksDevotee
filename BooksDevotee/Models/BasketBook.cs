namespace BooksDevotee.Models
{
    public class BasketBook
    {
        public int BasketBookId { get; set; }
        public int BasketId { get; set; }
        public int BookId { get; set; }
        public Basket Basket { get; set; }
        public Book Book { get; set; }
    }
}
