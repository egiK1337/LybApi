using DataLayer.EfClasses;
using DataLayer.EfCode;
using LinqKit;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Abstractions;
using ServiceLayer.Abstractions.DTO;
using ServiceLayer.Abstractions.DTO.Author;
using ServiceLayer.Abstractions.Filter;
using ServiceLayer.AuthorServices.AuthorServices;
using ServiceLayer.AuthorServices.QueryObjects;
using ServiceLayer.BookServices.Concrete;
using ServiceLayer.BookServices.QueryObjects;
using System.Drawing.Printing;
using System.Linq;

namespace ServiceLayer.AuthorServices.Concrete
{
    public class AuthorListServices
    {
        private readonly EfCoreContext _context;

        public AuthorListServices(EfCoreContext context)
        {
            _context = context;
        }

        public List<AuthorsListDto> List(PageDto pageDto)
        {
            // задать вопрос
            //int authorCount = _dbContex.Authors.Count();

            Pagination pagination = new Pagination()
            {
                //PageNum = pageDto.PageNum,
                PageSize = pageDto.PageSize
                //NumPages = _context.Authors.Count() / pageDto.PageSize
            };

            if (pagination == null)
            {
                throw new ArgumentNullException("Пагинация не задана");
            }
            //if (pagenation.PageNumber < 0)
            //{
            //    throw new ArgumentNullException("Некоректный номер страницы");
            //}

            var a = _context.Authors.DefaultOrder<Author>()
                .Paginate(pagination)
                .Select(author => new AuthorsListDto
                {
                    Id = author.Id,
                    Name = author.Name,
                    WebUrl = author.WebUrl
                }).ToList();

            return a;
        }

        public AuthorDto GetById(int authorId)
        {
            var authors = _context.Authors.Where(a => a.Id == authorId).Select(author => new AuthorDto
            {
                Name = author.Name,
                WebUrl = author.WebUrl
            }).FirstOrDefault();

            if (authors != null)
            {
                return authors;
            }

            throw new Exception("Такого автора нет");
        }


        //public List<AuthorsListDto> Query([FromBody] AuthorFilterDto authorFilterDto)
        //{
        //    Pagination pagination = new Pagination()
        //    {
        //        PageNum = authorFilterDto.Page.PageNum,
        //        PageSize = authorFilterDto.Page.PageSize
        //    };

        //    var predicate = PredicateBuilder.New<Author>(true);

        //    if (authorFilterDto.FirstName != null)
        //    {
        //        predicate.And(a => a.Name.Replace(" ", "").ToUpper().Contains(authorFilterDto.FirstName.Replace(" ", "").ToUpper()));
        //    }
        //    if (authorFilterDto.WebUrl != null)
        //    {
        //        predicate.And(a => a.WebUrl.Replace(" ", "").ToUpper().Contains(authorFilterDto.WebUrl.Replace(" ", "").ToUpper()));
        //    }

        //    var a = _context.Authors
        //        .Where(predicate)
        //        .Paginate(pagination)                
        //        .Select(author => new AuthorsListDto
        //        {
        //            Id = author.Id,
        //            Name = author.Name,
        //            WebUrl = author.WebUrl
        //        }).ToList();
        //    return a;
        //}

        public PagedDto<AuthorsListDto> Query(AuthorSortFilterPageOption filterPageOptions)
        {
            var service = new AuthorListServices(_context);

            var items = service.SortFilterPage(filterPageOptions);

            return new PagedDto<AuthorsListDto>(
                items,
                filterPageOptions.PageNum,
                filterPageOptions.NumPages);
        }

        public IQueryable<AuthorsListDto> SortFilterPage(AuthorSortFilterPageOption options)
        {
            {
                var authorsQuery = _context.Authors
                                .FilterAuthorsBy(options.Filter)
                                .MapAuthorToDto()
                                .OrderAuthorsBy(options.OrderByOptions);

                return authorsQuery.Paginate(options);
            }
        }
    }
}
