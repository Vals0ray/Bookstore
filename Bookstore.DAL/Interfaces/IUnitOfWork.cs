using System;

namespace Bookstore.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Books { get; }
        void Save();
    }
}
