using AutoMapper;
using Bookstore.BLL.DTO;
using Bookstore.DAL.Models;

namespace Bookstore.BLL.Infrastructure
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>();

            CreateMap<BookAuthor, BookAuthorDTO>();
            CreateMap<BookAuthorDTO, BookAuthor>();
        }
    }
}
