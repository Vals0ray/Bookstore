using Bookstore.DAL.DataAccess;
using Bookstore.DAL.Interfaces;
using System;

namespace Bookstore.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext db;
        private BookRepository bookRepository;

        public UnitOfWork(DataContext context)
        {
            db = context;
        }

        public IBookRepository Books
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = new BookRepository(db);
                return bookRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}