using AutoFixture.Xunit2;
using LuccaStore.Core.Application.Exceptions;
using LuccaStore.Core.Domain.Constants;
using LuccaStore.Core.Domain.Models.Identity;
using LuccaStore.Domain.Models.Identity;
using LuccaStore.Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSubstitute;

namespace LuccaStore.Tests.Infrastructure.Data.Repository
{
    public class IdentityRepositoryTests
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IdentityRepository _sut;

        public IdentityRepositoryTests()
        {
            _userManager = Substitute.For<UserManager<IdentityUser>>(
                Substitute.For<IUserStore<IdentityUser>>(),
                Substitute.For<IOptions<IdentityOptions>>(),
                Substitute.For<IPasswordHasher<IdentityUser>>(),
                Array.Empty<IUserValidator<IdentityUser>>(),
                Array.Empty<IPasswordValidator<IdentityUser>>(),
                Substitute.For<ILookupNormalizer>(),
                Substitute.For<IdentityErrorDescriber>(),
                Substitute.For<IServiceProvider>(),
                Substitute.For<ILogger<UserManager<IdentityUser>>>());

            _roleManager = Substitute.For<RoleManager<IdentityRole>>(
                Substitute.For<IRoleStore<IdentityRole>>(),
                Array.Empty<IRoleValidator<IdentityRole>>(),
                Substitute.For<ILookupNormalizer>(),
                Substitute.For<IdentityErrorDescriber>(),
                Substitute.For<ILogger<RoleManager<IdentityRole>>>());

            _sut = new IdentityRepository(_userManager, _roleManager);
        }

        #region LoginAsync
        [Theory, AutoData]
        public async Task LoginAsync_Returns_IdentityEntity(LoginModel model,
                                                            IdentityUser user,
                                                            List<string> roles)
        {
            // Arrange            
            _userManager.FindByNameAsync(model.Username).Returns(user);
            _userManager.CheckPasswordAsync(user, model.Password).Returns(true);
            _userManager.GetRolesAsync(user).Returns(roles);

            // Act
            var actual = await _sut.LoginAsync(model);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(user, actual.User);
            Assert.Equal(roles, actual.Roles);
        }

        [Theory, AutoData]
        public async Task LoginAsync_Returns_ThrowsAuthorizationException(LoginModel model)
        {
            // Arrange            
            _userManager.FindByNameAsync(model.Username)
                        .Returns(Task.FromResult<IdentityUser>(null!));
            _userManager.CheckPasswordAsync(null!, model.Password).Returns(false);

            // Act & Assert
            await Assert.ThrowsAsync<AuthorizationException>(async () => await _sut.LoginAsync(model));
        }
        #endregion

        #region RegisterAdminAsync
        [Theory, AutoData]
        public async Task RegisterAdminAsync_CreatesIdentityUser(RegisterModel model)
        {
            // Arrange            
            _userManager.FindByNameAsync(model.Username)
                        .Returns(Task.FromResult<IdentityUser>(null!));

            _userManager.CreateAsync(Arg.Any<IdentityUser>(), model.Password)
                        .Returns(Task.FromResult(IdentityResult.Success));

            _roleManager.RoleExistsAsync(Arg.Any<string>()).Returns(true);

            // Act
            await _sut.RegisterAdminAsync(model);

            // Assert
            await _userManager.Received().CreateAsync(Arg.Any<IdentityUser>(), model.Password);
            await _userManager.Received().AddToRoleAsync(Arg.Any<IdentityUser>(), UserRoles.Admin);
            await _userManager.Received().AddToRoleAsync(Arg.Any<IdentityUser>(), UserRoles.User);
        }

        [Theory, AutoData]
        public async Task RegisterAdminAsync_UserExists_ThrowsInvalidParametersException(RegisterModel model,
                                                                                         IdentityUser user)
        {
            // Arrange
            _userManager.FindByNameAsync(model.Username).Returns(user);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidParametersException>(async () => await _sut.RegisterAdminAsync(model));
        }

        [Theory, AutoData]
        public async Task RegisterAdminAsync_IdentityResultFail_ThrowsInvalidParametersException(RegisterModel model)
        {
            // Arrange
            _userManager.FindByNameAsync(model.Username)
                        .Returns(Task.FromResult<IdentityUser>(null!));

            _userManager.CreateAsync(Arg.Any<IdentityUser>(), model.Password)
                        .Returns(Task.FromResult(new IdentityResult()));

            // Act & Assert
            await Assert.ThrowsAsync<InvalidParametersException>(async () => await _sut.RegisterAdminAsync(model));
        }
        #endregion

        #region RegisterAsync
        [Theory, AutoData]
        public async Task RegisterAsync_CreatesIdentityUser(RegisterModel model)
        {
            // Arrange            
            _userManager.FindByNameAsync(model.Username)
                        .Returns(Task.FromResult<IdentityUser>(null!));

            _userManager.CreateAsync(Arg.Any<IdentityUser>(), model.Password)
                        .Returns(Task.FromResult(IdentityResult.Success));

            _roleManager.RoleExistsAsync(Arg.Any<string>()).Returns(true);

            // Act
            await _sut.RegisterAsync(model);

            // Assert
            await _userManager.Received().CreateAsync(Arg.Any<IdentityUser>(), model.Password);            
            await _userManager.Received().AddToRoleAsync(Arg.Any<IdentityUser>(), UserRoles.User);
        }

        [Theory, AutoData]
        public async Task RegisterAsync_UserExists_ThrowsInvalidParametersException(RegisterModel model,
                                                                                         IdentityUser user)
        {
            // Arrange
            _userManager.FindByNameAsync(model.Username).Returns(user);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidParametersException>(async () => await _sut.RegisterAsync(model));
        }

        [Theory, AutoData]
        public async Task RegisterAsync_IdentityResultFail_ThrowsInvalidParametersException(RegisterModel model)
        {
            // Arrange
            _userManager.FindByNameAsync(model.Username)
                        .Returns(Task.FromResult<IdentityUser>(null!));

            _userManager.CreateAsync(Arg.Any<IdentityUser>(), model.Password)
                        .Returns(Task.FromResult(new IdentityResult()));

            // Act & Assert
            await Assert.ThrowsAsync<InvalidParametersException>(async () => await _sut.RegisterAsync(model));
        }
        #endregion

        #region UnregisterAsync
        [Theory, AutoData]
        public async Task UnregisterAsync_DeleteIdentityUser(UnregisterModel model, IdentityUser user)
        {
            // Arrange            
            _userManager.FindByNameAsync(model.Username).Returns(user);

            _userManager.DeleteAsync(user)
                        .Returns(Task.FromResult(IdentityResult.Success));            

            // Act
            await _sut.UnregisterAsync(model);

            // Assert
            await _userManager.Received().DeleteAsync(Arg.Any<IdentityUser>());            
        }

        [Theory, AutoData]
        public async Task UnregisterAsync_UserNotExists_ThrowsInvalidParametersException(UnregisterModel model)
        {
            // Arrange
            _userManager.FindByNameAsync(model.Username)
                .Returns(Task.FromResult<IdentityUser>(null!));

            // Act & Assert
            await Assert.ThrowsAsync<InvalidParametersException>(async () => await _sut.UnregisterAsync(model));
        }

        [Theory, AutoData]
        public async Task UnregisterAsync_IdentityResultFail_ThrowsInvalidParametersException(UnregisterModel model,
                                                                                              IdentityUser user)
        {
            // Arrange
            _userManager.FindByNameAsync(model.Username)
                        .Returns(user);

            _userManager.DeleteAsync(user)
                        .Returns(Task.FromResult(new IdentityResult()));

            // Act & Assert
            await Assert.ThrowsAsync<InvalidParametersException>(async () => await _sut.UnregisterAsync(model));
        }
        #endregion
    }
}
