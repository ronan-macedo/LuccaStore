using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using LuccaStore.Application.Services;
using LuccaStore.Core.Application.Interfaces;
using LuccaStore.Core.Domain.Dtos.Identity;
using LuccaStore.Core.Domain.Entities;
using LuccaStore.Core.Domain.Interfaces;
using LuccaStore.Core.Domain.Models.Identity;
using LuccaStore.Domain.Models.Identity;
using NSubstitute;

namespace LuccaStore.Tests.Core.Application
{
    public class IdentityServiceTests
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IdentityService _sut;

        public IdentityServiceTests()
        {
            _identityRepository = Substitute.For<IIdentityRepository>();
            _tokenService = Substitute.For<ITokenService>();            
            _mapper = Substitute.For<IMapper>();

            _sut = new IdentityService(_identityRepository, _tokenService, _mapper);
        }

        [Theory, AutoData]
        public async Task LoginAsync_Returns_LoginResponseDto(LoginRequestDto request,
                                                              LoginModel model,
                                                              IdentityEntity entity)
        {
            // Arrange
            _mapper.Map<LoginModel>(request).Returns(model);
            _identityRepository.LoginAsync(model).Returns(entity);
            _tokenService.GetToken(entity.User, entity.Roles).Returns(Guid.NewGuid().ToString());

            // Act
            var actual = await _sut.LoginAsync(request);

            // Assert
            actual.Should().NotBeNull();
            actual.Should().BeOfType<LoginResponseDto>();
        }

        [Theory, AutoData]
        public async Task RegisterAdminAsync_Returns_RegisterResponseDto(RegisterRequestDto request,
                                                                         RegisterModel model,
                                                                         RegisterResponseDto response)
        {
            // Arrange
            _mapper.Map<RegisterModel>(request).Returns(model);
            _mapper.Map<RegisterResponseDto>(model).Returns(response);

            // Act
            var actual = await _sut.RegisterAdminAsync(request);

            // Assert
            actual.Should().NotBeNull();
            actual.Should().BeOfType<RegisterResponseDto>();
        }

        [Theory, AutoData]
        public async Task RegisterAsync_Returns_RegisterResponseDto(RegisterRequestDto request,
                                                                    RegisterModel model,
                                                                    RegisterResponseDto response)
        {
            // Arrange
            _mapper.Map<RegisterModel>(request).Returns(model);
            _mapper.Map<RegisterResponseDto>(model).Returns(response);

            // Act
            var actual = await _sut.RegisterAsync(request);

            // Assert
            actual.Should().NotBeNull();
            actual.Should().BeOfType<RegisterResponseDto>();
        }

        [Theory, AutoData]
        public async Task UnregisterAsync_Returns_RegisterResponseDto(UnregisterRequestDto request,
                                                                      UnregisterModel model,
                                                                      UnregisterResponseDto response)
        {
            // Arrange
            _mapper.Map<UnregisterModel>(request).Returns(model);
            _mapper.Map<UnregisterResponseDto>(model).Returns(response);

            // Act
            var actual = await _sut.UnregisterAsync(request);

            // Assert
            actual.Should().NotBeNull();
            actual.Should().BeOfType<UnregisterResponseDto>();
        }
    }
}
