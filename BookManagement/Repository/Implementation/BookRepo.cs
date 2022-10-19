namespace BookManagement.Repository
{
    using BookManagement.Service;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Book Repo
    /// </summary>
    /// <seealso cref="BookManagement.Repository.IBookRepo" />
    public class BookRepo : IBookRepo
    {
        /// <summary>
        /// The book service
        /// </summary>
        private readonly IBookService bookService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookRepo"/> class.
        /// </summary>
        /// <param name="_bookService">The book service.</param>
        public BookRepo(IBookService _bookService)
        {
            bookService = _bookService;
        }

        #region Public Methods

        /// <summary>
        /// Gets the books.
        /// </summary>
        /// <returns>Gets books</returns>
        public ApiResponse<List<Book>> GetBooks()
        {
            ApiResponse<List<Book>> getBooks = new ApiResponse<List<Book>>
            {
                IsSuccess = false,
                Message = "Book data not found",
                Response = new List<Book>()
            };
            try
            {
                var bookList = bookService.GetBooks();
                if (bookList?.Any() == true)
                {
                    getBooks.IsSuccess = true;
                    getBooks.Message = "Success";
                    getBooks.Response.AddRange(bookList);
                }
            }
            catch (Exception ex)
            {
                getBooks.Message = ex.Message;
                getBooks.ExceptionRaised = ex;
            }

            return getBooks;
        }

        /// <summary>
        /// Gets the book by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Gets book by identifier
        /// </returns>
        public ApiResponse<Book> GetBookById(Guid id)
        {
            ApiResponse<Book> getBookById = new ApiResponse<Book>
            {
                IsSuccess = false,
                Message = "Book data not found"
            };
            try
            {
                var bookData = bookService.GetBookById(id);
                if (bookData != null && bookData.Id == id)
                {
                    getBookById.IsSuccess = true;
                    getBookById.Message = "Success";
                    getBookById.Response = bookData;
                }
            }
            catch (Exception ex)
            {
                getBookById.Message = ex.Message;
                getBookById.ExceptionRaised = ex;
            }

            return getBookById;
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
            ApiResponse<string> createBook = new ApiResponse<string>
            {
                IsSuccess = false
            };
            try
            {
                createBook = ValidateBook(book);
                if (createBook.IsSuccess)
                {
                    var checkBookExist = bookService.GetBookByName(book.Name, book.AuthorName);
                    if (checkBookExist != null)
                    {
                        createBook.IsSuccess = false;
                        createBook.Message = "Book already exist";
                    }
                    else
                    {
                        createBook = bookService.CreateBook(book);
                    }
                }
            }
            catch (Exception ex)
            {
                createBook.Message = ex.Message;
                createBook.ExceptionRaised = ex;
            }

            return createBook;
        }

        /// <summary>
        /// Deletes the book.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Deletes book
        /// </returns>
        public ApiResponse<string> DeleteBook(Guid id)
        {
            ApiResponse<string> deleteBook = new ApiResponse<string>
            {
                IsSuccess = false,
                Message = "Book not exist"
            };
            try
            {
                var bookExist = bookService.GetBookById(id);
                if (bookExist != null)
                {
                    deleteBook = bookService.DeleteBook(bookExist);
                }
            }
            catch (Exception ex)
            {
                deleteBook.Message = ex.Message;
                deleteBook.ExceptionRaised = ex;
            }

            return deleteBook;
        }

        /// <summary>
        /// Updates the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>
        /// Updates book
        /// </returns>
        public ApiResponse<string> UpdateBook(Book book)
        {
            ApiResponse<string> updateBook = new ApiResponse<string>
            {
                IsSuccess = false,
                Message = "Book not exist"
            };
            try
            {
                var bookExist = bookService.GetBookById(book.Id);
                if (bookExist != null)
                {
                    updateBook = ValidateBook(book);
                    if (updateBook.IsSuccess)
                    {
                        bookExist.Name = book.Name;
                        bookExist.AuthorName = book.AuthorName;
                        updateBook = bookService.UpdateBook(bookExist);
                    }
                }
            }
            catch (Exception ex)
            {
                updateBook.Message = ex.Message;
                updateBook.ExceptionRaised = ex;
            }

            return updateBook;
        }

        /// <summary>
        /// Saves the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>
        /// Saves book
        /// </returns>
        public ApiResponse<string> SaveBook(Book book)
        {
            ApiResponse<string> saveBook = new ApiResponse<string>
            {
                IsSuccess = false
            };
            try
            {
                saveBook = ValidateBook(book);
                if (saveBook.IsSuccess)
                {
                    var checkBookExist = bookService.GetBookById(book.Id);
                    if (checkBookExist != null)
                    {
                        checkBookExist.Name = book.Name;
                        checkBookExist.AuthorName = book.AuthorName;
                        saveBook = bookService.UpdateBook(checkBookExist);
                    }
                    else
                    {
                        saveBook = bookService.CreateBook(book);
                    }
                }
            }
            catch (Exception ex)
            {
                saveBook.Message = ex.Message;
                saveBook.ExceptionRaised = ex;
            }

            return saveBook;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Validates the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>Validates book</returns>
        private ApiResponse<string> ValidateBook(Book book)
        {
            ApiResponse<string> validateBook = new ApiResponse<string>
            {
                IsSuccess = true,
                Message = "Success"
            };
            try
            {
                if (book == null)
                {
                    validateBook.IsSuccess = false;
                    validateBook.Message = "Book data is null";
                }
                else if (string.IsNullOrEmpty(book.Name))
                {
                    validateBook.IsSuccess = false;
                    validateBook.Message = "Book name is null";
                }
                else if (string.IsNullOrEmpty(book.AuthorName))
                {
                    validateBook.IsSuccess = false;
                    validateBook.Message = "Author name is null";
                }
            }
            catch (Exception ex)
            {
                validateBook.Message = ex.Message;
                validateBook.ExceptionRaised = ex;
            }

            return validateBook;
        }

        #endregion Private Methods
    }
}