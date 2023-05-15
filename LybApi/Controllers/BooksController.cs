using DataLayer.EfCode;
using LybApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Abstractions;
using ServiceLayer.Abstractions.DTO;
using ServiceLayer.Abstractions.Filter;
using ServiceLayer.BookServices.Concrete;

namespace LybApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : BaseController
{


    private readonly EfCoreContext _context;



    [HttpPost]
    [Route("BooksList")]
    public List<BookListDto> BooksList([FromBody] Pagination pagenation)
    {
        var bookListService = new BookListService(_context);

        return bookListService.List(pagenation);
    }

    [HttpGet]
    [Route("BookGetById/{bookId:int}")]
    public BookDto BookGetById(int bookId)
    {
        var bookListService = new BookListService(_context);

        return bookListService.GetById(bookId);
    }

    [HttpPost]
    [Route("BooksQuery")]
    public List<BookListDto> BooksQuery(BooksFilter bookFilter, Pagination pagenation)
    {
        var bookListService = new BookListService(_context);
        return bookListService.Query(bookFilter, pagenation);
    }

    [HttpPost]
    [Route("BookAdd")]
    public ReturnBookResult Add(BookAddDto bookAddDto)
    {
        var bookAddService = new BookAddService(_context);
        return bookAddService.Add(bookAddDto);
    }

}


