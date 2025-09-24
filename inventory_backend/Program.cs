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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.ConfigureSwaggerConfiguration(); // swagger gen in this extension method
builder.ConfigureDbContext();
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
app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();


app.Run();
