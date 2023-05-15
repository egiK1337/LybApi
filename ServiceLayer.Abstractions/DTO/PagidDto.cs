using Newtonsoft.Json;

namespace ServiceLayer.Abstractions.DTO
{
    public class PagedDto
    {
        [JsonProperty(PropertyName = "page_number")]
        public int PageNumber { get; set; }

        [JsonProperty(PropertyName = "all_pages_numbers")]
        public int AllPagesNumbers { get; set; }

        public PagedDto()
        {
        }
    }
}