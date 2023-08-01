using System.Collections.Generic;

namespace BookStore.Core.Results
{

    public sealed class Result : ResultBase
    {
        public static Result Success()
        {
            return new Result
            {
                IsSuccess = true,
            };
        }
        public static Result Success(string message)
        {
            return new Result
            {
                IsSuccess = true,
                Message = message
            };
        }
        public static Result Failure(string message)
        {
            return new Result
            {
                IsSuccess = false,
                Message = message
            };
        }
        public static Result Failure(string message, List<CustomValidationError> validationErrors)
        {
            return new Result
            {
                IsSuccess = false,
                Message = message,
                ValidationErrors = validationErrors
            };
        }
    }
}
