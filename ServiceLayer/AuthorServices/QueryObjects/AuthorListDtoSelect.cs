using DataLayer.EfClasses;
using ServiceLayer.Abstractions.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.AuthorServices.QueryObjects
{
    static public class AuthorListDtoSelect
    {
        //Паттерн объект-запрос
        static public IQueryable<AuthorsListDto> MapAuthorToDto(this IQueryable<Author> authors)
        {
            return authors.Select(author => new AuthorsListDto
            {
                Id = author.Id,
                Name = author.Name,
                WebUrl = author.WebUrl
            });
        }
    }
}
