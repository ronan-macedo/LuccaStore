using Microsoft.AspNetCore.Identity;

namespace LuccaStore.Core.Application.Interfaces
{
    public interface ITokenService
    {
        Task<string> GetToken(IdentityUser user, IList<string>? userRoles);
    }
}
