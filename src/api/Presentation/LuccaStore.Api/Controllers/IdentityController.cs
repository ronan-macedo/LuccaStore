using LuccaStore.Api.Validators.Identity;
using LuccaStore.Core.Application.Exceptions;
using LuccaStore.Core.Application.Interfaces;
using LuccaStore.Core.Domain.Common;
using LuccaStore.Core.Domain.Dtos.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LuccaStore.Api.Controllers
{
    /// <summary>
    /// Identity Endpoints
    /// </summary>
    [Route("lucca-store-api/v1/identity")]
    public class IdentityController : ApiControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        /// <summary>
        /// Login to the api.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="validator"></param>
        /// <returns>Return an access token.</returns>
        /// <response code="200">The access token.</response>
        /// <response code="400">Error message.</response>
        [AllowAnonymous]
        [HttpPost("login")]        
        [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginRequestDto request,
                                                                [FromServices] LoginRequestDtoValidator validator)
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return ValidationFailure(validationResult);
            }

            try
            {
                var result = await _identityService.LoginAsync(request);

                return Ok(result);
            }
            catch (AuthorizationException authorizationExc)
            {
                return ErrorResponse(authorizationExc.ErrorCode,
                                     authorizationExc.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Register new user with Adim and User roles.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="validator"></param>
        /// <returns>Returns the username and email of a new user.</returns>
        /// <response code="200">Returns the username and email of a new user.</response>
        /// <response code="400">Error message.</response>
        /// <response code="401">The unauthorized message.</response>]        
        [Authorize(Roles = "Admin")]
        [HttpPost("register-admin")]
        [ProducesResponseType(typeof(RegisterResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<RegisterResponseDto>> RegisterAdmin([FromBody] RegisterRequestDto request,
                                                                           [FromServices] RegisterRequestDtoValidator validator)
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return ValidationFailure(validationResult);
            }

            try
            {
                var result = await _identityService.RegisterAdminAsync(request);

                return Ok(result);
            }
            catch (InvalidParametersException invalidParamExc)
            {
                return ErrorResponse(invalidParamExc.ErrorCode,
                                     invalidParamExc.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Register new user with User roles.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="validator"></param>
        /// <returns>Returns the username and email of a new user.</returns>
        /// <response code="200">Returns the username and email of a new user.</response>
        /// <response code="400">Error message.</response>
        /// <response code="401">The unauthorized message.</response>
        [Authorize(Roles = "User")]
        [HttpPost("register")]
        [ProducesResponseType(typeof(RegisterResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<RegisterResponseDto>> Register([FromBody] RegisterRequestDto request,
                                                                      [FromServices] RegisterRequestDtoValidator validator)
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return ValidationFailure(validationResult);
            }

            try
            {
                var result = await _identityService.RegisterAsync(request);

                return Ok(result);
            }
            catch (InvalidParametersException invalidParamExc)
            {
                return ErrorResponse(invalidParamExc.ErrorCode,
                                     invalidParamExc.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Delete a registered user.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="validator"></param>
        /// <returns>Returns the username of the deleted user.</returns>
        /// <response code="200">Returns the username of the deleted user.</response>
        /// <response code="400">Error message.</response>
        /// <response code="401">The unauthorized message.</response>
        [Authorize(Roles = "Admin")]
        [HttpPost("unregister")]
        [ProducesResponseType(typeof(UnregisterResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UnregisterResponseDto>> Unregister([FromBody] UnregisterRequestDto request,
                                                                          [FromServices] UnregisterRequestDtoValidator validator)
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return ValidationFailure(validationResult);
            }

            try
            {
                var result = await _identityService.UnregisterAsync(request);

                return Ok(result);
            }
            catch (InvalidParametersException invalidParamExc)
            {
                return ErrorResponse(invalidParamExc.ErrorCode,
                                     invalidParamExc.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
