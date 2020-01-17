using System.ComponentModel.DataAnnotations;

namespace Bookstore.DAL.Models
{
    public class BookDetail
    {
        public int Id { get; set; }

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

        public BookDimension Dimensions { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
