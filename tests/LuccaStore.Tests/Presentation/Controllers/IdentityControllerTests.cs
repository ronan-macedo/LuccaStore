using AutoFixture.Xunit2;
using LuccaStore.Api.Controllers;
using LuccaStore.Api.Validators.Identity;
using LuccaStore.Core.Application.Exceptions;
using LuccaStore.Core.Application.Interfaces;
using LuccaStore.Core.Domain.Common;
using LuccaStore.Core.Domain.Dtos.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace LuccaStore.Tests.Presentation.Controllers
{
    public class IdentityControllerTests
    {
        private readonly IIdentityService _identityService;
        private readonly IdentityController _sut;

        public IdentityControllerTests()
        {
            _identityService = Substitute.For<IIdentityService>();
            _sut = new IdentityController(_identityService);
        }

        #region POST Login
        [Theory, AutoData]
        public async Task Login_ReceiveValidRequest_ReturnsOK(LoginRequestDto request,
                                                              LoginRequestDtoValidator validator,
                                                              LoginResponseDto response)
        {
            // Arrange            
            _identityService.LoginAsync(Arg.Any<LoginRequestDto>()).Returns(response);

            // Act
            var actual = await _sut.Login(request, validator);

            // Assert
            var objectResult = (ObjectResult?)actual.Result;

            Assert.Equal(StatusCodes.Status200OK, objectResult?.StatusCode);
            Assert.IsType<LoginResponseDto>(objectResult?.Value);
        }

        [Theory, AutoData]
        public async Task Login_NotValidateRequest_ReturnsBadRequest(LoginRequestDto request,
                                                                     LoginRequestDtoValidator validator)
        {
            // Arrange
            request.Username = string.Empty;

            // Act
            var actual = await _sut.Login(request, validator);

            // Assert
            var objectResult = (ObjectResult?)actual.Result;

            Assert.Equal(StatusCodes.Status400BadRequest, objectResult?.StatusCode);
            Assert.IsType<ApiErrorResponse>(objectResult?.Value);
        }

        [Theory, AutoData]
        public async Task Login_ReceiveInvalidRequest_ThrowsAuthorizationException(LoginRequestDto request,
                                                                                   LoginRequestDtoValidator validator)
        {
            // Arrange
            _identityService.LoginAsync(Arg.Any<LoginRequestDto>())
                .ThrowsAsync(new AuthorizationException("test", "test"));

            // Act
            var actual = await _sut.Login(request, validator);

            // Assert
            var objectResult = (ObjectResult?)actual.Result;

            Assert.Equal(StatusCodes.Status400BadRequest, objectResult?.StatusCode);
            Assert.IsType<ApiErrorResponse>(objectResult?.Value);
        }

        [Theory, AutoData]
        public async Task Login_ReceiveInvalidRequest_ThrowsException(LoginRequestDto request,
                                                                      LoginRequestDtoValidator validator)
        {
            // Arrange
            _identityService.LoginAsync(Arg.Any<LoginRequestDto>())
                            .ThrowsAsync(new Exception("test"));

            // Act
            var actual = await _sut.Login(request, validator);

            // Assert
            var objectResult = (ObjectResult?)actual.Result;

            Assert.Equal(StatusCodes.Status500InternalServerError, objectResult?.StatusCode);
        }
        #endregion

        #region POST RegisterAdmin
        [Theory, AutoData]
        public async Task RegisterAdmin_ReceiveValidRequest_ReturnsOk(RegisterRequestDto request,
                                                                      RegisterRequestDtoValidator validator,
                                                                      RegisterResponseDto response)
        {
            // Arrange
            request.Email = "test@email.com";
            _identityService.RegisterAdminAsync(Arg.Any<RegisterRequestDto>()).Returns(response);

            // Act
            var actual = await _sut.RegisterAdmin(request, validator);

            // Assert
            var objectResult = (ObjectResult?)actual?.Result;

            Assert.Equal(StatusCodes.Status200OK, objectResult?.StatusCode);
            Assert.IsType<RegisterResponseDto>(objectResult?.Value);
        }

        [Theory, AutoData]
        public async Task RegisterAdmin_NotValidateRequest_ReturnsBadRequest(RegisterRequestDto request,
                                                                             RegisterRequestDtoValidator validator)
        {
            // Arrange & Act
            var actual = await _sut.RegisterAdmin(request, validator);

            // Assert
            var objectResult = (ObjectResult?)actual.Result;

            Assert.Equal(StatusCodes.Status400BadRequest, objectResult?.StatusCode);
            Assert.IsType<ApiErrorResponse>(objectResult?.Value);
        }

        [Theory, AutoData]
        public async Task RegisterAdmin_ReceiveInvalidRequest_ThrowsInvalidParametersException(RegisterRequestDto request,
                                                                                               RegisterRequestDtoValidator validator)
        {
            // Arrange
            request.Email = "test@email.com";
            _identityService.RegisterAdminAsync(Arg.Any<RegisterRequestDto>())
                            .ThrowsAsync(new InvalidParametersException("test", "test"));

            // Act
            var actual = await _sut.RegisterAdmin(request, validator);

            // Assert
            var objectResult = (ObjectResult?)actual.Result;

            Assert.Equal(StatusCodes.Status400BadRequest, objectResult?.StatusCode);
            Assert.IsType<ApiErrorResponse>(objectResult?.Value);
        }

        [Theory, AutoData]
        public async Task RegisterAdmin_ReceiveInvalidRequest_ThrowsException(RegisterRequestDto request,
                                                                              RegisterRequestDtoValidator validator)
        {
            // Arrange
            request.Email = "test@email.com";
            _identityService.RegisterAdminAsync(Arg.Any<RegisterRequestDto>())
                            .ThrowsAsync(new Exception("test"));

            // Act
            var actual = await _sut.RegisterAdmin(request, validator);

            // Assert
            var objectResult = (ObjectResult?)actual.Result;

            Assert.Equal(StatusCodes.Status500InternalServerError, objectResult?.StatusCode);
        }
        #endregion

        #region POST Register
        [Theory, AutoData]
        public async Task Register_ReceiveValidRequest_ReturnsOk(RegisterRequestDto request,
                                                                 RegisterRequestDtoValidator validator,
                                                                 RegisterResponseDto response)
        {
            // Arrange
            request.Email = "test@email.com";
            _identityService.RegisterAsync(Arg.Any<RegisterRequestDto>()).Returns(response);

            // Act
            var actual = await _sut.Register(request, validator);

            // Assert
            var objectResult = (ObjectResult?)actual?.Result;

            Assert.Equal(StatusCodes.Status200OK, objectResult?.StatusCode);
            Assert.IsType<RegisterResponseDto>(objectResult?.Value);
        }

        [Theory, AutoData]
        public async Task Register_NotValidateRequest_ReturnsBadRequest(RegisterRequestDto request,
                                                                        RegisterRequestDtoValidator validator)
        {
            // Arrange & Act
            var actual = await _sut.Register(request, validator);

            // Assert
            var objectResult = (ObjectResult?)actual.Result;

            Assert.Equal(StatusCodes.Status400BadRequest, objectResult?.StatusCode);
            Assert.IsType<ApiErrorResponse>(objectResult?.Value);
        }

        [Theory, AutoData]
        public async Task Register_ReceiveInvalidRequest_ThrowsInvalidParametersException(RegisterRequestDto request,
                                                                                          RegisterRequestDtoValidator validator)
        {
            // Arrange
            request.Email = "test@email.com";
            _identityService.RegisterAsync(Arg.Any<RegisterRequestDto>())
                            .ThrowsAsync(new InvalidParametersException("test", "test"));

            // Act
            var actual = await _sut.Register(request, validator);

            // Assert
            var objectResult = (ObjectResult?)actual.Result;

            Assert.Equal(StatusCodes.Status400BadRequest, objectResult?.StatusCode);
            Assert.IsType<ApiErrorResponse>(objectResult?.Value);
        }

        [Theory, AutoData]
        public async Task Register_ReceiveInvalidRequest_ThrowsException(RegisterRequestDto request,
                                                                         RegisterRequestDtoValidator validator)
        {
            // Arrange
            request.Email = "test@email.com";
            _identityService.RegisterAsync(Arg.Any<RegisterRequestDto>())
                            .ThrowsAsync(new Exception("test"));

            // Act
            var actual = await _sut.Register(request, validator);

            // Assert
            var objectResult = (ObjectResult?)actual.Result;

            Assert.Equal(StatusCodes.Status500InternalServerError, objectResult?.StatusCode);
        }
        #endregion

        #region POST Unregister
        [Theory, AutoData]
        public async Task Unregister_ReceiveValidRequest_ReturnsOk(UnregisterRequestDto request,
                                                                   UnregisterRequestDtoValidator validator,
                                                                   UnregisterResponseDto response)
        {
            // Arrange            
            _identityService.UnregisterAsync(Arg.Any<UnregisterRequestDto>()).Returns(response);

            // Act
            var actual = await _sut.Unregister(request, validator);

            // Assert
            var objectResult = (ObjectResult?)actual?.Result;

            Assert.Equal(StatusCodes.Status200OK, objectResult?.StatusCode);
            Assert.IsType<UnregisterResponseDto>(objectResult?.Value);
        }

        [Theory, AutoData]
        public async Task Unregister_NotValidateRequest_ReturnsBadRequest(UnregisterRequestDto request,
                                                                          UnregisterRequestDtoValidator validator)
        {
            // Arrange
            request.Username = string.Empty;

            // Act
            var actual = await _sut.Unregister(request, validator);

            // Assert
            var objectResult = (ObjectResult?)actual.Result;

            Assert.Equal(StatusCodes.Status400BadRequest, objectResult?.StatusCode);
            Assert.IsType<ApiErrorResponse>(objectResult?.Value);
        }

        [Theory, AutoData]
        public async Task Unregister_ReceiveInvalidRequest_ThrowsInvalidParametersException(UnregisterRequestDto request,
                                                                                            UnregisterRequestDtoValidator validator)
        {
            // Arrange            
            _identityService.UnregisterAsync(Arg.Any<UnregisterRequestDto>())
                            .ThrowsAsync(new InvalidParametersException("test", "test"));

            // Act
            var actual = await _sut.Unregister(request, validator);

            // Assert
            var objectResult = (ObjectResult?)actual.Result;

            Assert.Equal(StatusCodes.Status400BadRequest, objectResult?.StatusCode);
            Assert.IsType<ApiErrorResponse>(objectResult?.Value);
        }

        [Theory, AutoData]
        public async Task Unregister_ReceiveInvalidRequest_ThrowsException(UnregisterRequestDto request,
                                                                           UnregisterRequestDtoValidator validator)
        {
            // Arrange            
            _identityService.UnregisterAsync(Arg.Any<UnregisterRequestDto>())
                            .ThrowsAsync(new Exception("test"));

            // Act
            var actual = await _sut.Unregister(request, validator);

            // Assert
            var objectResult = (ObjectResult?)actual.Result;

            Assert.Equal(StatusCodes.Status500InternalServerError, objectResult?.StatusCode);
        }
        #endregion
    }
}
