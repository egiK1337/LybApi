namespace ServiceLayer.Abstractions
{
    public class Pagination
    {
        public const int DefaultPageSize = 20;

        //public int[] PageSizes =
        //    new[] { DefaultPageSize, 5, 20, 50, 100, 500, 1000 };

        public int NumPages { get; private set; }


        public int PageNum
        {
            get { return _pageNum; }
            set { _pageNum = value; }
        }

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value < DefaultPageSize && value > 0 ? value : DefaultPageSize; }
            //set { _pageSize = PageSizes.Any(x => x == value) == true ? value : DefaultPageSize; }
        }

        private int _pageNum = 1;

        private int _pageSize = DefaultPageSize;

        public Pagination()
        {

        }

        public void SetupPagination<T>(IQueryable<T> query)
        {
            NumPages = (int)Math.Ceiling(
                (double)query.Count() / PageSize);
            PageNum = Math.Min(
                Math.Max(1, PageNum), NumPages);
        }
    }
}

