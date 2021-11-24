namespace Bookish.Models
{
    public class Author
    {

        public Author(string name)
        {
            Name = name;
        }
        public int? id { get; set; }
        public string Name { get; set; }
    }
}