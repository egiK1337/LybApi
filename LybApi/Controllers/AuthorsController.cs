using DataLayer.EfCode;
using LybApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Abstractions;
using ServiceLayer.Abstractions.DTO;
using ServiceLayer.Abstractions.Filter;
using ServiceLayer.Abstractions.ReturnResult;
using ServiceLayer.AuthorServices.Concrete;

namespace LybApi.Controllers;


public class AuthorsController : BaseController
{
    //todo AuthorService
    private readonly AuthorListServices _authorListService;

    private readonly AuthorEditServices _authorEditService;

    private readonly AuthorAddServices _authorAddService;

    //to do delete
    private readonly EfCoreContext _context;

    public AuthorsController(EfCoreContext dbContext) : base()
    {
        _authorListService = new AuthorListServices(dbContext);
        _authorEditService = new AuthorEditServices(dbContext);
        _authorAddService = new AuthorAddServices(dbContext);
    }


    [HttpGet]
    [Route("AuthorList")]
    public List<AuthorsListDto> AuthorList(Pagination pagenation)
    {
        return _authorListService.List(pagenation);
    }

    [HttpGet]
    [Route("AuthorGetById/{authorId:int}")]
    public AuthorDto AuthorGetById(int authorId)
    {
        return _authorListService.GetById(authorId);
    }

    [HttpPost]
    [Route("AuthorQuery")]
    public List<AuthorsListDto> AuthorQuery([FromBody] AuthorFilterDto authorFilterDto, Pagination pagenation)
    {
        return _authorListService.Query(authorFilterDto, pagenation);
    }

    [HttpPost]
    [Route("AuthorAdd")]
    public ReturnResult<AuthorDto> AuthorAdd(AuthorDto authorDto)
    {
        return _authorAddService.Add(authorDto);
    }

    [HttpPost]
    [Route("AuthorEdit")]
    public ReturnResult<AuthorDto> AuthorEdit(AuthorDto authorDto)
    {
        return _authorEditService.Edit(authorDto);
    }
}