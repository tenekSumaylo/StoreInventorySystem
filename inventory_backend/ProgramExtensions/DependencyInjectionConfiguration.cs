using inventory_backend.Authentication;
using inventory_backend.Authentication.BasicAuthentication;
using inventory_backend.Authentication.GoogleAuthentication;
using inventory_backend.Dtos;
using inventory_backend.Mapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using inventory_backend.Repository.ProductRepository;
using inventory_backend.Repository.CategoryRepository;
using inventory_backend.Services.Products;
using inventory_backend.Services.TokenServices;
using inventory_backend.Services.Categories;
using inventory_backend.Services.Tags;
using inventory_backend.Repository.TagsRepository;
using inventory_backend.Repository.ShoppingCartItemRepository;
using inventory_backend.Repository.ShoppingCartRepository;
using inventory_backend.Services.ShoppingCartService;
using inventory_backend.Services.ShoppingCartItemServices;
using inventory_backend.Services.CheckoutServices;
using inventory_backend.Repository.OrderRepository;
using inventory_backend.Repository.OrderItemRepository;
using inventory_backend.UnitOfWorkPattern;
using inventory_backend.Repository.GenericRepository;
using inventory_backend.Models;
namespace inventory_backend.ProgramExtensions
{
    public static class DependencyInjectionConfiguration
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            // services
            services.AddScoped<IBasicAuthenticationService, BasicAuthenticationService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IGoogleAuthenticationService, GoogleAuthenticationService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<IShoppingCartItemService, ShoppingCartItemService>();
            services.AddScoped<ICheckoutServices, CheckoutServices>();
            // repositories
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITagsRepository, TagsRepository>();
            services.AddScoped<IShoppingCartItemRepository, ShoppingCartItemRepository>();
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddHttpCacheHeaders();
            // auto mapper
            services.AddAutoMapper(i =>
            {
                i.AddProfile<ProductProfile>();
                i.AddProfile<CategoryProfile>();
                i.AddProfile<CustomerProfile>();
                i.AddProfile<EmployeeProfile>();
                i.AddProfile<TagProfile>();
                i.AddProfile<ShoppingCartProfile>();
                i.AddProfile<ShoppingCartItemProfile>();
            });
        }
    }
}
