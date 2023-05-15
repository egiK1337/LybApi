namespace ServiceLayer
{
    public static class GenericPaging
    {
        public static IQueryable<T> Paginate<T>(
            this IQueryable<T> query,
            Pagination pagination)
        {
            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination), "pagination cannot be null");

            pagination.SetupPagination(query);

            return query.Paginate(
                pageNumZeroStart:
                pagination.PageNum == 0 ?
                    0 :
                    pagination.PageNum - 1,
                pageSize: pagination.PageSize);
        }
    }
}


