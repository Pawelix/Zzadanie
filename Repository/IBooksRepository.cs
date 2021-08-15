using System.Collections.Generic;
using zadanie.Models;

namespace zadanie.Repository
{
    public interface IBooksRepository
    {
        Book Get(int id);
        void Add(Book book);
        IEnumerable<Book> GetAll();
        void Update(Book book);
        void Delete(int id);
    }
}