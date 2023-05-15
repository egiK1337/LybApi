using DataLayer.EfCode;
using FluentValidation;
using FluentValidation.Results;
using ServiceLayer.Abstractions;
using ServiceLayer.Abstractions.DTO;
using ServiceLayer.Validations.AuthorValidations;


namespace ServiceLayer.AuthorServices.Concrete
{
    public class AuthorEditServices
    {
        private readonly EfCoreContext _context;

        AuthorValidator validator = new AuthorValidator();

        public AuthorEditServices(EfCoreContext context)
        {
            _context = context;
        }

        public ReturnAuthorResult Edit(AuthorDto authorDto)
        {

            ValidationResult result = validator.Validate(authorDto);

            if (!result.IsValid)
            {
                return new ReturnAuthorResult(result);
            }

            var author = _context.Authors
                .Where(author => author.Name.ToUpper() == authorDto.Name.ToUpper())
                .FirstOrDefault();

            if (author == null)
            {
                throw new ValidationException("This author is not in the database");
            }
            author.Name = authorDto.Name;
            author.WebUrl = authorDto.WebUrl;

            _context.SaveChanges();

            return new ReturnAuthorResult(author.Name, author.WebUrl);
        }
    }
}
