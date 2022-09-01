using Entra21.CSharp.Area21.Repository.DependenciesInjection;
using Entra21.CSharp.Area21.RepositoryDataBase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services
    .InsertEntityFramework(builder.Configuration);

var app = builder.Build();

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
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
