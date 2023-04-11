using AutoMapper;
using LuccaStore.Core.Application.Interfaces;
using LuccaStore.Core.Domain.Dtos.Identity;
using LuccaStore.Core.Domain.Interfaces;
using LuccaStore.Core.Domain.Models.Identity;
using LuccaStore.Domain.Models.Identity;

namespace LuccaStore.Application.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public IdentityService(
            IIdentityRepository identityRepository,
            ITokenService tokenService,
            IMapper mapper)
        {
            _identityRepository = identityRepository;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public Task<IEnumerable<string>> GetRolesAsync(string username)
        {
            return _identityRepository.GetRolesAsync(username);
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto login)
        {
            var loginModel = _mapper.Map<LoginModel>(login);

            var identityEntity = await _identityRepository.LoginAsync(loginModel);

            var token = await _tokenService.GetToken(identityEntity.User, identityEntity.Roles);

            return new LoginResponseDto
            {
                Username = loginModel.Username,
                AccessToken = token,
                ExpireIn = DateTime.UtcNow.AddHours(2)
            };
        }

        public async Task<RegisterResponseDto> RegisterAdminAsync(RegisterRequestDto register)
        {
            var registerModel = _mapper.Map<RegisterModel>(register);
            
            await _identityRepository.RegisterAdminAsync(registerModel);            
            
            var registerDtoResponse = _mapper.Map<RegisterResponseDto>(registerModel);

            return registerDtoResponse;
        }

        public async Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto register)
        {
            var registerModel = _mapper.Map<RegisterModel>(register);
            
            await _identityRepository.RegisterAsync(registerModel);

            var registerDtoResponse = _mapper.Map<RegisterResponseDto>(registerModel);
            
            return registerDtoResponse;
        }

        public async Task<UnregisterResponseDto> UnregisterAsync(UnregisterRequestDto unregister)
        {
            var unregisterModel = _mapper.Map<UnregisterModel>(unregister);
            
            await _identityRepository.UnregisterAsync(unregisterModel);            

            var unregisterDtoResponse = _mapper.Map<UnregisterResponseDto>(unregisterModel);
            
            return unregisterDtoResponse;
        }
    }
}
