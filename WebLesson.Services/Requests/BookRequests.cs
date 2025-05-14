using System.ComponentModel.DataAnnotations;

namespace WebLesson.Business.Requests
{
    public record SaveBookRequest(
        [Required]
        string Title,
        [Required]
        string Description,
        [Required]
        int PublishedYear,
        [Required]
        string Publisher,
        [Required]
        string Author
    );
}
