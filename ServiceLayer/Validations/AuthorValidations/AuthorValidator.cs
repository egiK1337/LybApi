using FluentValidation;
using ServiceLayer.Abstractions.DTO;

namespace ServiceLayer.Validations.AuthorValidations
{
    public class AuthorValidator : AbstractValidator<AuthorDto>
    {
        public AuthorValidator()
        {
            RuleFor(authorDto => authorDto.Name)
                .NotEmpty();

            RuleFor(authorDto => authorDto.WebUrl)
               .NotEmpty();
        }
    }
}
