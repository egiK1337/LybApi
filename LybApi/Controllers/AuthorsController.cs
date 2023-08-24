using DataLayer.EfCode;
using LybApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Abstractions;
using ServiceLayer.Abstractions.DTO;
using ServiceLayer.Abstractions.DTO.Author;
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
    public List<AuthorsListDto> AuthorList(PageDto pageDto)
    {
        return _authorListService.List(pageDto);
    }

    [HttpGet]
    [Route("AuthorGetById/{authorId:int}")]
    public AuthorDto AuthorGetById(int authorId)
    {
        return _authorListService.GetById(authorId);
    }

    [HttpPost]
    [Route("AuthorQuery")]
    public PagedDto<AuthorsListDto> AuthorQuery([FromBody] AuthorSortFilterPageOption filterPageOptions)
    {
        return _authorListService.Query(filterPageOptions);
    }

    [HttpPost]
    [Route("AuthorAdd")]
    public ReturnResult<AuthorDto> AuthorAdd([FromBody] AuthorDto authorDto)
    {
        return _authorAddService.Add(authorDto);
    }

    [HttpPost]
    [Route("AuthorEdit")]
    public ReturnResult<AuthorDto> AuthorEdit([FromBody] AuthorDto authorDto)
    {
        return _authorEditService.Edit(authorDto);
    }
}