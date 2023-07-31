using AutoMapper;
using LuccaStore.Core.Domain.Dtos.Identity;
using LuccaStore.Core.Domain.Models.Identity;
using System.Diagnostics.CodeAnalysis;

namespace LuccaStore.Infrastructure.Mappings
{
    [ExcludeFromCodeCoverage]
    public class ModelToDtoProfile : Profile
    {
        public ModelToDtoProfile()
        {
            CreateMap<RegisterModel, RegisterResponseDto>();

            CreateMap<UnregisterModel, UnregisterResponseDto>();            
        }
    }
}
