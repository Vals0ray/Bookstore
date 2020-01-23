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

            CreateMap<BookDetail, BookDetailDTO>();
            CreateMap<BookDetailDTO, BookDetail>();

            CreateMap<BookAuthor, BookAuthorDTO>();
            CreateMap<BookAuthorDTO, BookAuthor>();
        }
    }
}
