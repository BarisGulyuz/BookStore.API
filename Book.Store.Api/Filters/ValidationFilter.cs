using BookStore.Core.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Store.Api.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                KeyValuePair<string, IEnumerable<string>>[] errors = context.ModelState
                                                                    .Where(x => x.Value.Errors.Any())
                                                                    .ToDictionary(e => e.Key, e => e.Value.Errors.Select(e => e.ErrorMessage))
                                                                    .ToArray();

                Result validationResult = PrepareResult(errors);
                context.Result = new BadRequestObjectResult(validationResult);
                return;
            }

            await next();
        }

        private Result PrepareResult(KeyValuePair<string, IEnumerable<string>>[] errors)
        {
            List<CustomValidationError> validationErrors = new List<CustomValidationError>();
            foreach (var errorData in errors)
            {
                foreach (var errorValue in errorData.Value)
                {
                    validationErrors.Add(new CustomValidationError(errorData.Key, errorValue));
                }
            }

            return Result.Failure("Validation Error", validationErrors);
        }
    }
}
