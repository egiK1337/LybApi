using ServiceLayer.Abstractions.Filter;

namespace ServiceLayer.Abstractions.DTO
{
    public class SortFilterPageOptions : Abstractions.Pagination
    {
        public BooksFilter Filter { get; set; }
        public OrderByOptions OrderByOptions { get; set; }
    }
}

