using ServiceLayer.Abstractions.Filter;

namespace ServiceLayer.Abstractions.DTO
{
    public class SortFilterPageOptions : Abstractions.Pagination
    {
        //to do generic for filter field
        public BooksFilter Filter { get; set; }
        public OrderByOptions OrderByOptions { get; set; }
    }
}

