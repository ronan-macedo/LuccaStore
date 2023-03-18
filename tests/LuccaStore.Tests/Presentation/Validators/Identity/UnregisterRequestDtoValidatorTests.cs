using AutoFixture.Xunit2;
using FluentAssertions;
using LuccaStore.Api.Validators.Identity;
using LuccaStore.Core.Domain.Dtos.Identity;

namespace LuccaStore.Tests.Presentation.Validators.Identity
{
    public class UnregisterRequestDtoValidatorTests
    {
        [Theory, AutoData]
        public void Validate_ValidLoginRequestDto_ReturnsSucess(UnregisterRequestDto dto, UnregisterRequestDtoValidator sut)
        {
            // Arrange & Act
            var result = sut.Validate(dto);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Theory, AutoData]
        public void Validate_InvalidLoginRequestDto_ReturnsFailure(UnregisterRequestDto dto, UnregisterRequestDtoValidator sut)
        {
            // Arrange
            dto.Username = "";            

            // Act
            var result = sut.Validate(dto);

            // Assert
            result.IsValid.Should().BeFalse();
        }
    }
}
