using Microsoft.EntityFrameworkCore;
using S.P.WithCleanArchitecture.Application.Interfaces;
using S.P.WithCleanArchitecture.Application.Services.EntityServices;
using S.P.WithCleanArchitecture.Application.Services.Mappings.UserMaps;
using S.P.WithCleanArchitecture.Application.Validations.Interfaces;
using S.P.WithCleanArchitecture.Domain.Interfaces;
using S.P.WithCleanArchitecture.Infrastructure.Data.DataBase;
using S.P.WithCleanArchitecture.Infrastructure.Repositories;
using S.P.WithCleanArchiteture.API.DTOs.User;
using S.P.WithCleanArchiteture.API.Middlewares;
using S.P.WithCleanArchiteture.API.Validator;
using S.P.WithCleanArchiteture.API.Validator.UserViewModelValidators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<CleanAchitectureDbContext>(options => {
    options.UseSqlServer(connectionString).EnableSensitiveDataLogging();
    });

//Inject Services
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


//Inject Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

//Inject AuthoMapper with assembly
builder.Services.AddAutoMapper(typeof(UserMapper));
builder.Services.AddAutoMapper(typeof(S.P.WithCleanArchiteture.API.Mappings.UserMapper));

//Inject Validators
builder.Services.AddScoped<IValidatorBase, ValidatorBase>();
builder.Services.AddScoped<IViewModelValidator<UserRegistrationViewModel>, UserRegistrationViewModelValidator>();
builder.Services.AddScoped<IViewModelValidator<UserLoginViewModel>, UserViewModelValidator>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
