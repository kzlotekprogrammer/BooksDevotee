namespace BooksDevotee.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
