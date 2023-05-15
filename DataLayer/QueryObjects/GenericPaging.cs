namespace ServiceLayer
{
    public static class GenericPaging
    {
        public static IQueryable<T> Paginate<T>(
            this IQueryable<T> query,
            int pageNumZeroStart,
            int pageSize)
        {
            if (pageSize == 0)
                throw new ArgumentOutOfRangeException
                    (nameof(pageSize), "pageSize cannot be zero.");

            if (pageNumZeroStart < 0)
                throw new ArgumentOutOfRangeException
                    (nameof(pageNumZeroStart), "pageNumZeroStart cannot be negative.");

            if (pageNumZeroStart != 0)
                query = query
                    .Skip(pageNumZeroStart * pageSize);

            return query.Take(pageSize);
        }
    }
}

