using System.ComponentModel.DataAnnotations;

namespace WebLesson.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
