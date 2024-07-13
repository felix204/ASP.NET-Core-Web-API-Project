using ECommerceAPI.Business.Abstract;
using Microsoft.AspNetCore.Identity;
using ECommerceAPI.Business.Concrate;
using ECommerceAPI.DAL.Concrete.EntityFramework.Context;
using ECommerceAPI.DAL.Abstract.DataManagment;
using ECommerceAPI.DAL.Concrete.EntityFramework.DataManagment;
using FluentValidation.AspNetCore;
using EcommerceAPI.Api.Middleware;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using ECommerceAPI.Api.Middleware;
using ECommerceAPI.Helper.Global;



var builder = WebApplication.CreateBuilder(args);




// Add services to the container.

builder.Services.AddControllers();

//AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<ShopContext>();

//Unit Of Work
builder.Services.AddScoped<IUnitOfWork, EFUnitOfWork>();

//Services
builder.Services.AddScoped<IUserServices, UserManager>();
builder.Services.AddScoped<ICategoryServices, CategoryManager>();

//Validation Nug
builder.Services.AddFluentValidationAutoValidation();

//Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

//ConfigureMonit
builder.Services.Configure<JWTExceptionURLList>(builder.Configuration.GetSection(nameof(JWTExceptionURLList)));

var app = builder.Build();



app.UseGlobalExceptionMiddleware();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseApiAuthorizationMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
