namespace BookManagement.UnitTest
{
    using BookManagement.Repository;
    using BookManagement.Service;
    using Moq;
    using System;
    using System.Collections.Generic;
    using Xunit;

    /// <summary>
    /// Book Repo Test
    /// </summary>
    public class BookRepoTest
    {
        /// <summary>
        /// The book service
        /// </summary>
        private readonly Mock<IBookService> bookService;

        /// <summary>
        /// The book repo
        /// </summary>
        private readonly BookRepo bookRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookRepoTest"/> class.
        /// </summary>
        public BookRepoTest()
        {
            bookService = new Mock<IBookService>();
            bookRepo = new BookRepo(bookService.Object);
        }

        /// <summary>
        /// Gets the books pass.
        /// </summary>
        [Fact]
        public void GetBooks_Pass()
        {
            // Arrange
            List<Book> bookListPass = new List<Book>();
            Book bookDataPass = new Book
            {
                Name = "Book1",
                AuthorName = "Author1"
            };
            bookListPass.Add(bookDataPass);
            bookService.Setup(repo => repo.GetBooks())
                .Returns(bookListPass);

            // Act
            ApiResponse<List<Book>> getBooksPass = bookRepo.GetBooks();

            //Assert
            var apiRespGetBooksPass = Assert.IsType<ApiResponse<List<Book>>>(getBooksPass);
            Assert.True(apiRespGetBooksPass.IsSuccess);
        }

        /// <summary>
        /// Gets the books fail.
        /// </summary>
        [Fact]
        public void GetBooks_Fail()
        {
            // Arrange
            List<Book> bookListFail = new List<Book>();
            bookService.Setup(repo => repo.GetBooks())
                .Returns(bookListFail);

            // Act
            ApiResponse<List<Book>> getBooksFail = bookRepo.GetBooks();

            //Assert
            var apiRespGetBooksFail = Assert.IsType<ApiResponse<List<Book>>>(getBooksFail);
            Assert.False(apiRespGetBooksFail.IsSuccess);
        }

        /// <summary>
        /// Gets the book by identifier pass.
        /// </summary>
        [Fact]
        public void GetBookById_Pass()
        {
            // Arrange
            var bookByIdInputPass = Guid.NewGuid();
            Book bookByIdPass = new Book
            {
                Id = bookByIdInputPass,
                Name = "Book1",
                AuthorName = "Author1"
            };
            bookService.Setup(repo => repo.GetBookById(bookByIdInputPass))
                .Returns(bookByIdPass);

            // Act
            ApiResponse<Book> bookByIdResultPass = bookRepo.GetBookById(bookByIdInputPass);

            //Assert
            var apiRespbookByIdPass = Assert.IsType<ApiResponse<Book>>(bookByIdResultPass);
            Assert.True(apiRespbookByIdPass.IsSuccess);
        }

        /// <summary>
        /// Gets the book by identifier fail.
        /// </summary>
        [Fact]
        public void GetBookById_Fail()
        {
            // Arrange
            var bookByIdInputFail = Guid.NewGuid();
            Book bookByIdFail = null;
            bookService.Setup(repo => repo.GetBookById(bookByIdInputFail))
                .Returns(bookByIdFail);

            // Act
            ApiResponse<Book> bookByIdResultFail = bookRepo.GetBookById(bookByIdInputFail);

            //Assert
            var apiRespbookByIdPass = Assert.IsType<ApiResponse<Book>>(bookByIdResultFail);
            Assert.False(apiRespbookByIdPass.IsSuccess);
        }

        /// <summary>
        /// Creates the book pass.
        /// </summary>
        [Fact]
        public void CreateBook_Pass()
        {
            // Arrange
            var createBookOutputPass = new ApiResponse<string> { IsSuccess = true };
            Book createBookPass = new Book
            {
                Name = "Book1",
                AuthorName = "Author1"
            };
            Book returnBookPass = null;
            bookService.Setup(repo => repo.GetBookByName(createBookPass.Name, createBookPass.AuthorName))
                .Returns(returnBookPass);
            bookService.Setup(repo => repo.CreateBook(createBookPass))
               .Returns(createBookOutputPass);

            // Act
            ApiResponse<string> createBookResultPass = bookRepo.CreateBook(createBookPass);

            //Assert
            var apiRespcreateBookPass = Assert.IsType<ApiResponse<string>>(createBookResultPass);
            Assert.True(apiRespcreateBookPass.IsSuccess);
        }

        /// <summary>
        /// Creates the book fail1.
        /// </summary>
        [Fact]
        public void CreateBook_Fail1()
        {
            // Arrange
            Book createBookFail1 = new Book
            {
                Name = "Book1",
                AuthorName = "Author1"
            };
            bookService.Setup(repo => repo.GetBookByName(createBookFail1.Name, createBookFail1.AuthorName))
                .Returns(createBookFail1);

            // Act
            ApiResponse<string> createBookResultFail1 = bookRepo.CreateBook(createBookFail1);

            //Assert
            var apiRespcreateBookFail = Assert.IsType<ApiResponse<string>>(createBookResultFail1);
            Assert.False(apiRespcreateBookFail.IsSuccess);
        }

        /// <summary>
        /// Creates the book fail2.
        /// </summary>
        [Fact]
        public void CreateBook_Fail2()
        {
            // Arrange
            var createBookOutputFail2 = new ApiResponse<string> { IsSuccess = false };
            Book createBookFail2 = new Book
            {
                Name = "Book1",
                AuthorName = "Author1"
            };
            Book returnBookFail2 = null;
            bookService.Setup(repo => repo.GetBookByName(createBookFail2.Name, createBookFail2.AuthorName))
                .Returns(returnBookFail2);
            bookService.Setup(repo => repo.CreateBook(createBookFail2))
               .Returns(createBookOutputFail2);

            // Act
            ApiResponse<string> createBookResultFail2 = bookRepo.CreateBook(createBookFail2);

            //Assert
            var apiRespcreateBookFail2 = Assert.IsType<ApiResponse<string>>(createBookResultFail2);
            Assert.False(apiRespcreateBookFail2.IsSuccess);
        }

        /// <summary>
        /// Creates the book fail3.
        /// </summary>
        [Fact]
        public void CreateBook_Fail3()
        {
            // Arrange
            Book createBookFail3 = new Book
            {
                Name = "",
                AuthorName = "Author1"
            };

            // Act
            ApiResponse<string> createBookResultFail3 = bookRepo.CreateBook(createBookFail3);

            //Assert
            var apiRespcreateBookFail3 = Assert.IsType<ApiResponse<string>>(createBookResultFail3);
            Assert.False(apiRespcreateBookFail3.IsSuccess);
        }

        /// <summary>
        /// Creates the book fail4.
        /// </summary>
        [Fact]
        public void CreateBook_Fail4()
        {
            // Arrange
            Book createBookFail4 = new Book
            {
                Name = "Book1",
                AuthorName = ""
            };

            // Act
            ApiResponse<string> createBookResultFail4 = bookRepo.CreateBook(createBookFail4);

            //Assert
            var apiRespcreateBookFail4 = Assert.IsType<ApiResponse<string>>(createBookResultFail4);
            Assert.False(apiRespcreateBookFail4.IsSuccess);
        }

        /// <summary>
        /// Creates the book fail5.
        /// </summary>
        [Fact]
        public void CreateBook_Fail5()
        {
            // Arrange
            Book createBookFail5 = null;

            // Act
            ApiResponse<string> createBookResultFail5 = bookRepo.CreateBook(createBookFail5);

            //Assert
            var apiRespcreateBookFail5 = Assert.IsType<ApiResponse<string>>(createBookResultFail5);
            Assert.False(apiRespcreateBookFail5.IsSuccess);
        }
    }
}