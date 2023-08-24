using DataLayer.EfClasses;
using DataLayer.EfCode;
using FluentValidation;
using FluentValidation.Results;
using ServiceLayer.Abstractions.DTO;
using ServiceLayer.Abstractions.ReturnResult;
using ServiceLayer.Validations.BookValidations;


namespace ServiceLayer.BookServices.Concrete
{
    public class BookAddService
    {
        private readonly EfCoreContext _context;

        public BookAddService(EfCoreContext context)
        {
            _context = context;
        }

        BookValidator validator = new BookValidator();

        public ReturnResult<BookDto> Add(BookDto bookAddDto)
        {

            ValidationResult result = validator.Validate(bookAddDto);

            List<string> errors = new List<string>();

            foreach (var item in result.Errors)
            {
                errors.Add(item.ToString());
            }

            if (!result.IsValid)
            {
                return new ReturnResult<BookDto>(bookAddDto, result.Errors);
            }


            var bookInDb = _context.Books
                .Where(
                    b => b.Title.ToLower() == bookAddDto.Title.ToLower())
                .FirstOrDefault();

            if (bookInDb != null)
            {

                throw new ValidationException("Such a book is in the database");
            }

            var newBook = new Book()
            {
                Authors = new List<BookAuthor>(),
                Publisher = bookAddDto.Publisher,
                PublishedOn = bookAddDto.PublishedOn,
                Price = bookAddDto.Price,
                ImageUrl = bookAddDto.ImageUrl,
                Description = bookAddDto.Description,
                Count = bookAddDto.Count,
                Title = bookAddDto.Title
            };

            foreach (var author in bookAddDto.Authors)
            {
                var authorInDb = _context.Authors
                    .Where(a => a.Name.ToLower() == author.Name.ToLower())
                    .FirstOrDefault();

                if (authorInDb != null)
                {
                    newBook.Authors.Add(new BookAuthor
                    {
                        AuthorId = authorInDb.Id
                    });
                }
                else
                {
                    newBook.Authors.Add(new BookAuthor
                    {
                        Author = new Author()
                        {
                            Name = author.Name,
                            WebUrl = author.WebUrl
                        }
                    });
                }
            };

            _context.Books.Add(newBook);
            _context.SaveChanges();

            return new ReturnResult<BookDto>(bookAddDto);
        }

    }
}

