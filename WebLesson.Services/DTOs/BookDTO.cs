namespace WebLesson.Business.DTOs
{
    public record BookDTO(
        string Title,
        string Description,
        int PublishedYear,
        string Publisher,
        string Author,
        string AddedBy
    );
}
