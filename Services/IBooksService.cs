using System.Collections.Generic;
using zadanie.Models;

namespace zadanie.Services
{
    public interface IBooksService
    {
        void AddBook(Book book);
        Book GetBook(int id);
        IEnumerable<Book> GetAll();
        void DeleteBook(int id);
        void UpdateBook(Book book);
    }
}
