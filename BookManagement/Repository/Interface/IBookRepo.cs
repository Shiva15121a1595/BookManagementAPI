namespace BookManagement.Repository
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Book repository
    /// </summary>
    public interface IBookRepo
    {
        /// <summary>
        /// Gets the books.
        /// </summary>
        /// <returns>Gets books</returns>
        ApiResponse<List<Book>> GetBooks();

        /// <summary>
        /// Gets the book by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Gets book by identifier</returns>
        ApiResponse<Book> GetBookById(Guid id);

        /// <summary>
        /// Creates the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>Creates book</returns>
        ApiResponse<string> CreateBook(Book book);

        /// <summary>
        /// Deletes the book.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Deletes book</returns>
        ApiResponse<string> DeleteBook(Guid id);

        /// <summary>
        /// Updates the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>Updates book</returns>
        ApiResponse<string> UpdateBook(Book book);

        /// <summary>
        /// Saves the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>Saves book</returns>
        ApiResponse<string> SaveBook(Book book);
    }
}