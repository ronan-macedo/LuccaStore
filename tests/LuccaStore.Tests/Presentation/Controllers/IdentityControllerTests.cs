using AutoFixture.Xunit2;
using FluentAssertions;
using LuccaStore.Api.Controllers;
using LuccaStore.Api.Validators.Identity;
using LuccaStore.Core.Application.Interfaces;
using LuccaStore.Core.Domain.Common;
using LuccaStore.Core.Domain.Dtos.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

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
        public async Task Login_ReceiveValidRequest_ReturnsOK(LoginRequestDto dto,
                                                              LoginRequestDtoValidator validator,
                                                              LoginResponseDto response)
        {
            // Arrange
            _identityService.LoginAsync(dto).Returns(response);

            // Act
            var actual = await _sut.Login(dto, validator);

            // Assert
            var objectResult = (ObjectResult?)actual.Result;

            Assert.Equal(StatusCodes.Status200OK, objectResult?.StatusCode);
            Assert.IsType<LoginResponseDto>(objectResult?.Value);
        }

        [Theory, AutoData]
        public async Task Login_NotValidateRequest_ReturnsBadRequest(LoginRequestDto dto,
                                                                     LoginRequestDtoValidator validator)
        {
            // Arrange
            dto.Username = "";

            // Act
            var actual = await _sut.Login(dto, validator);

            // Assert
            var objectResult = (ObjectResult?)actual.Result;

            Assert.Equal(StatusCodes.Status400BadRequest, objectResult?.StatusCode);
            Assert.IsType<ApiErrorResponse>(objectResult?.Value);
        }

        [Theory, AutoData]
        public async Task Login_ReceiveInvalidRequest_ThrowsAuthorizationException(LoginRequestDto dto,
                                                                                   LoginRequestDtoValidator validator)
        {

        }
        #endregion
    }
}
