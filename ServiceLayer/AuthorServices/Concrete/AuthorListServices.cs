using DataLayer.EfCode;
using LinqKit;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Abstractions;
using ServiceLayer.Abstractions.DTO;
using ServiceLayer.Abstractions.Filter;

namespace ServiceLayer.AuthorServices.Concrete
{
    public class AuthorListServices
    {
        private readonly EfCoreContext _context;

        public AuthorListServices(EfCoreContext context)
        {
            _context = context;
        }

        public List<AuthorsListDto> List(Pagination pagenation)
        {
            // задать вопрос
            //int authorCount = _dbContex.Authors.Count();

            if (pagenation == null)
            {
                throw new ArgumentNullException("Пагинация не задана");
            }
            //if (pagenation.PageNumber < 0)
            //{
            //    throw new ArgumentNullException("Некоректный номер страницы");
            //}

            return _context.Authors
                .Paginate(pagenation)
                .Select(author => new AuthorsListDto
                {
                    Name = author.Name,
                    WebUrl = author.WebUrl
                }).ToList();
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


        public List<AuthorsListDto> Query([FromBody] AuthorFilterDto authorFilterDto, Pagination pagenation)
        {
            var predicate = PredicateBuilder.New<DataLayer.EfClasses.Author>(true);

            if (authorFilterDto.FirstName != null)
            {
                predicate.And(a => a.Name.Replace(" ", "").ToUpper().Contains(authorFilterDto.FirstName.Replace(" ", "").ToUpper()));
            }
            if (authorFilterDto.WebUrl != null)
            {
                predicate.And(a => a.WebUrl.Replace(" ", "").ToUpper().Contains(authorFilterDto.WebUrl.Replace(" ", "").ToUpper()));
            }

            return _context.Authors
                .Paginate(pagenation)
                .Where(predicate)
                .Select(author => new AuthorsListDto
                {
                    Name = author.Name,
                    WebUrl = author.WebUrl
                }).ToList();
        }
    }
}
