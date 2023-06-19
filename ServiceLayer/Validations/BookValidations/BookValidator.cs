using FluentValidation;
using ServiceLayer.Abstractions.DTO;

namespace ServiceLayer.Validations.BookValidations
{
    public class BookValidator : AbstractValidator<BookAddDto>
    {

        public BookValidator()
        {

            RuleFor(bookAddDto => bookAddDto.Description)
                .NotEmpty();

            RuleFor(bookAddDto => bookAddDto.Publisher)
                .NotEmpty();

            RuleFor(bookAddDto => bookAddDto.Price)
                .NotEmpty()
                .When(bookAddDto => bookAddDto.Price > 0);


            RuleFor(bookAddDto => bookAddDto.ImageUrl)
                .NotEmpty();

            RuleFor(bookAddDto => bookAddDto.WebUrl)
                .NotEmpty();

            RuleFor(bookAddDto => bookAddDto.Count)
                .NotEmpty()
                .When(bookAddDto => bookAddDto.Count > 0);

            RuleFor(bookAddDto => bookAddDto.Title)
                .NotEmpty();

        }
    }
}
