using DataLayer.EfCode;
using LybApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Abstractions;
using ServiceLayer.Abstractions.DTO;
using ServiceLayer.Abstractions.Filter;
using ServiceLayer.AuthorServices.Concrete;

namespace LybApi.Controllers;


public class AuthorsController : BaseController
{
    //private readonly AuthorsLogic _authorsLogic;

    //public AuthorsController(AppDbContext dbContext) : base()
    //{
    //    _authorsLogic = new AuthorsLogic(dbContext);
    //}

    private readonly EfCoreContext _context;

    [HttpGet]
    [Route("AuthorList")]
    public List<AuthorsListDto> AuthorList(Pagination pagenation)
    {
        var authorListServices = new AuthorListServices(_context);
        return authorListServices.List(pagenation);
    }

    [HttpGet]
    [Route("AuthorGetById/{authorId:int}")]
    public AuthorDto AuthorGetById(int authorId)
    {
        var authorListServices = new AuthorListServices(_context);
        return authorListServices.GetById(authorId);
    }

    [HttpPost]
    [Route("AuthorQuery")]
    public List<AuthorsListDto> AuthorQuery([FromBody] AuthorFilterDto authorFilterDto, Pagination pagenation)
    {
        var authorListServices = new AuthorListServices(_context);
        return authorListServices.Query(authorFilterDto, pagenation);
    }



    [HttpPost]
    [Route("AuthorAdd")]
    public ReturnAuthorResult AuthorAdd(AuthorDto authorDto)
    {
        var authorAddServices = new AuthorAddServices(_context);
        return authorAddServices.Add(authorDto);
    }

    [HttpPost]
    [Route("AuthorEdit")]
    public ReturnAuthorResult AuthorEdit(AuthorDto authorDto)
    {
        var authoreEditServices = new AuthorEditServices(_context);
        return authoreEditServices.Edit(authorDto);
    }
}