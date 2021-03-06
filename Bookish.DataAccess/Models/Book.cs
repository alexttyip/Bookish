using System;

namespace Bookish.DataAccess.Models
{
    public class Book
    {
        public Book() { }
        public Book(string title, string isbn)
        {
            Title = title;
            Isbn = isbn;
        }

        public int? Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Title} - {Isbn}";
        }
    }

    public class LoanedBook : Book
    {
        public LoanedBook() { }

        public LoanedBook(string title, string isbn, DateTime due) : base(title, isbn)
        {
            Due = due;
        }

        public DateTime Due { get; set; }

        public bool IsBookOverdue()
        {
            return DateTime.Now > Due;
        }

        public override string ToString()
        {
            return base.ToString() + $" - {Due}";
        }
    }
}