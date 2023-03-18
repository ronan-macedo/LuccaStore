using AutoMapper;
using LuccaStore.Core.Domain.Dtos.Identity;
using LuccaStore.Core.Domain.Models.Identity;

namespace LuccaStore.Infrastructure.Mappings
{
    public class ModelToDtoProfile : Profile
    {
        public ModelToDtoProfile()
        {
            CreateMap<RegisterModel, RegisterResponseDto>();

            CreateMap<UnregisterModel, UnregisterResponseDto>();            
        }
    }
}
