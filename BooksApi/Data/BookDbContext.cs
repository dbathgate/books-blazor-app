using Microsoft.EntityFrameworkCore;

namespace BooksApi.Data;

public class BookDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<BookDto> Books { get; set; }
}