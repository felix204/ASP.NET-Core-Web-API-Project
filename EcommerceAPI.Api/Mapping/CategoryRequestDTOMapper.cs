using AutoMapper;
using ECommerceAPI.Entity.DTO.Category;
using ECommerceAPI.Entity.Poco;

namespace EcommerceAPI.Api.Mapping
{
    public class CategoryRequestDTOMapper:Profile
    {
        public CategoryRequestDTOMapper()
        {
            CreateMap<Category,CategoryRequestDTO>()
                .ForMember(dest => dest.Name, opt => { opt.MapFrom(src => src.Name); }).ReverseMap();
        }
    }
}
