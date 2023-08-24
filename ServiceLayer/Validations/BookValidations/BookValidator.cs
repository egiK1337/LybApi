using FluentValidation;
using ServiceLayer.Abstractions.DTO;

namespace ServiceLayer.Validations.BookValidations
{
    public class BookValidator : AbstractValidator<BookDto>
    {

        public BookValidator()
        {

            RuleFor(bookDto => bookDto.Description)
                .NotEmpty();

            RuleFor(bookDto => bookDto.Publisher)
                .NotEmpty();

            RuleFor(bookDto => bookDto.Price)
                .NotEmpty()
                .When(bookDto => bookDto.Price > 0);

            RuleFor(bookDto => bookDto.ImageUrl)
                .NotEmpty();

            //RuleFor(bookDto => bookDto.WebUrl)
            //    .NotEmpty();

            RuleFor(bookDto => bookDto.Count)
                .NotEmpty()
                .When(bookDto => bookDto.Count > 0);

            RuleFor(bookDto => bookDto.Title)
                .NotEmpty();

            RuleFor(bookDto => bookDto.Authors)
                .NotEmpty();

        }
    }
}
