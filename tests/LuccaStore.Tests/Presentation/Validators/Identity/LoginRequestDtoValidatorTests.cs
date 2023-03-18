using AutoFixture.Xunit2;
using FluentAssertions;
using LuccaStore.Api.Validators.Identity;
using LuccaStore.Core.Domain.Dtos.Identity;

namespace LuccaStore.Tests.Presentation.Validators.Identity
{
    public class LoginRequestDtoValidatorTests
    {
        [Theory, AutoData]
        public void Validate_ValidLoginRequestDto_ReturnsSucess(LoginRequestDto dto, LoginRequestDtoValidator sut)
        {
            // Arrange & Act
            var result = sut.Validate(dto);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Theory, AutoData]
        public void Validate_InvalidLoginRequestDto_ReturnsFailure(LoginRequestDto dto, LoginRequestDtoValidator sut)
        {
            // Arrange
            dto.Username = "";
            dto.Password = "1234";

            // Act
            var result = sut.Validate(dto);

            // Assert
            result.IsValid.Should().BeFalse();
        }
    }
}
