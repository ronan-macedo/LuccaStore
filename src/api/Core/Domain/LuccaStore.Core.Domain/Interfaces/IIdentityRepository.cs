using LuccaStore.Core.Domain.Entities;
using LuccaStore.Core.Domain.Models.Identity;
using LuccaStore.Domain.Models.Identity;

namespace LuccaStore.Core.Domain.Interfaces
{
    public interface IIdentityRepository
    {
        Task<IdentityEntity> LoginAsync(LoginModel login);
        Task RegisterAsync(RegisterModel register);
        Task RegisterAdminAsync(RegisterModel register);
        Task UnregisterAsync(UnregisterModel unregister);
    }
}
