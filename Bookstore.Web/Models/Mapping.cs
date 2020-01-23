using AutoMapper;
using Bookstore.BLL.DTO;

namespace Bookstore.Web.Models
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<BookViewModel, BookDTO>();
            CreateMap<BookDTO, BookViewModel>();

            CreateMap<BookAuthorViewModel, BookAuthorDTO>();
            CreateMap<BookAuthorDTO, BookAuthorViewModel>();
        }
    }
}
