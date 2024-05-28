using System.Collections.Generic;
using System.Linq;
using Management_Library.Interfaces;
using Management_Library.Models;
using Management_Library.Exceptions;

namespace Management_Library.Services
{
    public class BookService : IBookService
    {
        private List<Book> books = new List<Book>();
        private int bookIdCounter = 1;

        public List<Book> GetBooks()
        {
            return books;
        }

        public void AddBook(Book book)
        {
            book.Id = bookIdCounter++;
            books.Add(book);
        }

        public void EditBook(int id, string title, string author)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                throw new BookNotFoundException($"El libro con ID {id} no se encontró.");
            }
            book.Title = title;
            book.Author = author;
        }
    }
}