using WebLesson.Business.DTOs;
using WebLesson.Business.Requests;
using WebLesson.Data.Entities;

namespace WebLesson.Business.Helpers
{
    public static class Mapper
    {
        public static Book ToBook(this SaveBookRequest request)
        {
            return new Book
            {
                Title = request.Title,
                Description = request.Description,
                PublishedYear = request.PublishedYear,
                Publisher = request.Publisher,
                Author = request.Author
            };
        }

        public static BookDTO ToBookDTO(this Book book)
        {
            return new BookDTO(
                book.Title,
                book.Description,
                book.PublishedYear,
                book.Publisher,
                book.Author,
                book.User?.Username ?? "Unknown User"
            );
        }
    }
}
