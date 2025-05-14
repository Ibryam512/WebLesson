namespace WebLesson.Data.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public List<Book> Books { get; set; }
    }
}
