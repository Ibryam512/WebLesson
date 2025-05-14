using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebLesson.Business.Contracts;
using WebLesson.Business.Requests;

namespace WebLesson.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController(IBookService bookService) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var response = await bookService.GetAllBooks();
            return Ok(response);
        }

        [HttpGet("{bookId:int}")]
        public async Task<IActionResult> GetBookById(int bookId)
        {
            var response = await bookService.GetBookById(bookId);
            if (!response.Success)

            {
                return HandleFailure(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] SaveBookRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = RetrieveUserId();

            var response = await bookService.AddBook(userId, request);

            if (!response.Success)
            {
                return HandleFailure(response);
            }

            return CreatedAtAction(nameof(GetBookById), new { bookId = response.Data }, response);
        }

        [HttpPut("{bookId:int}")]
        public async Task<IActionResult> UpdateBook(int bookId, [FromBody] SaveBookRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await bookService.UpdateBook(bookId, request);

            if (!response.Success)
            {
                return HandleFailure(response);
            }

            return NoContent();
        }

        [HttpDelete("{bookId:int}")]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            var response = await bookService.DeleteBook(bookId);

            if (!response.Success)
            {
                return HandleFailure(response);
            }

            return NoContent();
        }
    }
}
