using AutoMapper;
using ECommerceAPI.Entity.DTO.Category;
using ECommerceAPI.Entity.Poco;

namespace EcommerceAPI.Api.Mapping
{
    public class CategoryResponseDTOMapper : Profile
    {
        public CategoryResponseDTOMapper()
        {
            CreateMap<Category, CategoryResponseDTO>()
                .ForMember(dest => dest.Name, opt => { opt.MapFrom(src => src.Name); }).ReverseMap();
        }
    }
}
