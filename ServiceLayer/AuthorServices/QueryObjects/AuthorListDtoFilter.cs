using DataLayer.EfClasses;
using LinqKit;
using ServiceLayer.Abstractions.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.AuthorServices.AuthorServices
{
    static public class AuthorListDtoFilter
    {
        static public IQueryable<Author> FilterAuthorsBy(
                        this IQueryable<Author> authors,
                        AuthorFilterDto authorsFilter)
        {
            var predicate = PredicateBuilder.New<Author>(true);

            //TODO add filter validation

            if (authorsFilter != null)
            {
                if (authorsFilter.FirstName != null)
                    predicate = predicate.And(x => x.Name == authorsFilter.FirstName);

                if (authorsFilter.WebUrl != null)
                    predicate = predicate.And(x => x.WebUrl == authorsFilter.WebUrl);
            }

            return authors.Where(predicate);
        }
    }
}
