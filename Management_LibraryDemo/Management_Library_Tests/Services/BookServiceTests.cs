using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management_Library.Exceptions;
using Management_Library.Models;
using Management_Library.Services;

namespace Management_Library_Tests.Services
{
    public class BookServiceTests
    {
        private BookService bookService;

        public BookServiceTests()
        {
            bookService = new BookService();
        }

        [Fact]
        public void AddBook_ShouldAddBook()
        {
            var book = new Book { Title = "Test Book", Author = "Test Author" };

            bookService.AddBook(book);
            var books = bookService.GetBooks();

            Assert.Single(books);
            Assert.Equal("Test Book", books[0].Title);
            Assert.Equal("Test Author", books[0].Author);
        }

        [Fact]
        public void EditBook_ShouldEditBook()
        {
            var book = new Book { Title = "Test Book", Author = "Test Author" };
            bookService.AddBook(book);

            bookService.EditBook(1, "New Title", "New Author");
            var editedBook = bookService.GetBooks()[0];

            Assert.Equal("New Title", editedBook.Title);
            Assert.Equal("New Author", editedBook.Author);
        }

        [Fact]
        public void EditBook_ShouldThrowExceptionIfBookNotFound()
        {
            Assert.Throws<BookNotFoundException>(() => bookService.EditBook(999, "Title", "Author"));
        }
    }
}
