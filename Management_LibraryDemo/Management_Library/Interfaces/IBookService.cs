using Management_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Library.Interfaces
{
    public interface IBookService
    {
        List<Book> GetBooks();
        void AddBook(Book book);
        void EditBook(int id, string title, string author);
    }
}
