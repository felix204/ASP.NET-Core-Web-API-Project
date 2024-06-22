using ECommerceAPI.Business.Abstract;
using ECommerceAPI.Entity.DTO.User;
using ECommerceAPI.Entity.Poco;
using ECommerceAPI.Entity.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userService;

        public UserController(IUserServices userService)
        {
            _userService = userService;
        }

        [HttpGet("/Users/{id}")]
        public async Task<IActionResult> GetUsers(int id)
        {
            var users = await _userService.GetAllAsync(x => x.ID == id);
            List<UserResponseDTO> UsersResponse = new();

            foreach (var user in users)
            {
                UserResponseDTO userResponse = new();

                userResponse.FirstName = user.FirstName;
                userResponse.LastName = user.LastName;
                userResponse.Password = user.Password;
                userResponse.Email = user.Email;
                userResponse.Phone = user.Phone;
                userResponse.Adress = user.Adress;

                UsersResponse.Add(userResponse);


            };

            return Ok(Result<List<UserResponseDTO>>.SuccessWithData(UsersResponse));
        }

        [HttpPost("/AddUser")]
        public async Task<IActionResult> AddUser(UserRequestDTO AddedUser)
        {
            User user = new(); 
            user.FirstName = AddedUser.FirstName;
            user.LastName = AddedUser.LastName;
            user.Password = AddedUser.Password;
            user.Email = AddedUser.Email;
            user.Phone = AddedUser.Phone;
            user.Adress = AddedUser.Adress;

            await _userService.AddAsync(user);

            return Ok("İşlem Başarılı!!!");
        }
    }
}
