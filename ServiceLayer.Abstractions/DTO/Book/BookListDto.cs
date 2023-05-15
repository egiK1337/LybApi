namespace ServiceLayer.Abstractions.DTO
{
    public class BookListDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Description { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishedOn { get; set; }
        public decimal Price { get; set; }
        public decimal ActualPrice { get; set; }
        public string PromotionPromotionalText { get; set; } = string.Empty;
        public string AuthorsOrdered { get; set; } = string.Empty;
        public int ReviewsCount { get; set; }
        public double? ReviewsAverageVotes { get; set; }
        public string[]? TagStrings { get; set; }
        public int Count { get; set; }

        public BookListDto()
        {
        }
    }
}
