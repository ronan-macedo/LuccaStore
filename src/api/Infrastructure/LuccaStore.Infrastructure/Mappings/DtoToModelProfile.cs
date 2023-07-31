using AutoMapper;
using LuccaStore.Core.Domain.Dtos.Categories;
using LuccaStore.Core.Domain.Dtos.Identity;
using LuccaStore.Core.Domain.Models.Categories;
using LuccaStore.Core.Domain.Models.Identity;
using LuccaStore.Domain.Models.Identity;
using System.Diagnostics.CodeAnalysis;

namespace LuccaStore.Infrastructure.Mappings
{
    [ExcludeFromCodeCoverage]
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<LoginRequestDto, LoginModel>();

            CreateMap<RegisterRequestDto, RegisterModel>();

            CreateMap<UnregisterRequestDto, UnregisterModel>();

            CreateMap<CategoryRequestDto, CategoryModel>()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForMember(src => src.CreateAt, opt => opt.Ignore())
                .ForMember(src => src.UpdateAt, opt => opt.Ignore());
        }
    }
}
