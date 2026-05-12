namespace LibraryDb.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int PublishYear { get; set; }

    // Външен ключ към Author (1→много)
    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;

    // Навигационно свойство: много→много с Category
    public ICollection<Category> Categories { get; set; } = new List<Category>();
}
