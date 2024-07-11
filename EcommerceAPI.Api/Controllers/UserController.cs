using AutoMapper;
using EcommerceAPI.Api.Validation.FluentValidation;
using EcommerceAPI.Helper.CustomExceptions;
using ECommerceAPI.Business.Abstract;
using ECommerceAPI.Entity.DTO.Category;
using ECommerceAPI.Entity.DTO.User;
using ECommerceAPI.Entity.Poco;
using ECommerceAPI.Entity.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userService;
        private readonly IMapper _mapper;

        public UserController(IUserServices userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }





        // Users
        [HttpGet("/Users")]
        //[ProducesResponseType(typeof(Result<List<UserResponseDTO>>)), (int)HttpStatusCode.Ok]
        public async Task<IActionResult> GetUsers()
        {
            var users  = await _userService.GetAllAsync();
            List<UserResponseDTO> userDTOList = new();

            foreach (var user in users) 
            {
                userDTOList.Add(_mapper.Map<UserResponseDTO>(user));
            }

            return Ok(Result<List<UserResponseDTO>>.SuccessWithData(userDTOList));
        }






        //id User

        [HttpGet("/Users/{id}")]
        public async Task<IActionResult> GetUsers(int id)
        {
            var users = await _userService.GetAllAsync(x => x.ID == id);

            if (User!=null)
            {
                List<UserResponseDTO> UsersResponse = new();
                 
                foreach (var user in users)
                {
                    UsersResponse.Add(_mapper.Map<UserResponseDTO>(user));
                }

                return Ok(Result<List<UserResponseDTO>>.SuccessWithData(UsersResponse));
            }
            return NotFound(Result<UserResponseDTO>.SuccesNoDataFound());
           

            
        }





        //POST AddUser

        [HttpPost("/AddUser")]
        public async Task<IActionResult> AddUser(UserRequestDTO AddedUser)
        {

            UserRegisterValidation userRegisterValidation = new UserRegisterValidation();

            if (userRegisterValidation.Validate(AddedUser).IsValid)
            {
                User user = _mapper.Map<User>(AddedUser);

                await _userService.AddAsync(user);

                UserResponseDTO UserResponseDTO = _mapper.Map<UserResponseDTO>(user);

                return Ok(Result<UserResponseDTO>.SuccessWithData(UserResponseDTO));
            }
            else
            {
                List<string> ValidatonMessages = new List<string>();
                for (int i = 8; i < userRegisterValidation.Validate
                (AddedUser).Errors.Count; i++)
                {
                    ValidatonMessages.Add(userRegisterValidation.Validate
                    (AddedUser).Errors[i].ErrorMessage);
                }

                throw new FieldValidationException(ValidatonMessages);
            }

            

            //return Ok(Result<UserResponseDTO>.SuccessWithData(UserResponseDTO));
        }
    }
}
