using LibraryDb.Data;
using LibraryDb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryDb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly LibraryContext _db;

    public BooksController(LibraryContext db)
    {
        _db = db;
    }

    // ============ СИНХРОНЕН ВАРИАНТ ============
    // Извличане на всички книги — блокира thread-а на сървъра, докато БД работи.
    [HttpGet("sync")]
    public ActionResult<List<Book>> GetBooksSync()
    {
        var books = _db.Books
            .Include(b => b.Author)
            .Include(b => b.Categories)
            .ToList();   // блокираща операция
        return Ok(books);
    }

    // ============ АСИНХРОНЕН ВАРИАНТ ============
    // Извличане на всички книги — освобождава thread-а, докато БД работи.
    [HttpGet("async")]
    public async Task<ActionResult<List<Book>>> GetBooksAsync()
    {
        var books = await _db.Books
            .Include(b => b.Author)
            .Include(b => b.Categories)
            .ToListAsync();   // неблокираща операция
        return Ok(books);
    }
}
