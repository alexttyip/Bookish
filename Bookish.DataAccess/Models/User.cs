namespace Bookish.DataAccess.Models
{
    public class User
    {

        public User() { }

        public User(string username, string pwHash)
        {
            Username = username;
            Pw_hash = pwHash;
        }
        public int? Id { get; set; }
        public string Username { get; set; }

        // ReSharper disable once InconsistentNaming
        public string Pw_hash { get; set; }

        public User Copy()
        {
            return new User(Username, Pw_hash);
        }
    }
}