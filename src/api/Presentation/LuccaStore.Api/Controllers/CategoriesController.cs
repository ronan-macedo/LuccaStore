using FluentValidation.Validators;
using LuccaStore.Core.Application.Exceptions;
using LuccaStore.Core.Application.Interfaces;
using LuccaStore.Core.Domain;
using LuccaStore.Core.Domain.Dtos.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
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

        [Authorize(Roles = "User")]
        [HttpGet("{categoryId}")]
        public async Task<ActionResult<CategoryResponseDto>> GetCategoryById(Guid? categoryId)
        {
            if(categoryId == Guid.Empty || categoryId == null)
            {
                return ErrorResponse(MessageTemplate.InvalidGuidError,
                                     MessageTemplate.InvalidGuidErrorMessage);
            }

            try
            {
                var result = await _categoryService.GetCategoryByIdAsync((Guid)categoryId);

                return Ok(result);
            }
            catch(NotFoundException notFoundExc)
            {
                return ErrorResponse(notFoundExc.ErrorCode,
                                     notFoundExc.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize(Roles = "User")]
        [HttpGet]
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
    }
}
