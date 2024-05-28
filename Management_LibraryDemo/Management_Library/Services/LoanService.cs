using Management_Library.Exceptions;
using Management_Library.Interfaces;
using Management_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Library.Services
{
    public class LoanService : ILoanService
    {
        private List<Loan> loans = new List<Loan>();
        private List<Book> books;
        private int loanIdCounter = 1;

        public LoanService(List<Book> books)
        {
            this.books = books;
        }

        public List<Loan> GetLoans()
        {
            return loans;
        }

        public void RegisterLoan(string clientEmail, int bookId, int loanDays)
        {
            var book = books.FirstOrDefault(b => b.Id == bookId && b.IsAvailable);
            if (book == null)
            {
                throw new BookNotFoundException($"El libro con ID {bookId} no está disponible.");
            }

            book.IsAvailable = false;
            var loan = new Loan
            {
                Id = loanIdCounter++,
                BookId = bookId,
                ClientEmail = clientEmail,
                LoanDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(loanDays)
            };
            loans.Add(loan);
        }

        public void ReturnBook(int loanId)
        {
            var loan = loans.FirstOrDefault(l => l.Id == loanId && !l.IsReturned);
            if (loan == null)
            {
                throw new LoanNotFoundException($"El préstamo con ID {loanId} no se encontró.");
            }

            loan.IsReturned = true;
            var book = books.FirstOrDefault(b => b.Id == loan.BookId);
            if (book != null)
            {
                book.IsAvailable = true;
                if (DateTime.Now > loan.DueDate)
                {
                    Console.WriteLine("Mora: El libro fue devuelto tarde.");
                }
            }
        }
    }
}
