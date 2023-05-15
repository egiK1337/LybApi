namespace ServiceLayer.Abstractions.Filter
{
    public class BooksFilter
    {
        public int HighPrice;

        public int LowPrice;

        public ICollection<string>? Tags { get; set; }

        public ICollection<string>? Titles { get; set; }

        public DateTime? DatePublishedFrom { get; set; }

        public DateTime? DatePublishedTo { get; set; }

        public BooksFilter()
        {
        }
    }
}

