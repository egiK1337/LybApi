namespace ServiceLayer.BookServices.QueryObjects
{
    public static class BookListDtoSelect
    {
        //Паттерн объект-запрос
        static public IQueryable<BookListDto> MapBookToDto(this IQueryable<Book> books)
        {
            return books.Select(book => new BookListDto
            {
                Id = book.Id,
                Title = book.Title,
                PublishedOn = book.PublishedOn,
                ActualPrice = book.Promotion == null
                    ? book.Price
                    : book.Promotion.NewPrice,
                PromotionPromotionalText = book.Promotion == null
                    ? ""
                    : book.Promotion.PromotionalText,
                AuthorsOrdered = string.Join(',',
                    book.Authors
                        .OrderBy(ba => ba.Order)
                        .Where(ba => ba.Author != null)
                        .Select(ba => ba.Author.Name)),
                ReviewsCount = book.Reviews.Count,
                ReviewsAverageVotes =
                    book.Reviews.Select(review =>
                        (double?)review.NumStars).Average(),
                TagStrings = book.Tags.Select(tag => tag.Id).ToArray()
            });
        }
    }
}


