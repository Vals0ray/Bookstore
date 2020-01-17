using Bookstore.DAL.Models;
using System;
using System.Collections.Generic;

namespace Bookstore.DAL.Interfaces
{
    public interface IBookRepository
    {
        void Create(Book item);
        Book FindById(int id);
        IEnumerable<Book> Get();
        IEnumerable<Book> Get(Func<Book, bool> predicate);
        void Remove(Book item);
        void Update(Book item);
    }
}
