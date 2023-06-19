using DataLayer.EfClasses;
using DataLayer.EfCode;
using FluentValidation.Results;
using ServiceLayer.Abstractions.DTO;
using ServiceLayer.Abstractions.ReturnResult;
using ServiceLayer.Validations.AuthorValidations;


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

        public ReturnResult<AuthorDto> Add(AuthorDto authorDto) 
        {
            ValidationResult result = validator.Validate(authorDto);

            List<string> errors = new List<string>();

            foreach (var item in result.Errors)
            {                                                
                errors.Add(item.ToString());
            }


            if (!result.IsValid)
            {
                return new ReturnResult<AuthorDto>(authorDto, result.Errors);
            }

            var author = _context.Authors
                .Where(author => author.Name.ToUpper() == authorDto.Name.ToUpper())
                .FirstOrDefault();


            if (author != null)
            {
                author.Name = authorDto.Name;
                author.WebUrl = authorDto.WebUrl;
                _context.SaveChanges();
                return new ReturnResult<AuthorDto>(authorDto);
            }

            var newAuthor = new Author()
            {
                Name = authorDto.Name,
                WebUrl = authorDto.WebUrl
            };

            _context.Add(newAuthor);

            _context.SaveChanges();

            return new ReturnResult<AuthorDto>(authorDto);
        }
    }
}