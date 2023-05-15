namespace DataLayer.EfClasses;

public class Review
{
    public Review()
    {
    }

    public int Id { get; set; }
    public string VoterName { get; set; } = string.Empty;
    public int NumStars { get; set; }
    public string Comment { get; set; } = string.Empty;

    public int BookId { get; set; }
}
