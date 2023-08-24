using FluentValidation.Results;
using Newtonsoft.Json;
using ServiceLayer.Abstractions.DTO;

namespace ServiceLayer.Abstractions.ReturnResult
{
    public class ReturnResult<TDto> where TDto : IDto
    {
        //[JsonProperty("Model", NullValueHandling = NullValueHandling.Ignore)]
        public TDto Model { get; set; }

        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public List<FluentError> Errors { get; set; } = new List<FluentError>();

        public ReturnResult()
        {

        }

        public ReturnResult(TDto dto, List<ValidationFailure> validationFailures = default)
        {
            if (validationFailures != default)
            {
                foreach (var failure in validationFailures)
                {
                    Errors.Add(new FluentError()
                    {
                        ErrorCode = failure.ErrorCode,
                        ErrorMessage = failure.ErrorMessage,
                        PropertyName = failure.PropertyName
                    });
                }
            }
            Model = dto;
        }
    }
}

