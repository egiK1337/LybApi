using ServiceLayer.Abstractions;

namespace DataLayer.EfClasses;

public class BookAuthor
{
    public BookAuthor()
    {
    }

    public int BookId { get; set; }
    public int AuthorId { get; set; }
    public int Order { get; set; }

    public Book Book { get; set; }
    public Author Author { get; set; }
}
