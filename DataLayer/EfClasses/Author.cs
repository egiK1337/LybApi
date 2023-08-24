using ServiceLayer.Abstractions;

namespace DataLayer.EfClasses;

public class Author : IEntity
{
    public Author()
    {
    }

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string WebUrl { get; set; } = string.Empty;

    ICollection<BookAuthor> Books { get; set; }
}
