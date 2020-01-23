using Bookstore.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.DAL.DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<BookAuthor> BookAuthors { get; set; }

        public DbSet<BookDetail> BookDetails { get; set; }

        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }
    }
}
