using Bookstore.BLL.DTO;
using System;
using System.Collections.Generic;

namespace Bookstore.BLL.Interfaces
{
    public interface IBookService
    {
        void Create(BookDTO item);
        BookDTO FindById(int id);
        IEnumerable<BookDTO> Get();
        IEnumerable<BookDTO> Get(Func<BookDTO, bool> predicate);
        void Remove(BookDTO item);
        void Update(BookDTO item);
    }
}
