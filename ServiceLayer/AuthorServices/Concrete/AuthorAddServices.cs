using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.AuthorServices.Concrete
{
    public class AuthorAddServices
    {
        private readonly EfCoreContext _context;

        public AuthorAddServices(EfCoreContext context)
        {
            _context = context;
        }

        AuthorValidator validator = new AuthorValidator();

        public ReturnAuthorResult Add(AuthorDto authorDto)
        {
            ValidationResult result = validator.Validate(authorDto);

            if (!result.IsValid)
            {
                return new ReturnAuthorResult(result);
            }

            var author = _context.Authors
                .Where(author => author.Name.ToUpper() == authorDto.Name.ToUpper())
                .FirstOrDefault();

            if (author != null)
            {
                author.Name = authorDto.Name;
                author.WebUrl = authorDto.WebUrl;
                _context.SaveChanges();
                return new ReturnAuthorResult(author.Name, author.WebUrl);
            }

            _context.Add(new Author()
            {
                Name = authorDto.Name,
                WebUrl = authorDto.WebUrl
            });

            _context.SaveChanges();

            return new ReturnAuthorResult(authorDto.Name, authorDto.WebUrl);
        }
    }
}