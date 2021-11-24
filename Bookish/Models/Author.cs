namespace Authorish.Models
{
    public class Author
    {
        public int? id { get; set; }
        public string Name { get; set; }

        public Author(string name)
        {
            Name = name;
        }
    }
}