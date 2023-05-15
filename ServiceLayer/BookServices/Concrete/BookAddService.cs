using System.ComponentModel.DataAnnotations;

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

        public ReturnBookResult Add(BookAddDto bookAddDto)
        {

            ValidationResult result = validator.Validate(bookAddDto);

            if (!result.IsValid)
            {
                return new ReturnBookResult("Not done", result);
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
                PublishedOn = bookAddDto.PublishedOn.Value,
                Price = bookAddDto.Price.Value,
                ImageUrl = bookAddDto.ImageUrl,
                Description = bookAddDto.Description,
                Count = bookAddDto.Count.Value,
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

            return new ReturnBookResult(newBook.Id, "Success");
        }

    }
}

