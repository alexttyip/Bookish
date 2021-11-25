namespace Bookish.DataAccess.Models
{
    public class BookAuthor
    {
        public int? AuthorId;
        public string AuthorName;
        public int? BookId;
        public string BookTitle;
        public string Isbn;

        public override string ToString()
        {
            return $"BookId: {BookId} - AuthorId: {AuthorId} - BookTitle: {BookTitle} - AuthorName: {AuthorName} - ISBN: {Isbn}";
        }
    }
}