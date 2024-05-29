using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Library.Exceptions
{
    public class BookNotFoundException : Exception
    {
            public int BookId { get; } 
            public string BookTitle { get; } 

            public BookNotFoundException(string message, string bookTitle, int bookId) : base(message)
            {
                BookTitle = bookTitle;
                BookId = bookId;
            }

            public BookNotFoundException(string message) : base(message)
            {
            }

            public string GetDetailedMessage()
            {
                string errorMessage = Message;
                if (!string.IsNullOrEmpty(BookTitle))
                {
                    errorMessage += $" Título del libro: {BookTitle}";
                }
                if (BookId != 0)
                {
                    errorMessage += $" ID del libro: {BookId}";
                }
                return errorMessage;
            }
    }
}
