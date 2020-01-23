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
            var allBooks = books.GetWithInclude(b => b.Category == category, b => b.Authors);

            var booksOnPage = allBooks.Skip((page - 1) * 10)
                                      .Take(10)
                                      .ToList();

            var model = mapper.Map<List<BookViewModel>>(booksOnPage);

            ViewBag.Category = category;
            ViewBag.CurrentPage = page;
            ViewBag.BooksCount = allBooks.Count();

            return View(model);
        }

        public IActionResult Books(int id)
        {
            var book = books.GetWithInclude(b => b.Id == id, b => b.Authors, b => b.Details).First();
            var model = mapper.Map<BookViewModel>(book);

            return View(model);
        }
    }
}