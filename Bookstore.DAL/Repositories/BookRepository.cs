using Bookstore.DAL.DataAccess;
using Bookstore.DAL.Interfaces;
using Bookstore.DAL.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    }
}
