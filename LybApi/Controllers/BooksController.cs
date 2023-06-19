using DataLayer.EfCode;
using LybApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Abstractions;
using ServiceLayer.Abstractions.DTO;
using ServiceLayer.Abstractions.ReturnResult;
using ServiceLayer.BookServices.Concrete;

namespace LybApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : BaseController
{
    private readonly BookAddService _bookAddService;

    private readonly BookListService _bookListService;

    //private readonly EfCoreContext _context;

    public BooksController(EfCoreContext context)
    {
        _bookAddService = new BookAddService(context);
        _bookListService = new BookListService(context);
    }

    [HttpPost]
    [Route("BooksList")]
    public List<BookListDto> BooksList([FromBody] Pagination pagenation)
    {
        return _bookListService.List(pagenation);
    }

    [HttpGet]
    [Route("BookGetById/{bookId:int}")]
    public BookDto BookGetById(int bookId)
    {
        return _bookListService.GetById(bookId);
    }

    [HttpPost]
    [Route("BooksQuery")]
    public PagedDto<BookListDto> BooksQuery(SortFilterPageOptions filterPageOptions)
    {
        return _bookListService.Query(filterPageOptions);
    }

    [HttpPost]
    [Route("BookAdd")]
    public ReturnBookResult Add(BookAddDto bookAddDto)
    {
        return _bookAddService.Add(bookAddDto);
    }

}


