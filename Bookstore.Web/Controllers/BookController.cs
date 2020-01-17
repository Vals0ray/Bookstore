using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Bookstore.Web.Models;
using Bookstore.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService books;
        private readonly IMapper mapper;

        public BookController(IBookService bookService, IMapper mapper)
        {
            books = bookService;
            this.mapper = mapper;
        }

        public IActionResult BooksList()
        {
            var bookDTOs = books.Get().ToList();
            var model = mapper.Map<List<BookViewModel>>(bookDTOs);

            return View(model);
        }
    }
}