using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookstore.Web.Models;
using Bookstore.BLL.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;

namespace Bookstore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService books;
        private readonly IMapper mapper;

        public HomeController(IBookService bookService, IMapper mapper)
        {
            books = bookService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var bookDTOs = books.Get().ToList();

            if(bookDTOs.Count >= 4)
            {
                bookDTOs = bookDTOs.TakeLast(4).ToList();
            }

            var model = mapper.Map<List<BookViewModel>>(bookDTOs);

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
