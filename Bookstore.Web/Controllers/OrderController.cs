using AutoMapper;
using Bookstore.BLL.Interfaces;
using Bookstore.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Bookstore.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IBookService books;
        private readonly IMapper mapper;

        public OrderController(IBookService bookService, IMapper mapper)
        {
            books = bookService;
            this.mapper = mapper;
        }

        public IActionResult Cart(int? id)
        {
            if(id != null)
            {
                var book = books.GetWithInclude(b => b.Id == id, b => b.Authors).First();
                var model = mapper.Map<BookViewModel>(book);
                var cart = Models.StaticData.Cart.BooksInCart;
                cart.Add(model);
                Models.StaticData.Cart.Sum += model.Price;
            }

            return View();
        }

        public IActionResult Remove(int? id)
        {
            if (id != null)
            {
                var cart = Models.StaticData.Cart.BooksInCart;
                var cartBook = cart.First(b => b.Id == id);
                cart.Remove(cartBook);
                Models.StaticData.Cart.Sum -= cartBook.Price;
            }

            return View("Cart");
        }
    }
}