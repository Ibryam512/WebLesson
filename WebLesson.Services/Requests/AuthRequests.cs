using System.ComponentModel.DataAnnotations;

namespace WebLesson.Business.Requests
{
    public record LoginRequest(
        [Required]
        string Username,
        [Required]
        string Password
    );
    public record RegisterRequest(
        [Required]
        string Username,
        [Required]
        string Password
    );
}
