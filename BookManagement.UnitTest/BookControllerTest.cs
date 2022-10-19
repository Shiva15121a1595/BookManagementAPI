namespace BookManagement.UnitTest
{
    using BookManagement.Repository;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using System;
    using System.Collections.Generic;
    using Xunit;

    /// <summary>
    /// Book Controller Test
    /// </summary>
    public class BookControllerTest
    {
        /// <summary>
        /// The book repo
        /// </summary>
        private readonly Mock<IBookRepo> bookRepo;

        /// <summary>
        /// The book controller
        /// </summary>
        private readonly BookController bookController;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookControllerTest"/> class.
        /// </summary>
        public BookControllerTest()
        {
            bookRepo = new Mock<IBookRepo>();
            bookController = new BookController(bookRepo.Object);
        }

        /// <summary>
        /// Creates the book pass.
        /// </summary>
        [Fact]
        public void CreateBook_Pass()
        {
            // Arrange
            var createBookPassInput = new Book();
            var createBookPassOutput = new ApiResponse<string> { IsSuccess = true };
            bookRepo.Setup(repo => repo.CreateBook(createBookPassInput))
                .Returns(createBookPassOutput);

            //Act
            IActionResult createBookPass = bookController.CreateBook(createBookPassInput);

            //Assert
            var checkCreateResultPass = Assert.IsType<OkObjectResult>(createBookPass);
            var apiRespCreatePass = Assert.IsType<ApiResponse<string>>(checkCreateResultPass.Value);
            Assert.True(apiRespCreatePass.IsSuccess);
        }

        /// <summary>
        /// Creates the book fail.
        /// </summary>
        [Fact]
        public void CreateBook_Fail()
        {
            // Arrange
            var createBookFailInput = new Book();
            var createBookFailOutput = new ApiResponse<string> { IsSuccess = false };
            bookRepo.Setup(repo => repo.CreateBook(createBookFailInput))
                .Returns(createBookFailOutput);

            //Act
            IActionResult createBookFail = bookController.CreateBook(createBookFailInput);

            //Assert
            var checkCreateResultFail = Assert.IsType<NotFoundObjectResult>(createBookFail);
            var apiRespCreateFail = Assert.IsType<ApiResponse<string>>(checkCreateResultFail.Value);
            Assert.False(apiRespCreateFail.IsSuccess);
        }

        /// <summary>
        /// Gets all books pass.
        /// </summary>
        [Fact]
        public void GetAllBooks_Pass()
        {
            // Arrange
            var getAllBooksPassOutput = new ApiResponse<List<Book>> { IsSuccess = true };
            bookRepo.Setup(repo => repo.GetBooks())
                .Returns(getAllBooksPassOutput);

            //Act
            IActionResult getAllBooksPass = bookController.GetAllBooks();

            //Assert
            var checkGetAllResultPass = Assert.IsType<OkObjectResult>(getAllBooksPass);
            var apiRespGetAllPass = Assert.IsType<ApiResponse<List<Book>>>(checkGetAllResultPass.Value);
            Assert.True(apiRespGetAllPass.IsSuccess);
        }

        /// <summary>
        /// Gets all books fail.
        /// </summary>
        [Fact]
        public void GetAllBooks_Fail()
        {
            // Arrange
            var getAllBooksfailOutput = new ApiResponse<List<Book>> { IsSuccess = false };
            bookRepo.Setup(repo => repo.GetBooks())
                .Returns(getAllBooksfailOutput);

            //Act
            IActionResult getAllBooksfail = bookController.GetAllBooks();

            //Assert
            var checkGetAllResultFail = Assert.IsType<NotFoundObjectResult>(getAllBooksfail);
            var apiRespGetAllFail = Assert.IsType<ApiResponse<List<Book>>>(checkGetAllResultFail.Value);
            Assert.False(apiRespGetAllFail.IsSuccess);
        }

        /// <summary>
        /// Gets the book by identifier pass.
        /// </summary>
        [Fact]
        public void GetBookById_Pass()
        {
            // Arrange
            var getBookByIdInput = Guid.NewGuid();
            var getBookByIdOutput = new ApiResponse<Book> { IsSuccess = true };
            bookRepo.Setup(repo => repo.GetBookById(getBookByIdInput))
                .Returns(getBookByIdOutput);

            //Act
            IActionResult getBookByIdPass = bookController.GetBookById(getBookByIdInput);

            //Assert
            var checkGetByIdResultPass = Assert.IsType<OkObjectResult>(getBookByIdPass);
            var apiRespGetByIdPass = Assert.IsType<ApiResponse<Book>>(checkGetByIdResultPass.Value);
            Assert.True(apiRespGetByIdPass.IsSuccess);
        }

        /// <summary>
        /// Gets the book by identifier fail.
        /// </summary>
        [Fact]
        public void GetBookById_Fail()
        {
            // Arrange
            var getBookByIdFailInput = Guid.NewGuid();
            var getBookByIdFailOutput = new ApiResponse<Book> { IsSuccess = false };
            bookRepo.Setup(repo => repo.GetBookById(getBookByIdFailInput))
                .Returns(getBookByIdFailOutput);

            //Act
            IActionResult getBookByIdFail = bookController.GetBookById(getBookByIdFailInput);

            //Assert
            var checkGetByIdResultFail = Assert.IsType<NotFoundObjectResult>(getBookByIdFail);
            var apiRespGetByIdFail = Assert.IsType<ApiResponse<Book>>(checkGetByIdResultFail.Value);
            Assert.False(apiRespGetByIdFail.IsSuccess);
        }

        /// <summary>
        /// Deletes the book pass.
        /// </summary>
        [Fact]
        public void DeleteBook_Pass()
        {
            // Arrange
            var deleteBookInput = Guid.NewGuid();
            var deleteBookOutput = new ApiResponse<string> { IsSuccess = true };
            bookRepo.Setup(repo => repo.DeleteBook(deleteBookInput))
                .Returns(deleteBookOutput);

            //Act
            IActionResult deleteBookPass = bookController.DeleteBook(deleteBookInput);

            //Assert
            var checkDeleteResultPass = Assert.IsType<OkObjectResult>(deleteBookPass);
            var apiRespDeletePass = Assert.IsType<ApiResponse<string>>(checkDeleteResultPass.Value);
            Assert.True(apiRespDeletePass.IsSuccess);
        }

        /// <summary>
        /// Deletes the book fail.
        /// </summary>
        [Fact]
        public void DeleteBook_Fail()
        {
            // Arrange
            var deleteBookFailInput = Guid.NewGuid();
            var deleteBookFailOutput = new ApiResponse<string> { IsSuccess = false };
            bookRepo.Setup(repo => repo.DeleteBook(deleteBookFailInput))
                .Returns(deleteBookFailOutput);

            //Act
            IActionResult deleteBookFail = bookController.DeleteBook(deleteBookFailInput);

            //Assert
            var checkDeleteResultFail = Assert.IsType<NotFoundObjectResult>(deleteBookFail);
            var apiRespDeleteFail = Assert.IsType<ApiResponse<string>>(checkDeleteResultFail.Value);
            Assert.False(apiRespDeleteFail.IsSuccess);
        }

        /// <summary>
        /// Updates the book pass.
        /// </summary>
        [Fact]
        public void UpdateBook_Pass()
        {
            // Arrange
            var updateBookPassInput = new Book();
            var updateBookPassOutput = new ApiResponse<string> { IsSuccess = true };
            bookRepo.Setup(repo => repo.UpdateBook(updateBookPassInput))
                .Returns(updateBookPassOutput);

            //Act
            IActionResult updateBookPass = bookController.UpdateBook(updateBookPassInput);

            //Assert
            var checkUpdateResultPass = Assert.IsType<OkObjectResult>(updateBookPass);
            var apiRespUpdatePass = Assert.IsType<ApiResponse<string>>(checkUpdateResultPass.Value);
            Assert.True(apiRespUpdatePass.IsSuccess);
        }

        /// <summary>
        /// Updates the book fail.
        /// </summary>
        [Fact]
        public void UpdateBook_Fail()
        {
            // Arrange
            var updateBookFailInput = new Book();
            var updateBookFailOutput = new ApiResponse<string> { IsSuccess = false };
            bookRepo.Setup(repo => repo.UpdateBook(updateBookFailInput))
                .Returns(updateBookFailOutput);

            //Act
            IActionResult updateBookFail = bookController.UpdateBook(updateBookFailInput);

            //Assert
            var checkUpdateResultFail = Assert.IsType<NotFoundObjectResult>(updateBookFail);
            var apiRespUpdateFail = Assert.IsType<ApiResponse<string>>(checkUpdateResultFail.Value);
            Assert.False(apiRespUpdateFail.IsSuccess);
        }

        /// <summary>
        /// Saves the book pass.
        /// </summary>
        [Fact] 
        public void SaveBook_Pass()
        {
            // Arrange
            var saveBookPassInput = new Book();
            var saveBookPassOutput = new ApiResponse<string> { IsSuccess = true };
            bookRepo.Setup(repo => repo.SaveBook(saveBookPassInput))
                .Returns(saveBookPassOutput);

            //Act
            IActionResult saveBookPass = bookController.SaveBook(saveBookPassInput);

            //Assert
            var checkSaveResultPass = Assert.IsType<OkObjectResult>(saveBookPass);
            var apiRespSavePass = Assert.IsType<ApiResponse<string>>(checkSaveResultPass.Value);
            Assert.True(apiRespSavePass.IsSuccess);
        }

        /// <summary>
        /// Saves the book fail.
        /// </summary>
        [Fact]
        public void SaveBook_Fail()
        {
            // Arrange
            var saveBookFailInput = new Book();
            var saveBookFailOutput = new ApiResponse<string> { IsSuccess = false };
            bookRepo.Setup(repo => repo.SaveBook(saveBookFailInput))
                .Returns(saveBookFailOutput);

            //Act
            IActionResult saveBookFail = bookController.SaveBook(saveBookFailInput);

            //Assert
            var checkSaveResultFail = Assert.IsType<NotFoundObjectResult>(saveBookFail);
            var apiRespSaveFail = Assert.IsType<ApiResponse<string>>(checkSaveResultFail.Value);
            Assert.False(apiRespSaveFail.IsSuccess);
        }
    }
}