using System.Collections.Generic;
using System.Linq;
using zadanie.Models;

namespace zadanie.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly DataContext _context;
        public BooksRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Book book)
        {
            _context.Set<Book>().Add(book);
            _context.SaveChanges();
        }

        public Book Get(int id)
        {
            return _context.Find<Book>(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public void Delete(int id)
        {
            var book = _context.Find<Book>(id);
            _context.Remove(book);
            _context.SaveChanges();
        }

        public void Update(Book book)
        {
            _context.Set<Book>().Update(book);
            _context.SaveChanges();
        }
    }
}