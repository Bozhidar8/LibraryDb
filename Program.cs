using LibraryDb.Data;
using LibraryDb.Models;
using Microsoft.EntityFrameworkCore;

Console.OutputEncoding = System.Text.Encoding.UTF8;

using var db = new LibraryContext();

// Уверяваме се, че базата данни е създадена
db.Database.EnsureCreated();

Console.WriteLine("=== Библиотечна система ===\n");

// -------------------------------------------------------
// ДОБАВЯНЕ НА ПРИМЕРНИ ДАННИ (само при първо стартиране)
// -------------------------------------------------------
if (!db.Authors.Any())
{
    // Категории
    var fiction    = new Category { Name = "Белетристика" };
    var mystery    = new Category { Name = "Мистерия" };
    var science    = new Category { Name = "Наука" };
    var dystopia   = new Category { Name = "Антиутопия" };

    db.Categories.AddRange(fiction, mystery, science, dystopia);

    // Автори
    var orwell  = new Author { FirstName = "Джордж",  LastName = "Оруел",    BirthYear = 1903 };
    var doyle   = new Author { FirstName = "Артур",   LastName = "Дойл",     BirthYear = 1859 };
    var hawking = new Author { FirstName = "Стивън",  LastName = "Хокинг",   BirthYear = 1942 };

    db.Authors.AddRange(orwell, doyle, hawking);

    // Книги с категории (много→много)
    var book1 = new Book
    {
        Title = "1984",
        PublishYear = 1949,
        Author = orwell,
        Categories = new List<Category> { fiction, dystopia }
    };
    var book2 = new Book
    {
        Title = "Фермата на животните",
        PublishYear = 1945,
        Author = orwell,
        Categories = new List<Category> { fiction }
    };
    var book3 = new Book
    {
        Title = "Приключенията на Шерлок Холмс",
        PublishYear = 1892,
        Author = doyle,
        Categories = new List<Category> { fiction, mystery }
    };
    var book4 = new Book
    {
        Title = "Кратка история на времето",
        PublishYear = 1988,
        Author = hawking,
        Categories = new List<Category> { science }
    };

    db.Books.AddRange(book1, book2, book3, book4);

    db.SaveChanges();
    Console.WriteLine("Примерните данни са добавени успешно!\n");
}

// -------------------------------------------------------
// ИЗВЛИЧАНЕ И ПОКАЗВАНЕ НА ДАННИТЕ
// -------------------------------------------------------

Console.WriteLine("--- КНИГИ ---");
var books = db.Books
    .Include(b => b.Author)
    .Include(b => b.Categories)
    .ToList();

foreach (var book in books)
{
    var cats = string.Join(", ", book.Categories.Select(c => c.Name));
    Console.WriteLine($"  [{book.Id}] \"{book.Title}\" ({book.PublishYear})");
    Console.WriteLine($"       Автор: {book.Author.FirstName} {book.Author.LastName}");
    Console.WriteLine($"       Категории: {cats}");
}

Console.WriteLine("\n=== Готово! ===");
