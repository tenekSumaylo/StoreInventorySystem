using inventory_backend.Authentication;
using inventory_backend.Authentication.BasicAuthentication;
using inventory_backend.Authentication.GoogleAuthentication;
using inventory_backend.Dtos;
using inventory_backend.Mapper;
using inventory_backend.Products;
using inventory_backend.TokenServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using inventory_backend.Repository.ProductRepository;
using inventory_backend.Categories;
using inventory_backend.Repository.CategoryRepository;
namespace inventory_backend.ProgramExtensions
{
    public static class DependencyInjectionConfiguration
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            // services
            services.AddScoped<IAuthenticationService<LoginDto, RegisterDto>, BasicAuthenticationService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IGoogleAuthenticationService, GoogleAuthenticationService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            // repositories
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            // auto mapper
            services.AddAutoMapper(i =>
            {
                i.AddProfile<ProductProfile>();
                i.AddProfile<CategoryProfile>();
            });
        }
    }
}
