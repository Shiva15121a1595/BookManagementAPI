namespace BookManagement
{
    using BookManagement.Repository;
    using Microsoft.AspNetCore.Mvc;
    using System;

    /// <summary>
    /// Book Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        /// <summary>
        /// The book repo
        /// </summary>
        private readonly IBookRepo bookRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookController"/> class.
        /// </summary>
        /// <param name="_bookRepo">The book repo.</param>
        public BookController(IBookRepo _bookRepo)
        {
            bookRepo = _bookRepo;
        }

        /// <summary>
        /// Gets all books.
        /// </summary>
        /// <returns>Get all books</returns>
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                var bookList = bookRepo.GetBooks();
                if (bookList.IsSuccess)
                {
                    return Ok(bookList);
                }
                else
                {
                    return NotFound(bookList);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Gets the book by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Gets book by identifier</returns>
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetBookById(Guid id)
        {
            try
            {
                var bookData = bookRepo.GetBookById(id);
                if (bookData.IsSuccess)
                {
                    return Ok(bookData);
                }
                else
                {
                    return NotFound(bookData);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Creates the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>Creates book</returns>
        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            try
            {
                var createBook = bookRepo.CreateBook(book);
                if (createBook.IsSuccess)
                {
                    return Ok(createBook);
                }
                else
                {
                    return NotFound(createBook);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deletes the book.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Deletes book</returns>
        [HttpDelete]
        public IActionResult DeleteBook(Guid id)
        {
            try
            {
                var deleteBook = bookRepo.DeleteBook(id);
                if (deleteBook.IsSuccess)
                {
                    return Ok(deleteBook);
                }
                else
                {
                    return NotFound(deleteBook);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Updates the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>Updates book</returns>
        [HttpPatch]
        public IActionResult UpdateBook(Book book)
        {
            try
            {
                var updateBook = bookRepo.UpdateBook(book);
                if (updateBook.IsSuccess)
                {
                    return Ok(updateBook);
                }
                else
                {
                    return NotFound(updateBook);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Saves the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>Saves book</returns>
        [HttpPut]
        public IActionResult SaveBook(Book book)
        {
            try
            {
                var saveBook = bookRepo.SaveBook(book);
                if (saveBook.IsSuccess)
                {
                    return Ok(saveBook);
                }
                else
                {
                    return NotFound(saveBook);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}