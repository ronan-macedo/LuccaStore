using AutoMapper;
using LuccaStore.Core.Domain.Entities;
using LuccaStore.Core.Domain.Models.Categories;

namespace LuccaStore.Infrastructure.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<CategoryModel, CategoryEntity>();
        }
    }
}
