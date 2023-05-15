using FluentValidation;
using ServiceLayer.Abstractions.DTO;

namespace ServiceLayer.Validations.BookValidations
{
    public class BookValidator : AbstractValidator<BookAddDto>
    {

        public BookValidator()
        {
            RuleFor(bookAddDto => bookAddDto)
                .NotNull()
                .NotEmpty()
                .WithMessage("Request is empty");

            RuleFor(bookAddDto => bookAddDto.Description)
                .NotNull()
                .NotEmpty()
                .WithMessage("Description was entered incorrectly");

            RuleFor(bookAddDto => bookAddDto.Publisher)
                .NotNull()
                .NotEmpty()
                .WithMessage("Publisher was entered incorrectly");

            RuleFor(bookAddDto => bookAddDto.Price)
                .NotNull()
                .NotEmpty()
                .WithMessage("Price was entered incorrectly")
                .When(bookAddDto => bookAddDto.Price > 0)
                .WithMessage("Price must be greater than zero");

            RuleFor(bookAddDto => bookAddDto.ImageUrl)
                .NotNull()
                .NotEmpty()
                .WithMessage("ImageUrl was entered incorrectly");

            RuleFor(bookAddDto => bookAddDto.WebUrl)
                .NotNull()
                .NotEmpty()
                .WithMessage("WebUrl was entered incorrectly");

            RuleFor(bookAddDto => bookAddDto.Count)
                .NotNull()
                .NotEmpty()
                .WithMessage("Count was entered incorrectly")
                .When(bookAddDto => bookAddDto.Count > 0)
                .WithMessage("Count must be greater than zero");

            RuleFor(bookAddDto => bookAddDto.Title)
                           .NotNull()
                           .NotEmpty()
                           .WithMessage("There was entered incorrectly");

        }
    }
}
