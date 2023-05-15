using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Abstractions
{
    public class ReturnAuthorResult
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string WebUrl { get; set; }

        public ValidationResult Value { get; set; }

        public ReturnAuthorResult(int authorID)
        {
            AuthorId = authorID;
        }

        public ReturnAuthorResult(ValidationResult value)
        {
            Value = value;
        }

        public ReturnAuthorResult(string name, string webUrl)
        {
            Name = name;
            WebUrl = webUrl;
        }

        public ReturnAuthorResult()
        {

        }
    }
}
