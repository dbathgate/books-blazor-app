using BooksApi.Data;
using BooksCore.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Repository;

public class BookRepository(BookDbContext dbContext) : IBookRepository
{
    public async Task<List<Book>> GetBooks()
    {
        return await dbContext.Books.Select(book =>
            new Book
            {
                Id = book.Id.ToString(),
                Name = book.Name,
                Author = book.Author
            }
        ).ToListAsync();
    }

    public async Task<Book?> GetBook(Guid id)
    {
        return await dbContext.Books
            .Where(book => book.Id == id)
            .Select(book =>
                new Book
                {
                    Id = book.Id.ToString(),
                    Name = book.Name,
                    Author = book.Author
                })
            .FirstOrDefaultAsync();
    }

    public async Task<Book> CreateBook(Book book)
    {
        var newBook = new BookDto
        {
            Id = Guid.NewGuid(),
            Name = book.Name,
            Author = book.Author
        };

        dbContext.Books.Add(newBook);
        await dbContext.SaveChangesAsync();

        book.Id = newBook.Id.ToString();
        
        return book;
    }

    public async Task<Book> UpdateBook(Book book)
    {
        var newBook = new BookDto
        {
            Id = Guid.Parse(book.Id),
            Name = book.Name,
            Author = book.Author
        };

        dbContext.Books.Update(newBook);
        await dbContext.SaveChangesAsync();
        
        return book;
    }

    public async Task DeleteBook(Guid id)
    {
        dbContext.Books.Remove(new BookDto { Id = id });
        await dbContext.SaveChangesAsync();
    }
}