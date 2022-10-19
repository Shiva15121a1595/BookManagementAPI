namespace BookManagement.Service
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Book Service
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// Gets the books.
        /// </summary>
        /// <returns>Gets books</returns>
        List<Book> GetBooks();

        /// <summary>
        /// Gets the book by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Gets book by identifier</returns>
        Book GetBookById(Guid id);

        /// <summary>
        /// Creates the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>Creates book</returns>
        ApiResponse<string> CreateBook(Book book);

        /// <summary>
        /// Deletes the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>Deletes book</returns>
        ApiResponse<string> DeleteBook(Book book);

        /// <summary>
        /// Gets the book by name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="authorName">Name of the author.</param>
        /// <returns>Gets book by name</returns>
        Book GetBookByName(string name, string authorName);

        /// <summary>
        /// Updates the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>Updates book</returns>
        ApiResponse<string> UpdateBook(Book book);
    }
}