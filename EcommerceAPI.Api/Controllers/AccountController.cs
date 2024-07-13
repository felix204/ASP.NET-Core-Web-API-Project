using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ECommerceAPI.Entity.DTO.Login;
using ECommerceAPI.Business.Abstract;
using ECommerceAPI.Entity.Results;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using ECommerceAPI.Api.Aspects;
using ECommerceAPI.Api.Validation.FluentValidation;


namespace EcommerceAPI.Api.Controllers
{
    [ApiController]
    [Route("action")]    
    public class AccountController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly IConfiguration _configuration;

        public AccountController(IUserServices userServices, IConfiguration configuration)
        {
            _userServices = userServices;
            _configuration = configuration;
        }
        [HttpPost("/login")]
        [ValidationFilter(typeof(LoginValidation))]
        public async Task<IActionResult> LoginAsync(LoginRequestDTO loginRequestDTO)
        {
            var user = await _userServices.GetAsync(x => x.Email == loginRequestDTO.UserName && x.Password == loginRequestDTO.Password);

            if (user == null)
            {
                return NotFound(Result<LoginResponseDTO>.SuccesNoDataFound());
            }
            else
            {
                var key = Encoding.UTF8.GetBytes
                    (_configuration.GetValue<string>("AppSettings:JWTKey"));

                var claims = new List<Claim>();

                claims.Add(new Claim("FirstName", user.FirstName));
                claims.Add(new Claim("ID", user.ID.ToString()));

                var jwt = new JwtSecurityToken(expires: DateTime.Now.AddDays(30),
                    notBefore: DateTime.Now,
                    claims: claims,
                    issuer: "http//asdaf.com",
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    );

                var token = new JwtSecurityTokenHandler().WriteToken(jwt);

                LoginResponseDTO loginResponseDTO = new LoginResponseDTO
                {
                    Token = token
                };
                return Ok(Result<LoginResponseDTO>.SuccessWithData(loginResponseDTO));

            }
        }
    }
}
