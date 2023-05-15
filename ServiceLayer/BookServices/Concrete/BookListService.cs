namespace ServiceLayer.BookServices.Concrete
{
    public class BookListService : ControllerBase
    {
        private readonly EfCoreContext _context;

        public BookListService(EfCoreContext context)
        {
            _context = context;
        }

        //public IQueryable<BookListDto> GetBookList()
        //{
        //    return _context.Books.MapBookToDto();
        //}

        //public IQueryable<BookListDto> SortFilterPage(SortFilterPageOptions options)
        //{
        //    var booksQuery = _context.Books
        //        .AsNoTracking()
        //        .FilterBooksBy(options.Filter)
        //        .MapBookToDto()
        //        .OrderBooksBy(options.OrderByOptions);

        //    return booksQuery.Paginate(options);

        //}
        public List<BookListDto> List(Pagination pagenation)
        {
            var result = _context.Books.Paginate(pagenation).ToList();

            return result.Select(book => new BookListDto
            {
                Description = book.Description,
                ImageUrl = book.ImageUrl,
                Price = book.Price,
                PublishedOn = book.PublishedOn,
                Publisher = book.Publisher,
                Title = book.Title,
                Id = book.Id,
                Count = book.Count
            }).ToList();
        }

        public BookDto GetById(int bookId)
        {
            var book = _context.Books.Where(id => id.Id == bookId).Select(book => new BookDto
            {
                Description = book.Description,
                ImageUrl = book.ImageUrl,
                Price = book.Price,
                PublishedOn = book.PublishedOn,
                Publisher = book.Publisher,
                Title = book.Title,
                Count = book.Count,
                Id = book.Id
            }).FirstOrDefault();

            if (book != null)
            {
                return book;
            }
            else
            {
                throw new Exception("Такой книги нет");
            }
        }


        public List<BookListDto> Query(BooksFilter bookFilter, Pagination pagenation)
        {
            List<string> errors = new();

            if (bookFilter?.HighPrice < bookFilter?.LowPrice)
            {
                errors.Add("Максимальная цена меньше минимальной; ");
            }
            if (bookFilter?.HighPrice < 0 || bookFilter?.LowPrice < 0)
            {
                errors.Add("Минимальная или максимальная цена указана ниже нуля; ");
            }

            string message = "Список ошибок: ";

            if (errors.Count > 0)
            {
                foreach (var error in errors)
                {
                    message += error;
                }
                throw new Exception(message);
            }

            var predicate = PredicateBuilder.New<Book>(true);

            //predicate условия суммируются это значи, что опертор .And (.Or) добавляет к предедущему условию новое и ряд условий растёт.

            if (bookFilter.Titles != null)
            {
                predicate = predicate.And(i => bookFilter.Titles.Contains(i.Title));
            }
            if (bookFilter.LowPrice > 0)
            {
                predicate = predicate.And(i => i.Price >= bookFilter.LowPrice);
            }
            if (bookFilter.HighPrice > 0)
            {
                predicate = predicate.And(i => i.Price <= bookFilter.HighPrice);
            }

            return _context.Books
                .Paginate(pagenation)
                .Where(predicate)
                .Select(book => new BookListDto
                {
                    Description = book.Description,
                    ImageUrl = book.ImageUrl,
                    Price = book.Price,
                    PublishedOn = book.PublishedOn,
                    Publisher = book.Publisher,
                    Title = book.Title,
                    Count = book.Count,
                    Id = book.Id
                }).ToList();
        }


    }



}

