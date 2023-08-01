using System.Collections.Generic;

namespace BookStore.Core.Results
{
    public abstract class ResultBase
    {
        public ResultBase()
        {
            IsSuccess = true;
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<CustomValidationError> ValidationErrors { get; set; } = new List<CustomValidationError>();

        public void SetError(string message)
        {
            IsSuccess = false;
            Message = message;
        }
    }

    public sealed class CustomValidationError
    {
        public CustomValidationError()
        {

        }
        public CustomValidationError(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }

        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}
