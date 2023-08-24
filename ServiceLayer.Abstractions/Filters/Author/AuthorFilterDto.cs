using ServiceLayer.Abstractions.DTO;

namespace ServiceLayer.Abstractions.Filter
{
    public class AuthorFilterDto
    {
        public string FirstName { get; set; }
        public string? WebUrl { get; set; }
        public PageDto Page { get; set; }

        public AuthorFilterDto()
        {

        }
    }
}
