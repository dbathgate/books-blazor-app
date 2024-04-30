using BooksCore.Models;

namespace BooksApi.Repository;

public interface IBookRepository
{
    Task<List<Book>> GetBooks();

    Task<Book?> GetBook(Guid id);

    Task<Book> CreateBook(Book book);

    Task<Book> UpdateBook(Book book);

    Task DeleteBook(Guid id);
}