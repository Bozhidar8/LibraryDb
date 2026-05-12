namespace LibraryDb.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    // Навигационно свойство: много→много с Book
    public ICollection<Book> Books { get; set; } = new List<Book>();
}
