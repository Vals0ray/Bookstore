using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookstore.Web.Models;
using Bookstore.BLL.Interfaces;

namespace Bookstore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService books;

        public HomeController(IBookService bookService)
        {
            books = bookService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
