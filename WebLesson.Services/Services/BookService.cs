using WebLesson.Business.Contracts;
using WebLesson.Business.DTOs;
using WebLesson.Business.Helpers;
using WebLesson.Business.Requests;
using WebLesson.Business.Responses;
using WebLesson.Data.Contracts;
using WebLesson.Data.Entities;

namespace WebLesson.Business.Services
{
    public class BookService(IRepository<Book> bookRepository) : IBookService
    {
        public async Task<BaseResponse<int>> AddBook(int userId, SaveBookRequest request)
        {
            Book book = Mapper.ToBook(request);
            book.UserId = userId;

            await bookRepository.Add(book);
            await bookRepository.SaveChanges();

            return BaseResponse<int>.Successful(data: book.Id, message: "Book was added succesfylly");
        }

        public async Task<BaseResponse<bool>> DeleteBook(int bookId)
        {
            Book book = await bookRepository.GetById(bookId);

            if (book is null)
            {
                return BaseResponse<bool>.NotFound("Book not found");
            }

            await bookRepository.Delete(book);
            await bookRepository.SaveChanges();

            return BaseResponse<bool>.Successful(data: true, message: "Book was deleted successfully");
        }

        public async Task<BaseResponse<List<BookDTO>>> GetAllBooks()
        {
            var books = await bookRepository.GetAll();

            List<BookDTO> result = books.Select(book => book.ToBookDTO()).ToList();

            return BaseResponse<List<BookDTO>>.Successful(data: result, message: "Books were retreived successfully");
        }

        public async Task<BaseResponse<BookDTO>> GetBookById(int bookId)
        {
            var book = await bookRepository.GetById(bookId);

            if (book is null)
            {
                return BaseResponse<BookDTO>.NotFound("Book not found");
            }

            var bookDTO = book.ToBookDTO();
            return BaseResponse<BookDTO>.Successful(data: bookDTO, message: "Book was retreived successfully");
        }

        public async Task<BaseResponse<bool>> UpdateBook(int bookId, SaveBookRequest request)
        {
            var book = await bookRepository.GetById(bookId);

            if (book is null)
            {
                return BaseResponse<bool>.NotFound("Book not found");
            }

            book.Title = request.Title;
            book.Author = request.Author;
            book.Description = request.Description;
            book.PublishedYear = request.PublishedYear;
            book.Publisher = request.Publisher;

            await bookRepository.Update(book);
            await bookRepository.SaveChanges();

            return BaseResponse<bool>.Successful(data: true, message: "Book was updated successfully");
        }
    }
}
