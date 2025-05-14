using WebLesson.Business.DTOs;
using WebLesson.Business.Requests;
using WebLesson.Business.Responses;

namespace WebLesson.Business.Contracts
{
    public interface IBookService
    {
        Task<BaseResponse<List<BookDTO>>> GetAllBooks();
        Task<BaseResponse<BookDTO>> GetBookById(int bookId);
        Task<BaseResponse<int>> AddBook(int userId, SaveBookRequest request);
        Task<BaseResponse<bool>> UpdateBook(int bookId, SaveBookRequest request);
        Task<BaseResponse<bool>> DeleteBook(int bookId);

    }
}
