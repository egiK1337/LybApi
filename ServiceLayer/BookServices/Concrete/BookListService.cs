using DataLayer.EfCode;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Abstractions;
using ServiceLayer.Abstractions.DTO;
using ServiceLayer.BookServices.QueryObjects;

namespace ServiceLayer.BookServices.Concrete
{
    public class BookListService : ControllerBase
    {
        private readonly EfCoreContext _context;

        public BookListService(EfCoreContext context)
        {
            _context = context;
        }


        //check it  . i deleted .AsNoTracking()

        public IQueryable<BookListDto> SortFilterPage(SortFilterPageOptions options)
        {
            var booksQuery = _context.Books
                            .FilterBooksBy(options.Filter)
                            .MapBookToDto()
                            .OrderBooksBy(options.OrderByOptions);

            return booksQuery.Paginate(options);
        }

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

        public PagedDto<BookListDto> Query(SortFilterPageOptions filterPageOptions)
        {
            var service = new BookListService(_context);

            var items = service.SortFilterPage(filterPageOptions);

            return new PagedDto<BookListDto>(
                items,
                filterPageOptions.PageNum,
                filterPageOptions.NumPages);
        }

        //public List<BookListDto> Query(SortFilterPageOptions filterPageOptions)
        //{
        //    List<string> errors = new();

        //    if (filterPageOptions.Filter?.HighPrice < filterPageOptions.Filter?.LowPrice)
        //    {
        //        errors.Add("Максимальная цена меньше минимальной; ");
        //    }
        //    if (filterPageOptions.Filter?.HighPrice < 0 || filterPageOptions.Filter?.LowPrice < 0)
        //    {
        //        errors.Add("Минимальная или максимальная цена указана ниже нуля; ");
        //    }

        //    string message = "Список ошибок: ";

        //    if (errors.Count > 0)
        //    {
        //        foreach (var error in errors)
        //        {
        //            message += error;
        //        }
        //        throw new Exception(message);
        //    }

        //    var predicate = PredicateBuilder.New<Book>(true);

        //    //predicate условия суммируются это значи, что опертор .And (.Or) добавляет к предедущему условию новое и ряд условий растёт.

        //    if (filterPageOptions.Filter.Titles != null)
        //    {
        //        predicate = predicate.And(i => filterPageOptions.Filter.Titles.Contains(i.Title));
        //    }
        //    if (filterPageOptions.Filter.LowPrice > 0)
        //    {
        //        predicate = predicate.And(i => i.Price >= filterPageOptions.Filter.LowPrice);
        //    }
        //    if (filterPageOptions.Filter.HighPrice > 0)
        //    {
        //        predicate = predicate.And(i => i.Price <= filterPageOptions.Filter.HighPrice);
        //    }

        //    return _context.Books
        //        .Paginate(filterPageOptions)
        //        .Where(predicate)
        //        .Select(book => new BookListDto
        //        {
        //            Description = book.Description,
        //            ImageUrl = book.ImageUrl,
        //            Price = book.Price,
        //            PublishedOn = book.PublishedOn,
        //            Publisher = book.Publisher,
        //            Title = book.Title,
        //            Count = book.Count,
        //            Id = book.Id
        //        }).ToList();
        //}


    }



}

