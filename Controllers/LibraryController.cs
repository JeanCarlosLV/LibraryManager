using LibraryManager.Communication.Requests;
using LibraryManager.Communication.Responses;
using LibraryManager.Models;
using LibraryManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly BookService _bookService;

        public LibraryController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateBook([FromBody] RequestRegisterBookJson request)
        {
            var newBook = new Book
            {
                Id = request.Id,
                Title = request.Title,
                Author = request.Author,
                Price = request.Price,
                InStock = request.InStock,
                BookGenre = request.BookGenre
            };

            _bookService.AddBook(newBook);

            var response = new ResponseRegisteredBookJson
            {
                Id = newBook.Id,
                Title = newBook.Title
            };

            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult DeleteBook([FromRoute] int id) 
        {
            var bookName = _bookService.GetBook(id);

            try
            {
                _bookService.RemoveBook(id);
                return Ok("Deleted Book: " + bookName);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }


        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateBook(int id, [FromBody] RequestUpdateBookJson updatedBookRequest)
        {
            var updatedBook = new Book
            {
                Title = updatedBookRequest.Title,
                Author = updatedBookRequest.Author,
                Price = updatedBookRequest.Price,
                InStock = updatedBookRequest.InStock,
                BookGenre = updatedBookRequest.BookGenre
            };

            try
            {
                _bookService.UpdateBook(id, updatedBook);
                return Ok("Book updated successfully.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
