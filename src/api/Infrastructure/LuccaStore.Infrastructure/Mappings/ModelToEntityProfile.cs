﻿using AutoMapper;
using LuccaStore.Core.Domain.Entities;
using LuccaStore.Core.Domain.Models.Categories;
using System.Diagnostics.CodeAnalysis;

namespace LuccaStore.Infrastructure.Mappings
{
    [ExcludeFromCodeCoverage]
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<CategoryModel, CategoryEntity>();
        }
    }
}
