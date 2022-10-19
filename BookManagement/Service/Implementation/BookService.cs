namespace BookManagement.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Book Service
    /// </summary>
    /// <seealso cref="BookManagement.Service.IBookService" />
    public class BookService : IBookService
    {
        /// <summary>
        /// The book database context
        /// </summary>
        private readonly BookDbContext bookDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookService"/> class.
        /// </summary>
        /// <param name="_bookDbContext">The book database context.</param>
        public BookService(BookDbContext _bookDbContext)
        {
            bookDbContext = _bookDbContext;
        }

        /// <summary>
        /// Gets the books.
        /// </summary>
        /// <returns>
        /// Gets books
        /// </returns>
        public List<Book> GetBooks()
        {
            try
            {
                return bookDbContext.Book.ToList();
            }
            catch
            {
                return new List<Book>();
            }
        }

        /// <summary>
        /// Gets the book by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Gets book by identifier
        /// </returns>
        public Book GetBookById(Guid id)
        {
            try
            {
                return bookDbContext.Book.FirstOrDefault(x => x.Id == id);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Creates the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>
        /// Creates book
        /// </returns>
        public ApiResponse<string> CreateBook(Book book)
        {
            ApiResponse<string> bookCreated = new ApiResponse<string>
            {
                IsSuccess = false
            };
            try
            {
                bookDbContext.Add<Book>(book);
                bookDbContext.SaveChanges();
                bookCreated.IsSuccess = true;
                bookCreated.Message = "Successfully added Book";
            }
            catch (Exception ex)
            {
                bookCreated.Message = ex.Message;
                bookCreated.ExceptionRaised = ex;
            }

            return bookCreated;
        }

        /// <summary>
        /// Deletes the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>
        /// Deletes book
        /// </returns>
        public ApiResponse<string> DeleteBook(Book book)
        {
            ApiResponse<string> bookDeleted = new ApiResponse<string>
            {
                IsSuccess = false
            };
            try
            {
                bookDbContext.Remove<Book>(book);
                bookDbContext.SaveChanges();
                bookDeleted.IsSuccess = true;
                bookDeleted.Message = "Successfully deleted Book";
            }
            catch (Exception ex)
            {
                bookDeleted.Message = ex.Message;
                bookDeleted.ExceptionRaised = ex;
            }

            return bookDeleted;
        }

        /// <summary>Gets the book by name.</summary>
        /// <param name="name">The name.</param>
        /// <param name="authorName">Name of the author.</param>
        /// <returns>Gets book by name</returns>
        public Book GetBookByName(string name, string authorName)
        {
            try
            {
                return bookDbContext.Book.FirstOrDefault(x => x.Name == name && x.AuthorName == authorName);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>Updates the book.</summary>
        /// <param name="book">The book.</param>
        /// <returns>Updates book</returns>
        public ApiResponse<string> UpdateBook(Book book)
        {
            ApiResponse<string> updateBook = new ApiResponse<string>
            {
                IsSuccess = false
            };
            try
            {
                bookDbContext.Update<Book>(book);
                bookDbContext.SaveChanges();
                updateBook.IsSuccess = true;
                updateBook.Message = "Successfully updated Book";
            }
            catch (Exception ex)
            {
                updateBook.Message = ex.Message;
                updateBook.ExceptionRaised = ex;
            }

            return updateBook;
        }
    }
}