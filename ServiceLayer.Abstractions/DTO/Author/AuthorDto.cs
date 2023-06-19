using ServiceLayer.Abstractions.ReturnResult;

namespace ServiceLayer.Abstractions.DTO
{
    public class AuthorDto : IDto
    {

        public string Name { get; set; }
        public string WebUrl { get; set; }

        public AuthorDto()
        {

        }
    }
}
