using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.DAL.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Title { get; set; }

        public byte[] Image { get; set; }

        [Required]
        [MaxLength(32)]
        public string Category { get; set; }

        [Required]
        public DateTime Edition { get; set; }

        [Required]
        [MaxLength(8)]
        public double Price { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }

        public List<BookAuthor> Authors { get; set; }

        public BookDetail Details { get; set; }
    }
}
