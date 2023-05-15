namespace ServiceLayer.BookServices.QueryObjects
{
    static public class BookListDtoFilter
    {
        static public IQueryable<Book> FilterBooksBy(
            this IQueryable<Book> books,
            BooksFilter booksFilter)
        {
            var predicate = PredicateBuilder.New<Book>(true);

            //TODO add filter validation

            if (booksFilter != null)
            {
                if (booksFilter.DatePublishedFrom != null && booksFilter.DatePublishedFrom != null)
                    predicate = predicate.And(x => x.PublishedOn >= booksFilter.DatePublishedFrom);

                if (booksFilter.DatePublishedTo != null && booksFilter.DatePublishedTo != null)
                    predicate = predicate.And(x => x.PublishedOn <= booksFilter.DatePublishedTo);

                if (booksFilter.Tags != null && booksFilter.Tags.Any())
                {
                    //predicate = predicate.And(
                    //    x => booksFilter.Tags.Any(y => x.Tags.Select(z => z.Id).Contains(y)));
                    foreach (var tag in booksFilter.Tags)
                    {
                        predicate = predicate.Or(x => x.Tags.Select(z => z.Id).Contains(tag));
                    }
                }


                if (booksFilter.Titles != null && booksFilter.Titles.Any())
                    predicate = predicate.And(x => booksFilter.Titles.Contains(x.Title));
            }

            return books.Where(predicate);

        }
    }
}


