using System;
using System.Collections.Generic;

namespace Bookstore.Web.Models.StaticData
{
    public static class Cart
    {
        private static double sum = 0.00;
        public static double Sum { get => Math.Round(sum, 2); set => sum = value; }
        public static List<BookViewModel> BooksInCart { get; set; }

        static Cart()
        {
            BooksInCart = new List<BookViewModel>();
        }
    }
}
