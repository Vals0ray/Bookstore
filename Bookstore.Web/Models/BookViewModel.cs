﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Web.Models
{
    public class BookViewModel
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

        public BookDetailViewModel Details { get; set; }

        public List<BookAuthorViewModel> Authors { get; set; }
    }

    public class BookAuthorViewModel
    {
        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(64)]
        public string SecondName { get; set; }
    }

    public class BookDetailViewModel
    {
        [Required]
        [MaxLength(64)]
        public string Binding { get; set; }

        [Required]
        [MaxLength(128)]
        public string Publisher { get; set; }

        [Required]
        public short NumberOfPages { get; set; }

        [Required]
        [MaxLength(8)]
        public float Weight { get; set; }

        [Required]
        [MaxLength(32)]
        public string Language { get; set; }

        [Required]
        [MaxLength(8)]
        public float Wide { get; set; }

        [Required]
        [MaxLength(8)]
        public float Long { get; set; }

        [Required]
        [MaxLength(8)]
        public float Tall { get; set; }
    }
}
