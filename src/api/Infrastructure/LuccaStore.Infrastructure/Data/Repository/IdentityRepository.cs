using Microsoft.AspNetCore.Identity;
using LuccaStore.Domain.Models.Identity;
using LuccaStore.Core.Domain.Models.Identity;
using LuccaStore.Core.Application.Exceptions;
using LuccaStore.Core.Domain;
using LuccaStore.Core.Domain.Constants;
using LuccaStore.Core.Domain.Interfaces;
using LuccaStore.Core.Domain.Entities;
using Serilog;

namespace LuccaStore.Infrastructure.Data.Repository
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityRepository(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<string>> GetRolesAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                throw new NotFoundException(MessageTemplate.InvalidUserError,
                                            MessageTemplate.UserNotExistsMessage);
            }

            return await _userManager.GetRolesAsync(user);
        }

        public async Task<IdentityEntity> LoginAsync(LoginModel login)
        {
            var user = await _userManager.FindByNameAsync(login.Username);

            if (user != null && await _userManager.CheckPasswordAsync(user, login.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                return new IdentityEntity
                {
                    User = user,
                    Roles = userRoles
                };
            }

            throw new AuthorizationException(MessageTemplate.InvalidCredentialsMessage,
                                             MessageTemplate.InvalidCredentialsError);
        }

        public async Task RegisterAdminAsync(RegisterModel register)
        {
            var userExists = await _userManager.FindByNameAsync(register.Username);
            if (userExists != null)
            {
                throw new InvalidParametersException(MessageTemplate.UserExistsMessage,
                                                     MessageTemplate.InvalidUserError);
            }

            var user = new IdentityUser
            {
                Email = register.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = register.Username
            };

            var result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                throw new InvalidParametersException(MessageTemplate.RegistrationErrorMessage,
                                                     MessageTemplate.RegistrationError);
            }

            // Add Roles to the User
            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            if (await _roleManager.RoleExistsAsync(UserRoles.User))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }
        }

        public async Task RegisterAsync(RegisterModel register)
        {
            var userExists = await _userManager.FindByNameAsync(register.Username);
            if (userExists != null)
            {
                throw new InvalidParametersException(MessageTemplate.UserExistsMessage,
                                                     MessageTemplate.InvalidUserError);
            }

            var user = new IdentityUser
            {
                Email = register.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = register.Username
            };

            var result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                throw new InvalidParametersException(MessageTemplate.RegistrationErrorMessage,
                                                     MessageTemplate.RegistrationError);
            }

            if (await _roleManager.RoleExistsAsync(UserRoles.User))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }
        }

        public async Task UnregisterAsync(UnregisterModel unregister)
        {
            var user = await _userManager.FindByNameAsync(unregister.Username);
            if (user == null)
            {
                throw new NotFoundException(MessageTemplate.InvalidUserError,
                                            MessageTemplate.UserNotExistsMessage);
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidParametersException(MessageTemplate.UnregistrationError,
                                                     MessageTemplate.UnregistrationErrorMessage);
            }
        }
    }
}
