using AutoMapper;
using LuccaStore.Core.Domain.Entities;
using LuccaStore.Core.Domain.Models.Categories;

namespace LuccaStore.Infrastructure.Mappings
{
    public class EntityToModelProfile : Profile
    {
        public EntityToModelProfile()
        {
            CreateMap<CategoryEntity, CategoryModel>();
        }
    }
}
