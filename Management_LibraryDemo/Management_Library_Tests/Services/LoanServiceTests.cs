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
    public class LoanServiceTests
    {
        private LoanService loanService;
        private BookService bookService;

        public LoanServiceTests()
        {
            bookService = new BookService();
            loanService = new LoanService(bookService.GetBooks());
        }

        [Fact]
        public void RegisterLoan_ShouldRegisterLoan()
        {
            var book = new Book { Title = "Test Book", Author = "Test Author" };
            bookService.AddBook(book);

            loanService.RegisterLoan("client@example.com", 1, 7);
            var books = bookService.GetBooks();

            Assert.False(books[0].IsAvailable);
        }

        [Fact]
        public void RegisterLoan_ShouldThrowExceptionIfBookNotFound()
        {
            Assert.Throws<BookNotFoundException>(() => loanService.RegisterLoan("client@example.com", 999, 7));
        }

        [Fact]
        public void ReturnBook_ShouldReturnBook()
        {
            var book = new Book { Title = "Test Book", Author = "Test Author" };
            bookService.AddBook(book);
            loanService.RegisterLoan("client@example.com", 1, 7);
            var loan = loanService.GetLoans()[0];

            loanService.ReturnBook(loan.Id);
            var books = bookService.GetBooks();

            Assert.True(books[0].IsAvailable);
        }

        [Fact]
        public void ReturnBook_ShouldThrowExceptionIfLoanNotFound()
        {
            Assert.Throws<LoanNotFoundException>(() => loanService.ReturnBook(999));
        }
    }
}
