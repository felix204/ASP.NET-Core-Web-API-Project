using ECommerceAPI.Entity.DTO.User;
using FluentValidation;

namespace EcommerceAPI.Api.Validation.FluentValidation
{
    public class UserRegisterValidation : AbstractValidator<UserRequestDTO>
    {
        public UserRegisterValidation() 
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("İsim Boş Olamaz");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyisim Boş Olamaz");
            RuleFor(x => x.Adress).NotEmpty().WithMessage("Adres Boş Olamaz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Boş Olamaz");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon Boş Olamaz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Boş Olamaz");
        }
    }
}
