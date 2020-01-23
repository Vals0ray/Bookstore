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

        public IActionResult BooksList(string category, int page = 1)
        {
            var AllBooks = books.GetWithInclude(b => b.Category == category, b => b.Authors);

            var BooksOnPage = AllBooks.Skip((page - 1) * 10)
                                      .Take(10)
                                      .ToList();

            var model = mapper.Map<List<BookViewModel>>(BooksOnPage);

            ViewBag.Category = category;
            ViewBag.CurrentPage = page;
            ViewBag.BooksCount = AllBooks.Count();

            return View(model);
        }
    }
}