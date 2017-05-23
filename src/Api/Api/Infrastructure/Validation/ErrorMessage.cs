using FluentValidation.Results;

namespace Api.Infrastructure.Validation
{
    public class ErrorMessage
    {
        public string Message { get; set; }
        public string Code { get; set; }

        public ErrorMessage(ValidationFailure validationFailure)
        {
            Message = validationFailure.ErrorMessage;
            Code = validationFailure.ErrorCode;
        }
    }
}