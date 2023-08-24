using ServiceLayer.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public static class GenericOrder
    {
        //toDo
        public static IQueryable<T> DefaultOrder<T>(
             this IQueryable<T> query) where T : IEntity
        {
            return query.OrderBy(x => x.Id);
        }
    }
}
