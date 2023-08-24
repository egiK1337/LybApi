using ServiceLayer.Abstractions.DTO;
using ServiceLayer.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Abstractions.Sortings.Authors;

namespace ServiceLayer.AuthorServices.QueryObjects
{
    static class AuthorListDtoSort
    {
        static public IQueryable<AuthorsListDto> OrderAuthorsBy(
                 this IQueryable<AuthorsListDto> authors,
                      AuthorOrderByOption orderByOptions)
        {
            switch (orderByOptions)
            {
            case AuthorOrderByOption.SimpleOrder:
                  return authors.OrderByDescending(x => x.Id);
            case AuthorOrderByOption.Name:
                  return authors.OrderByDescending(x => x.Name);
            case AuthorOrderByOption.WebUrl:
                  return authors.OrderByDescending(x => x.WebUrl);
            default:
                  throw new ArgumentOutOfRangeException(
                         nameof(orderByOptions),
                         orderByOptions,
                         null);
            }
        }
    }
}
