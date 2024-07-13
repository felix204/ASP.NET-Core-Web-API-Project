using ECommerceAPI.Entity.DTO.Login;
using FluentValidation;

namespace ECommerceAPI.Api.Validation.FluentValidation
{
    public class LoginValidation : AbstractValidator<LoginRequestDTO>
    {
        public LoginValidation() 
        {
            
        }
    }
}
