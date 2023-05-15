using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Abstractions

{
    public class ReturnBookResult
    {
        public int BookId { get; set; }
        public string Message { get; set; }

        public ValidationResult Value { get; set; }

        public ReturnBookResult(int bookId, string message)
        {
            BookId = bookId;
            Message = message;

        }
        public ReturnBookResult(string message, ValidationResult value)
        {
            Message = message;
            Value = value;
        }
        public ReturnBookResult()
        {

        }
    }
}
