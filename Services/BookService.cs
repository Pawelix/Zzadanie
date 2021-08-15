using System.Collections.Generic;
using System.Linq;
using zadanie.Models;
using zadanie.Repository;

namespace zadanie.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _booksRepository;

        public BooksService(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public void AddBook(Book book)
        {          
            _booksRepository.Add(book);
        }

        public Book GetBook(int id)
        {
            var book = _booksRepository.Get(id);

            if (book == null)
                return null;

            return book;          
        }

        public IEnumerable<Book> GetAll()
        {
            return _booksRepository.GetAll().Select(book => new Book
            {
                Id = book.Id,
                Author = book.Author,
                Title = book.Title,
                Category = book.Category
            });
        }

        public void UpdateBook(Book book)
        {          
            _booksRepository.Update(book);
        }

        public void DeleteBook(int id)
        {
            _booksRepository.Delete(id);
        }
    }
}