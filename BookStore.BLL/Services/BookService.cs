using AutoMapper;
using Bookstore.DAL.Interfaces;
using Bookstore.DAL.Models;
using Bookstore.BLL.DTO;
using Bookstore.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Bookstore.BLL.Infrastructure;
using System.Linq.Expressions;

namespace Bookstore.BLL.Services
{
    public class BookService : IBookService
    {
        private IUnitOfWork Database { get; set; }
        private readonly IMapper mapper;

        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            Database = unitOfWork;
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
            var books = Database.Books.Get().ToList();
            return mapper.Map<List<BookDTO>>(books);
        }

        public IEnumerable<BookDTO> Get(Func<BookDTO, bool> predicate)
        {
            var bookPredicade = MapFunc<BookDTO, Book>(predicate);
            var books = Database.Books.Get(bookPredicade);
            return mapper.Map<List<BookDTO>>(books);
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

        public IEnumerable<BookDTO> GetWithInclude(params Expression<Func<BookDTO, object>>[] includeProperties)
        {
            int i = 0;
            var properties = new Expression<Func<Book, object>>[includeProperties.Length];

            foreach (var property in includeProperties)
            {
                properties[i++] = ExpressionRewriter.CastParam<BookDTO, Book>(property);
            }

            var books = Database.Books.GetWithInclude(properties).ToList();

            return mapper.Map<List<BookDTO>>(books);
        }

        public IEnumerable<BookDTO> GetWithInclude(Func<BookDTO, bool> predicate, params Expression<Func<BookDTO, object>>[] includeProperties)
        {
            int i = 0;
            var properties = new Expression<Func<Book, object>>[includeProperties.Length];

            foreach (var property in includeProperties)
            {
                properties[i++] = ExpressionRewriter.CastParam<BookDTO, Book>(property);
            }

            var bookPredicade = MapFunc<BookDTO, Book>(predicate);
            var books = Database.Books.GetWithInclude(bookPredicade, properties).ToList();

            return mapper.Map<List<BookDTO>>(books);
        }

        private Func<TOut, bool> MapFunc<TIn, TOut>(Func<TIn, bool> func)
        {
            return new Func<TOut, bool>(
                (TOut arg) => func(mapper.Map<TOut, TIn>(arg))
            );
        }
    }
}