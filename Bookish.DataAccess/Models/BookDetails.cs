using System;

namespace Bookish.DataAccess.Models
{
    public class BookDetails
    {
        public int BookId;
        public int AuthorId;
        public int CopyId;
        public string BookTitle;
        public string AuthorName;
        public string Isbn;
        public string? Username;
        public DateTime? Due;

        public override string ToString()
        {
            var output = $"BookId: {BookId} - AuthorId: {AuthorId} - CopyId: {CopyId} BookTitle: {BookTitle} - AuthorName: {AuthorName} - ISBN: {Isbn} - ";
            if (Username != null) {
                output += "Username: {Username} - Due: {Due}";
            }
            else {
                output += "Not loaned";
            }
            return output;
        }
    }
}