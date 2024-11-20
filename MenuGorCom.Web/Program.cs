using MenuGorCom.Infrastructure.Logging;
using MenuGorCom.API.Middleware;
using Microsoft.EntityFrameworkCore;
using MenuGorCom.Infrastructure.Data;
using MenuGorCom.Application.Interfaces;
using MenuGorCom.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Veritabaný baðlantýsý (Connection String)
builder.Services.AddDbContext<MenuGorDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAdminService, AdminService>();


// Serilog'u yapýlandýr
SerilogConfiguration.ConfigureLogger();


var app = builder.Build();

// Middleware'e ekle
app.UseMiddleware<RequestLoggingMiddleware>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
