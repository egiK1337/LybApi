namespace ServiceLayer.Abstractions.DTO
{
    public class PagedDto<T>
    {
        //[JsonProperty(PropertyName = "page_number")]
        //public int PageNumber { get; set; }

        //[JsonProperty(PropertyName = "all_pages_numbers")]
        //public int AllPagesNumbers { get; set; }

        //public PagedDto()
        //{
        //}

        public IEnumerable<T> Items { get; set; }

        public int PageNumber { get; set; }

        public int AllPagesNumbers { get; set; }

        public PagedDto(
            IEnumerable<T> items,
            int pageNumber,
            int allPagesNumbers)
        {
            Items = items;
            PageNumber = pageNumber;
            AllPagesNumbers = allPagesNumbers;
        }
    }
}