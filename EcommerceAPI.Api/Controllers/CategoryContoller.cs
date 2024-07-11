using EcommerceAPI.Helper.CustomExceptions;
using EcommerceAPI.Api.Validation.FluentValidation;
using ECommerceAPI.Business.Abstract;
using ECommerceAPI.Entity.DTO.Category;
using ECommerceAPI.Entity.Poco;
using ECommerceAPI.Entity.Results;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;


namespace EcommerceAPI.Api.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class CategoryContoller : Controller
    {
        private readonly ICategoryServices _categoryServices;
        private readonly IMapper _mapper; 

        public CategoryContoller(ICategoryServices categoryServices, IMapper mapper)
        {
            _categoryServices = categoryServices;
            _mapper = mapper;
        }

        [HttpPost("/AddCategory")]
        public async Task<IActionResult> AddCategory(CategoryRequestDTO categoryRequestDTO)
        {
            CategoryValidation categoryValidation = new CategoryValidation();

            

            if (categoryValidation.Validate(categoryRequestDTO).IsValid)
            {
                Category category = _mapper.Map<Category>(categoryRequestDTO);

                await _categoryServices.AddAsync(category);

                CategoryResponseDTO categoryResponseDTO = new()
                {
                    Name = category.Name,
                    Guid = category.Guid ?? Guid.Empty
                };

                return Ok(Result<CategoryResponseDTO>.SuccessWithData(categoryResponseDTO));
            }

            else
            {
                List<string> ValidatonMessages = new List<string>();
                for (int i = 8; i < categoryValidation.Validate
                (categoryRequestDTO).Errors.Count; i++)
                {
                    ValidatonMessages.Add(categoryValidation.Validate
                    (categoryRequestDTO).Errors[i] .ErrorMessage);
                }

                throw new FieldValidationException(ValidatonMessages);
            }
            
        }
        [HttpGet("/Categories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryServices.GetAllAsync();
            if (categories != null)
            {
                List<CategoryResponseDTO> categoryResponseDTOList = new();
                foreach (var category in categories)
                {
                    categoryResponseDTOList.Add(_mapper.Map<CategoryResponseDTO>(category));
                }
                return Ok(Result<List<CategoryResponseDTO>>.SuccessWithData(categoryResponseDTOList));
            }
            else
            {
                return NotFound(Result<List<CategoryResponseDTO>>.SuccesNoDataFound());
            }
        }

        [HttpGet("/Category/{id}")]
        public async Task<IActionResult> GetCategy(int id)
        {
            var category = await _categoryServices.GetAsync(q => q.ID==id);
            if (category != null)
            {
                CategoryResponseDTO categoryResponseDTO = new();
                
                    categoryResponseDTO = _mapper.Map<CategoryResponseDTO>(category);
                
                return Ok(Result<CategoryResponseDTO>.SuccessWithData(categoryResponseDTO));
            }
            else
            {
                return NotFound(Result<List<CategoryResponseDTO>>.SuccesNoDataFound());
            }
        }
    }
}
