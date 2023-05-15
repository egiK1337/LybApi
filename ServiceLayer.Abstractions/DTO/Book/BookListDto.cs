namespace ServiceLayer.Abstractions.DTO
{
    public class BookListDto
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Count { get; set; }
    }
}
