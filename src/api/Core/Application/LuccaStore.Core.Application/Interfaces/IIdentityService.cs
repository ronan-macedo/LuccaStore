using LuccaStore.Core.Domain.Dtos.Identity;

namespace LuccaStore.Core.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto login);
        Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto register);
        Task<RegisterResponseDto> RegisterAdminAsync(RegisterRequestDto register);
        Task<UnregisterResponseDto> UnregisterAsync(UnregisterRequestDto unregister);
    }
}
