namespace DataLayer.EfClasses;

public class PriceOffer
{
    public PriceOffer()
    {
    }

    public int Id { get; set; }
    public string PromotionalText { get; set; } = string.Empty;
    public decimal NewPrice { get; set; }

    public int BookId { get; set; }
}
