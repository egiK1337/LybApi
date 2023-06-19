using DataLayer.EfCode;
using FluentValidation;
using FluentValidation.Results;
using ServiceLayer.Abstractions.DTO;
using ServiceLayer.Abstractions.ReturnResult;
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

        public ReturnResult<AuthorDto> Edit(AuthorDto authorDto)
        {

            ValidationResult result = validator.Validate(authorDto);

            List<string> errors = new List<string>();

            foreach (var item in result.Errors)
            {
                errors.Add(item.ToString());
            }

            if (!result.IsValid)
            {
                return new ReturnResult<AuthorDto>(authorDto);
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

            return new ReturnResult<AuthorDto>(authorDto);
        }
    }
}
