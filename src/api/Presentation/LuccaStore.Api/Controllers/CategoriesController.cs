using FluentValidation;
using LuccaStore.Api.Validators.Category;
using LuccaStore.Core.Application.Exceptions;
using LuccaStore.Core.Application.Interfaces;
using LuccaStore.Core.Domain.Common;
using LuccaStore.Core.Domain.Dtos.Categories;
using LuccaStore.Core.Domain.Dtos.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LuccaStore.Api.Controllers
{
    /// <summary>
    /// Categories endpoints.
    /// </summary>
    [Route("lucca-store-api/v1/categories")]
    [ApiController]
    public class CategoriesController : ApiControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Create new category.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="validator"></param>
        /// <returns>Returns new category details.</returns>
        /// <response code="200">Returns new category details.</response>
        /// <response code="400">Error message.</response>
        /// <response code="401">The unauthorized message.</response>
        /// <response code="500">The exception message.</response>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(typeof(CategoryResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<CategoryResponseDto>> CreateCategory(CategoryRequestDto request,
                                                                            [FromServices] CategoryRequestDtoValidator validator)
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return ValidationFailure(validationResult);
            }

            try
            {
                var result = await _categoryService.CreateCategoryAsync(request);

                return Ok(result);
            }
            catch (InvalidParametersException InvalidParametersExc)
            {
                return ErrorResponse(InvalidParametersExc.ErrorCode,
                                     InvalidParametersExc.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Delete a category.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="validator"></param>
        /// <returns>Returns the Id of the deleted category.</returns>
        /// <response code="200">Returns the Id of the deleted category.</response>
        /// <response code="400">Error message.</response>
        /// <response code="401">The unauthorized message.</response>
        /// <response code="500">The exception message.</response>
        [Authorize(Roles = "Admin")]
        [HttpDelete("{categoryId}")]
        [ProducesResponseType(typeof(CategoryResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<CategoryResponseDto>> DeleteCategory([FromRoute] Guid? categoryId,
                                                                            [FromServices] CategoryIdValidator validator)
        {
            var validationResult = validator.Validate((Guid)categoryId!);
            if (!validationResult.IsValid)
            {
                return ValidationFailure(validationResult);
            }

            try
            {
                var result = await _categoryService.DeleteCategoryAsync((Guid)categoryId!);

                return Ok(result);
            }
            catch (NotFoundException notFoundExc)
            {
                return ErrorResponse(notFoundExc.ErrorCode,
                                     notFoundExc.Message);
            }
            catch (InvalidParametersException InvalidParametersExc)
            {
                return ErrorResponse(InvalidParametersExc.ErrorCode,
                                     InvalidParametersExc.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Get all categories.
        /// </summary>
        /// <returns>Returns all the categories.</returns>
        /// <response code="200">Returns all the categories.</response>
        /// <response code="400">Error message.</response>
        /// <response code="401">The unauthorized message.</response>
        /// <response code="500">The exception message.</response>
        [Authorize(Roles = "User")]
        [HttpGet]
        [ProducesResponseType(typeof(CategoryResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<CategoryResponseDto>>> GetAllCategories()
        {
            try
            {
                var result = await _categoryService.GetAllCategoriesAsync();

                return Ok(result);
            }
            catch (NotFoundException notFoundExc)
            {
                return ErrorResponse(notFoundExc.ErrorCode,
                                     notFoundExc.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Get the category by its Id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="validator"></param>
        /// <returns>Returns a category details.</returns>
        /// <response code="200">Returns a category details.</response>
        /// <response code="400">Error message.</response>
        /// <response code="401">The unauthorized message.</response>
        /// <response code="500">The exception message.</response>
        [Authorize(Roles = "User")]
        [HttpGet("category-detail/{categoryId}")]
        [ProducesResponseType(typeof(CategoryResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<CategoryResponseDto>> GetCategoryById([FromRoute] Guid? categoryId,
                                                                             [FromServices] CategoryIdValidator validator)
        {
            var validationResult = validator.Validate((Guid)categoryId!);
            if (!validationResult.IsValid)
            {
                return ValidationFailure(validationResult);
            }

            try
            {
                var result = await _categoryService.GetCategoryByIdAsync((Guid)categoryId!);

                return Ok(result);
            }
            catch (NotFoundException notFoundExc)
            {
                return ErrorResponse(notFoundExc.ErrorCode,
                                     notFoundExc.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Get category by its name
        /// </summary>
        /// <param name="request"></param>
        /// <param name="validator"></param>
        /// <returns>Returns a category details.</returns>
        /// <response code="200">Returns a category details.</response>
        /// <response code="400">Error message.</response>
        /// <response code="401">The unauthorized message.</response>
        /// <response code="500">The exception message.</response>
        [Authorize(Roles = "User")]
        [HttpGet("category-detail")]
        [ProducesResponseType(typeof(CategoryResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<CategoryResponseDto>> GetCategoryByName(CategoryRequestDto request,
                                                                               [FromServices] CategoryRequestDtoValidator validator)
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return ValidationFailure(validationResult);
            }

            try
            {
                var result = await _categoryService.GetCategoryByNameAsync(request);

                return Ok(result);
            }
            catch (NotFoundException notFoundExc)
            {
                return ErrorResponse(notFoundExc.ErrorCode,
                                     notFoundExc.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Update a category
        /// </summary>
        /// <param name="request"></param>
        /// <param name="categoryId"></param>
        /// <param name="validator"></param>
        /// <param name="guidValidator"></param>
        /// <returns>Returns an updated category details.</returns>
        /// <response code="200">Returns an updated category details.</response>
        /// <response code="400">Error message.</response>
        /// <response code="401">The unauthorized message.</response>
        /// <response code="500">The exception message.</response>
        [Authorize(Roles = "Admin")]
        [HttpPut("{categoryId}")]
        [ProducesResponseType(typeof(CategoryResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<CategoryResponseDto>> UpdateCategorye(CategoryRequestDto request,
                                                                             [FromRoute] Guid? categoryId,
                                                                             [FromServices] CategoryRequestDtoValidator validator,
                                                                             [FromServices] CategoryIdValidator guidValidator)
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return ValidationFailure(validationResult);
            }

            var guidValidatorResult = guidValidator.Validate((Guid)categoryId!);
            if (!guidValidatorResult.IsValid)
            {
                return ValidationFailure(guidValidatorResult);
            }

            try
            {
                var result = await _categoryService.UpdateCategoryAsync(request, (Guid)categoryId!);

                return Ok(result);
            }
            catch (NotFoundException notFoundExc)
            {
                return ErrorResponse(notFoundExc.ErrorCode,
                                     notFoundExc.Message);
            }
            catch (InvalidParametersException InvalidParametersExc)
            {
                return ErrorResponse(InvalidParametersExc.ErrorCode,
                                     InvalidParametersExc.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
