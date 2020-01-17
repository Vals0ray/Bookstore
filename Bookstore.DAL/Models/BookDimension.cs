using System.ComponentModel.DataAnnotations;

namespace Bookstore.DAL.Models
{
    public class BookDimension
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(8)]
        public float Wide { get; set; }

        [Required]
        [MaxLength(8)]
        public float Long  { get; set; }

        [Required]
        [MaxLength(8)]
        public float Tall { get; set; }

        public int BookDetailsId { get; set; }
        public BookDetail BookDetails { get; set; }
    }
}
