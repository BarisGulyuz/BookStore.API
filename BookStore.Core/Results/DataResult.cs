using System.Collections.Generic;

namespace BookStore.Core.Results
{
    public sealed class DataResult<T> : ResultBase
    {
        public T Data { get; set; } = default!;
        public static DataResult<T> Success(T data)
        {
            return new DataResult<T>
            {
                IsSuccess = true,
                Data = data
            };
        }
        public static DataResult<T> Success(T data, string message)
        {
            return new DataResult<T>
            {
                IsSuccess = true,
                Data = data,
                Message = message
            };
        }
        public static DataResult<T> Failure(string message)
        {
            return new DataResult<T>
            {
                IsSuccess = false,
                Message = message
            };
        }
        public static DataResult<T> Failure(string message, List<CustomValidationError> validationErrors)
        {
            return new DataResult<T>
            {
                IsSuccess = false,
                Message = message,
                ValidationErrors = validationErrors
            };
        }
    }
}
