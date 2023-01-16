using MediatR;
using Microsoft.AspNetCore.Identity;
using SmartFinances.Application;
using SmartFinances.Infrastructure;
using SmartFinances.Interfaces;
using SmartFinances.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;

builder.Services.AddControllersWithViews();

builder.Services.ConfigureInfractructureServices(configuration);
builder.Services.ConfigureApplicationServices();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IOverviewService, OverviewService>();
builder.Services.AddScoped<IBudgetPlannerService, BudgetPlannerService>();
builder.Services.AddScoped<IUsersService, UsersService>();

var app = builder.Build();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
