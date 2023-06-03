using DB_Web.IServices;
using DB_Web.Models;
using DB_Web.Services;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var conecctionString = builder.Configuration.GetConnectionString("DbWebContext");
builder.Services.AddDbContext<DbWebContext>(x=> x.UseSqlServer(conecctionString));
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<IConfigswebServices, ConfigswebServices>();
var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}") ;

app.Run();
