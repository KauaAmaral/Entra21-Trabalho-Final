using Entra21.CSharp.Area21.Repository.DependeciesInjection;
using Entra21.CSharp.Area21.RepositoryDataBase;
using Entra21.CSharp.Area21.Service.DependenciesInjection;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using Entra21.CSharp.Area21.Repository.Entities;
using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    options.AreaViewLocationFormats.Clear();
    options.AreaViewLocationFormats.Add("/Areas/{2}/Views/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Areas/{2}/Views/{1}/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Areas/{2}/Views/Shared/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Views/{0}.cshtml");
});


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services
    .AddEntityFramework(builder.Configuration)
    .AddServices()
    .AddRepository()
    .AddEntitiesMapping();
  
var app = builder.Build();

var supportedCultures = new[] { new CultureInfo("pt-BR") };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

using (var scopo = app.Services.CreateScope())
{
    var contexto = scopo.ServiceProvider
        .GetService<ShortTermParkingContext>();
    contexto.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.UseEndpoints(endpoint =>
{
    endpoint.MapAreaControllerRoute(
        name: "AreaDriver",
        areaName: "Driver",
        pattern: "Driver/{controller=HomeDriver}/{action=Index}/{id?}");

    endpoint.MapAreaControllerRoute(
        name: "AreaPublic",
        areaName: "Public",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoint.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.Run();
