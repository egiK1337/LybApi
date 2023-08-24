using ServiceLayer.Abstractions;

namespace DataLayer.EfClasses;

public class Book : IEntity
{
    public Book()
    {
    }

    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime PublishedOn { get; set; }
    public string Publisher { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public int Count { get; set; }
    public string WebUrl { get; set; } = string.Empty;

    public ICollection<BookAuthor> Authors { get; set; }
    public ICollection<Tag> Tags { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public PriceOffer Promotion { get; set; }
}
