using DataLayer.EfClasses;
using DataLayer.EfCode;
using FluentValidation;
using FluentValidation.Results;
using ServiceLayer.Abstractions.DTO;
using ServiceLayer.Abstractions.ReturnResult;
using ServiceLayer.Validations.BookValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.BookServices.Concrete
{
    public class BookEditService
    {
        private readonly EfCoreContext _context;

        BookValidator validator = new BookValidator();

        public BookEditService(EfCoreContext context)
        {
            _context = context;
        }

        public ReturnResult<BookDto> Edit(BookDto bookDto)
        {
            ValidationResult result = validator.Validate(bookDto);

            List<string> errors = new List<string>();

            foreach (var item in result.Errors)
            {
                errors.Add(item.ToString());
            }

            if (result.IsValid)
            {
                return new ReturnResult<BookDto>(bookDto);
            }

            var book = _context.Books.Where(b => b.Title.ToUpper() == bookDto.Title.ToUpper()).FirstOrDefault();

            if (book == null)
            {
                throw new ValidationException("This book is not in the database");
            }

            book.Title = bookDto.Title;
            book.Price = bookDto.Price;
            book.Description = bookDto.Description;
            book.PublishedOn = bookDto.PublishedOn;
            book.Publisher = bookDto.Publisher;
            book.ImageUrl = bookDto.ImageUrl;
            book.Count = bookDto.Count;
            //book.WebUrl = bookDto.WebUrl;


            _context.SaveChanges();

            return new();
        }
    }
}
