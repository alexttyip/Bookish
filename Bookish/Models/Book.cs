namespace Bookish.Models
{
    public class Book
    {
        public Book(string title, string isbn)
        {
            Title = title;
            Isbn = isbn;
        }

        public int? Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
    }
}