namespace ServiceLayer.Abstractions.Filter
{
    public class AuthorFilterDto
    {
        public string FirstName { get; set; }
        public string? WebUrl { get; set; }

        public AuthorFilterDto()
        {

        }
    }
}
