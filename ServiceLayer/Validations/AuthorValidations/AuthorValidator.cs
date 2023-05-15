using FluentValidation;
using ServiceLayer.Abstractions.DTO;

namespace ServiceLayer.Validations.AuthorValidations
{
    public class AuthorValidator : AbstractValidator<AuthorDto>
    {
        public AuthorValidator()
        {
            RuleFor(authorDto => authorDto)
              .NotNull()
              .NotEmpty()
              .WithMessage("Request is empty");

            RuleFor(authorDto => authorDto.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("There was entered incorrectly");

            RuleFor(authorDto => authorDto.WebUrl)
               .NotNull()
               .NotEmpty()
               .WithMessage("There was entered incorrectly");
        }
    }
}
