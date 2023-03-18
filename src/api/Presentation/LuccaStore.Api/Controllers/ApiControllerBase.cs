using FluentValidation.Results;
using LuccaStore.Core.Domain;
using LuccaStore.Core.Domain.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LuccaStore.Api.Controllers
{
    [Produces("application/json", new string[] { })]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ApiControllerBase : ControllerBase
    {
        protected virtual ActionResult ValidationFailure(ValidationResult validation)
        {
            var listErrors = new List<ValidationErro>();

            foreach (var erro in validation.Errors)
            {
                listErrors.Add(new ValidationErro
                {
                    Property = erro.PropertyName,
                    Message = erro.ErrorMessage
                });
            }

            var apiErrorResponse = new ApiErrorResponse
            {
                Error = MessageTemplate.ValidationError,
                Message = MessageTemplate.ValidationErrorMessage,
                ValidationErrors = listErrors
            };

            return BadRequest(apiErrorResponse);
        }

        protected virtual ActionResult ErrorResponse(string? error, string? message)
        {
            var errorResponse = new ApiErrorResponse { Error = error, Message = message };

            return BadRequest(errorResponse);
        }
    }
}
