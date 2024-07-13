using ECommerceAPI.Helper.CustomExceptions;
using ECommerceAPI.Helper.Global;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Api.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ApiAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly IOptionsMonitor<JWTExceptionURLList> _optionMonitor;

        public ApiAuthorizationMiddleware(RequestDelegate next, IConfiguration configuration, Microsoft.Extensions.Options.IOptionsMonitor<JWTExceptionURLList> optionMonitor)
        {
            _next = next;
            _configuration = configuration;
            _optionMonitor = optionMonitor;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.Request.Path != null && ! _optionMonitor.CurrentValue.URLList.Contains(httpContext.Request.Path.Value))
            {
                var handler = new JwtSecurityTokenHandler();

                string authHeader = httpContext.Request.Headers["Authorization"];

                if (authHeader != null)
                {
                    var token = authHeader.Replace("Bearer", "");
                    var key = Encoding.UTF8.GetBytes
                        (_configuration.GetValue<string>("AppSettings:JWTKey"));

                    handler.ValidateToken(token, new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    }, out SecurityToken validateToken);

                    var JwtToken = (JwtSecurityToken)validateToken;

                    if (JwtToken.ValidTo < DateTime.Now)
                    {
                        httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    }

                    string? firstName = JwtToken.Claims.Where(q => q.Type == "FirstName").Select(q => q.Value).SingleOrDefault();

                    int? ID = Convert.ToInt32(JwtToken.Claims.Where(q => q.Type == "ID").Select(q => q.Value).SingleOrDefault());

                    if (string.IsNullOrEmpty(firstName) || ID == null)
                    {
                        httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        return;
                    }
                    else
                    {
                        throw new TokenNotFoundException();
                    }
                }
            }
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ApiAuthorizationMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiAuthorizationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiAuthorizationMiddleware>();
        }
    }
}
