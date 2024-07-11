using AutoMapper;
using ECommerceAPI.Entity.DTO.User;
using ECommerceAPI.Entity.Poco;

namespace EcommerceAPI.Api.Mapping
{
    public class UserRequestDTOMapper : Profile
    {
        public UserRequestDTOMapper()
        {
            CreateMap<User, UserRequestDTO>()
                .ForMember(dest => dest.FirstName, opt => { opt.MapFrom(src => src.FirstName); })
                .ForMember(dest => dest.LastName, opt => { opt.MapFrom(src => src.LastName); })
                .ForMember(dest => dest.Email, opt => { opt.MapFrom(src => src.Email); })
                .ForMember(dest => dest.Phone, opt => { opt.MapFrom(src => src.Phone); })
                .ForMember(dest => dest.Adress, opt => { opt.MapFrom(src => src.Adress); })
                .ForMember(dest => dest.Password, opt => { opt.MapFrom(src => src.Password); }).ReverseMap();
        }
    }
}
