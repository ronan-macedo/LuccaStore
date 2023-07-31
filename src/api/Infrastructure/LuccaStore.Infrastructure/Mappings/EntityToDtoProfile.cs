using AutoMapper;
using LuccaStore.Core.Domain.Dtos.Categories;
using LuccaStore.Core.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace LuccaStore.Infrastructure.Mappings
{
    [ExcludeFromCodeCoverage]
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<CategoryEntity, CategoryResponseDto>();
        }
    }
}
