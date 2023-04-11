using AutoMapper;
using LuccaStore.Core.Domain.Dtos.Categories;
using LuccaStore.Core.Domain.Entities;

namespace LuccaStore.Infrastructure.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<CategoryEntity, CategoryResponseDto>();
        }
    }
}
