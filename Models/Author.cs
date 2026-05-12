namespace LibraryDb.Models;

public class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int BirthYear { get; set; }

    // Навигационно свойство: един автор → много книги (1→много)
    public ICollection<Book> Books { get; set; } = new List<Book>();
}
