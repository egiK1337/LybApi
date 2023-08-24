using ServiceLayer.Abstractions.Filter;
using ServiceLayer.Abstractions.Sortings.Authors;

namespace ServiceLayer.Abstractions.DTO.Author
{
    public class AuthorSortFilterPageOption : Pagination
    {
        public AuthorFilterDto Filter { get; set; }
        public AuthorOrderByOption OrderByOptions { get; set; }
    }
}
