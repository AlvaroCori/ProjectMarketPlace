using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using ProjectMarketPlace.API;
using ProjectMarketPlace.Repository.Implementation;
using ProjectMarketPlace.Models;
using ProjectMarketPlace.Extension;
using ProjectMarketPlace.Service;
using ProjectMarketPlace.Repository.Contract;
using ProjectMarketPlace.Mappers;

var builder = WebApplication.CreateBuilder(args);

MarketPlaceMapper.Configure();
builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();

IConfiguration configuration = builder.Configuration;


//builder.Services.AddCustomSwagger();
builder.Services.AddCustomSwagger(configuration);
builder.Services.AddCustomAuthentication(configuration);
builder.Services.AddDbContext<MarketPlaceDBContext>();
//Repositorios
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
//Servicios
///*
builder.Services.AddScoped<IUserService, UserService>();
//See product service for failures
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
//*/
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI();
    
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseCors(option => {
    option.WithOrigins("http://localhost:4200").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

    //option.AllowCredentials();
    //option.WithOrigins();
});
app.ConfigureExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
//app.UseStaticFiles(); --

app.UseRouting();

app.UseAuthorization();
/*
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); --
*/
app.MapControllers();
app.Run();


/*
 add-migration InitialDB
 update-database
 */


