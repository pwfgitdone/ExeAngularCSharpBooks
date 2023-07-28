using Microsoft.AspNetCore.Mvc;
using Summaries.Data;

namespace Summaries.Controllers {

    [Route("api/[controller]")]
    public class BooksController:Controller {

        private IBookService _service;
        public BooksController(IBookService service)
        {
            _service = service;
        }

        // Create/Add a new book
        [HttpPost("AddBook")]
        public IActionResult AddBook([FromBody]Book book)
        {
            _service.AddBook(book);
            return Ok("Added");
        }

        [HttpGet("[action]")]
        public IActionResult GetBooks()
        {
            var allBooks = _service.GetAllBooks();
            return Ok(allBooks);
        }

        //Update an existing book
        [HttpPut("UpdateBook/{id}")]
        public IActionResult UpdateBook(int id, [FromBody]Book book) {
            _service.UpdateBook(id, book);
            return Ok(book);
        }

        [HttpDelete("DeleteBook/{id}")]
        public IActionResult DeleteBook(int id) {
            _service.DeleteBook(id);
            return Ok();
        }

        // Get a single book
        [HttpGet("SingleBook/{id}")]
        public IActionResult GetBookById(int id) {
            var book = _service.GetBookById(id);
            return Ok(book);
        }
    }
}