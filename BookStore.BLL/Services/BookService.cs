using AutoMapper;
using Bookstore.DAL.Interfaces;
using Bookstore.DAL.Models;
using Bookstore.BLL.DTO;
using Bookstore.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.BLL.Services
{
    public class BookService : IBookService
    {
        private IUnitOfWork Database { get; set; }
        private readonly IMapper mapper;

        public BookService(IUnitOfWork uow, IMapper mapper)
        {
            Database = uow;
            this.mapper = mapper;
        }

        public void Create(BookDTO item)
        {
            var book = mapper.Map<Book>(item);
            Database.Books.Create(book);
            Database.Save();
        }

        public BookDTO FindById(int id)
        {
            var book = Database.Books.FindById(id);
            return mapper.Map<BookDTO>(book);
        }

        public IEnumerable<BookDTO> Get()
        {
            var book = Database.Books.Get().ToList();
            var result = mapper.Map<List<BookDTO>>(book);
            return result;
        }

        public IEnumerable<BookDTO> Get(Func<BookDTO, bool> predicate)
        {
            var bookPredicade = mapper.Map<Func<Book, bool>>(predicate);
            var book = Database.Books.Get(bookPredicade);
            return mapper.Map<List<BookDTO>>(book);
        }

        public void Remove(BookDTO item)
        {
            var book = mapper.Map<Book>(item);
            Database.Books.Remove(book);
            Database.Save();
        }

        public void Update(BookDTO item)
        {
            var book = mapper.Map<Book>(item);
            Database.Books.Update(book);
            Database.Save();
        }
    }
}