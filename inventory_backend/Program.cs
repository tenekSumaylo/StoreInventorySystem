using inventory_backend.Data;
using inventory_backend.Models;
using inventory_backend.Services.AuthServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication.Google;
using FluentValidation;
using inventory_backend.Validations;
using inventory_backend.ProgramExtensions;
using inventory_backend.Roles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddCors(e =>
{
    e.AddPolicy("DevCors", p =>
    {
        p.WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.ConfigureSwaggerConfiguration(); // swagger gen in this extension method
builder.ConfigureDbContext();
builder.Services.ConfigureDependencyInjection();
builder.Services.AddValidatorsFromAssemblyContaining<LoginDtoValidator>();
builder.Services.ConfigureIdentityConfiguration();
builder.Services.ConfigureAuthentication(builder.Configuration);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var appDbContext = services.GetRequiredService<InventorySystemDbContext>();
    var identityContext = services.GetRequiredService<IdentityDbContext>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    appDbContext.Database.EnsureCreated();
    identityContext.Database.EnsureCreated();
    if ( !await roleManager.RoleExistsAsync(AppRoles.Customer))
    {
        await roleManager.CreateAsync(new IdentityRole(AppRoles.Customer));
    }

    if ( !await roleManager.RoleExistsAsync(AppRoles.Employee))
    {
        await roleManager.CreateAsync(new IdentityRole(AppRoles.Employee));
    }

}

app.MapControllers();
app.UseCors("DevCors");

app.UseAuthentication();
app.UseAuthorization();


app.Run();
