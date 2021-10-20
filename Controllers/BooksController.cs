using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_book.Data.Models.ViewModels;
using my_book.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BooksService _bookService;

        public BooksController(BooksService bookService)
        {
            _bookService = bookService;
        }


        [HttpGet("get-all-book")]
        public IActionResult GetAllBooks() {

            var allBooks = _bookService.GetAllBooks();
            return Ok(allBooks);

        
        }  [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookByID(int id) {

            var book = _bookService.GetBookByID(id);
            return Ok(book);
        
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _bookService.AddBook(book);
            return Ok();
        }

        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] BookVM book)
        {
            var updatedBook = _bookService.UpdateBookById(id, book);
            return Ok(updatedBook);
        }

        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            _bookService.DeleteBookById(id);
            return Ok();
        }
    }
}
