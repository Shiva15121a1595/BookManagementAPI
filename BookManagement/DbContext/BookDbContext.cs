namespace BookManagement
{
    using Microsoft.EntityFrameworkCore;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Book Db Context
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    [ExcludeFromCodeCoverage]
    public class BookDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookDbContext"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public BookDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Gets or sets the book.
        /// </summary>
        /// <value>
        /// The book.
        /// </value>
        public DbSet<Book> Book { get; set; }
    }
}