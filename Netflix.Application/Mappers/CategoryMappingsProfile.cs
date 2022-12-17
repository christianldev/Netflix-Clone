using AutoMapper;
using Netflix.Application.Dtos.Request;
using Netflix.Application.Dtos.Response;
using Netflix.Domain.Entities;
using Netflix.Infraestructure.Commons.Bases.Response;
using Netflix.Utilities.Static;

namespace Netflix.Application.Mappers
{
    public class CategoryMappingsProfile : Profile
    {
        public CategoryMappingsProfile()
        {

            CreateMap<Category, CategoryResponseDto>()
                .ForMember(x => x.StateCategory,
                x => x.MapFrom(y => y.State.Equals((int)StateTypes.Active) ? "Activo" : "Inactivo"))
                .ReverseMap();

            CreateMap<BaseEntityResponse<Category>, BaseEntityResponse<CategoryResponseDto>>()
                .ReverseMap();

            CreateMap<CategoryRequestDto, Category>();

            CreateMap<CategorySelectResponseDto, Category>()
                .ReverseMap();
        }
    }
}