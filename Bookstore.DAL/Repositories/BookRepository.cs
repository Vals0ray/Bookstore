using Bookstore.DAL.DataAccess;
using Bookstore.DAL.Interfaces;
using Bookstore.DAL.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bookstore.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext db;
        DbSet<Book> Books;

        public BookRepository(DataContext context)
        {
            db = context;
            Books = context.Set<Book>();
        }

        public void Create(Book item)
        {
            Books.Add(item);
        }

        public Book FindById(int id)
        {
            return Books.Find(id);
        }

        public IEnumerable<Book> Get()
        {
            return Books.AsNoTracking().ToList();
        }

        public IEnumerable<Book> Get(Func<Book, bool> predicate)
        {
            return Books.AsNoTracking().Where(predicate).ToList();
        }

        public void Remove(Book item)
        {
            Books.Remove(item);
        }

        public void Update(Book item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<Book> GetWithInclude(params Expression<Func<Book, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<Book> GetWithInclude(Func<Book, bool> predicate,
            params Expression<Func<Book, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        private IQueryable<Book> Include(params Expression<Func<Book, object>>[] includeProperties)
        {
            IQueryable<Book> query = Books.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
