using BookStore.Core.Results;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace BookStore.Bussiness.Extensions
{
    public static class FluentValidationExtension
    {
        [Obsolete("No need to use it, system will automatically catch faulty thanks to the validation filter")]
        public static List<CustomValidationError> ConvertToCustomValidationErrors(this ValidationResult validationResult)
        {
            List<CustomValidationError> customValidationErrors = new();
            foreach (var error in validationResult.Errors)
            {
                customValidationErrors.Add(new CustomValidationError
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                });
            }
            return customValidationErrors;
        }
    }
}
