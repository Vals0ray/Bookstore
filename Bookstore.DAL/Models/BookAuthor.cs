using System.ComponentModel.DataAnnotations;

namespace Bookstore.DAL.Models
{
    public class BookAuthor
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(64)]
        public string SecondName { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
