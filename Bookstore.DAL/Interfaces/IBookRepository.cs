using Bookstore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

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
        IEnumerable<Book> GetWithInclude(params Expression<Func<Book, object>>[] includeProperties);
        IEnumerable<Book> GetWithInclude(Func<Book, bool> predicate, 
            params Expression<Func<Book, object>>[] includeProperties);
    }
}
