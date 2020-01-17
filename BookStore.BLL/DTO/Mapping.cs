using AutoMapper;
using Bookstore.DAL.Models;
using System;

namespace Bookstore.BLL.DTO
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>();

            CreateMap<Func<BookDTO, bool>, Func<Book, bool>>();
            CreateMap<Func<Book, bool>, Func<BookDTO, bool>>();
        }
    }
}
