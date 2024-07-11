using FluentValidation;
using ECommerceAPI.Entity.DTO.Category;

namespace EcommerceAPI.Api.Validation.FluentValidation
{
    public class CategoryValidation:AbstractValidator<CategoryRequestDTO>
    {
        public CategoryValidation() 
        {
            RuleFor(q => q.Name).NotEmpty().WithMessage("Kategory Adı Boş Olamaz");
        }
    }
}
