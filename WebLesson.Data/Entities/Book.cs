namespace WebLesson.Data.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int PublishedYear { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
        
        // The user who added the book
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
