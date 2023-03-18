using AutoFixture.Xunit2;
using FluentAssertions;
using LuccaStore.Api.Validators.Identity;
using LuccaStore.Core.Domain.Dtos.Identity;

namespace LuccaStore.Tests.Presentation.Validators.Identity
{
    public class RegisterRequestDtoValidatorTests
    {
        [Theory, AutoData]
        public void Validate_ValidRegisterRequestDto_ReturnsSucess(RegisterRequestDto dto, RegisterRequestDtoValidator sut)
        {
            // Arrange
            dto.Email = "test@email.com";

            // Act
            var result = sut.Validate(dto);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Theory, AutoData]
        public void Validate_InvalidRegisterRequestDto_ReturnsFailure(RegisterRequestDto dto, RegisterRequestDtoValidator sut)
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
