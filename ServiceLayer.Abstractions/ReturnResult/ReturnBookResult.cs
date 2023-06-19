using FluentValidation.Results;

namespace ServiceLayer.Abstractions.ReturnResult

{
    public class ReturnBookResult
    {
        public int BookId { get; set; }

        public ValidationResult Errors { get; set; }

        public ReturnBookResult(int bookId)
        {
            BookId = bookId;
        }
        public ReturnBookResult(ValidationResult value)
        {
            Errors = value;
        }
        public ReturnBookResult()
        {

        }
    }
}
