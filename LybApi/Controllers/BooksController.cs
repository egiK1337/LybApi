using DataLayer.EfCode;
using LybApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Abstractions;
using ServiceLayer.Abstractions.DTO;
using ServiceLayer.Abstractions.ReturnResult;
using ServiceLayer.AuthorServices.Concrete;
using ServiceLayer.BookServices.Concrete;

namespace LybApi.Controllers;

//[ApiController]
//[Route("[controller]")]
public class BooksController : BaseController
{
    private readonly BookAddService _bookAddService;

    private readonly BookListService _bookListService;

    private readonly BookEditService _bookEditService;

    //private readonly EfCoreContext _context;

    public BooksController(EfCoreContext context)
    {
        _bookAddService = new BookAddService(context);
        _bookListService = new BookListService(context);
        _bookEditService = new BookEditService(context);
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
    public ReturnResult<BookDto> BookAdd([FromBody] BookDto bookAddDto)
    {
        return _bookAddService.Add(bookAddDto);
    }

    [HttpPost]
    [Route("BookEdit")]
    public ReturnResult<BookDto> Edit([FromBody] BookDto bookAddDto)
    {
        return _bookEditService.Edit(bookAddDto);
    }


}


