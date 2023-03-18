using AutoMapper;
using LuccaStore.Core.Domain.Dtos.Identity;
using LuccaStore.Core.Domain.Models.Identity;
using LuccaStore.Domain.Models.Identity;

namespace LuccaStore.Infrastructure.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<LoginRequestDto, LoginModel>();

            CreateMap<RegisterRequestDto, RegisterModel>();

            CreateMap<UnregisterRequestDto, UnregisterModel>();            
        }
    }
}
