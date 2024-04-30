using BooksApi.Repository;
using BooksCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers;

[ApiController]
[Route("/api/books")]
public class BooksController(IBookRepository bookRepository) : ControllerBase
{
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Book>> GetBook(Guid id)
    {
        var book = await bookRepository.GetBook(id);

        if (book == null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpGet]
    public async Task<ActionResult<List<Book>>> GetBooks()
    {
        return await bookRepository.GetBooks();
    }

    [HttpPost]
    public async Task<ActionResult<Book>> CreateBook(Book book)
    {
        return await bookRepository.CreateBook(book);
    }
    
    [HttpPut]
    public async Task<ActionResult<Book>> UpdateBook(Book book)
    {
        return await bookRepository.UpdateBook(book);
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteBook(Guid id)
    {
        await bookRepository.DeleteBook(id);

        return Ok();
    }
}